using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class ReservationExtraServiceManager : BaseManager<ReservationExtraServiceDto, ReservationExtraService>, IReservationExtraServiceManager
    {
        readonly IReservationExtraServiceRepository _repository;

        public ReservationExtraServiceManager(IReservationExtraServiceRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Belirtilen rezervasyon için yeni ekstra hizmet listesine göre güncelleme yapar.
        /// Eski kayıtlar silinir, yeniden aktif edilir veya yeni kayıtlar eklenir.
        /// </summary>
        public async Task UpdateExtraServicesForReservation(int reservationId, List<int> newExtraServiceIds)
        {
            newExtraServiceIds = newExtraServiceIds ?? new List<int>();

            // Var olan ilişkili servisleri çek
            List<ReservationExtraService> existingServices = await _repository.Where(res => res.ReservationId == reservationId).ToListAsync();

            // Silinecek olanları bul: yeni listede olmayan ve hâlâ aktif olanlar
            List<ReservationExtraService> servicesToDelete = existingServices
                .Where(es => !newExtraServiceIds.Contains(es.ExtraServiceId) && es.Status != DataStatus.Deleted)
                .ToList();

            foreach (ReservationExtraService service in servicesToDelete)
            {
                service.Status = DataStatus.Deleted;
                service.DeletedDate = DateTime.Now;
                service.ModifiedDate = DateTime.Now;
                await _repository.UpdateAsync(service, service);
            }

            // Daha önce silinmiş olanları reaktif et
            List<ReservationExtraService> servicesToReactivate = existingServices
                .Where(es => newExtraServiceIds.Contains(es.ExtraServiceId) && es.Status == DataStatus.Deleted)
                .ToList();

            foreach (ReservationExtraService service in servicesToReactivate)
            {
                service.Status = DataStatus.Updated;
                service.DeletedDate = null;
                service.ModifiedDate = DateTime.Now;
                await _repository.UpdateAsync(service, service);
            }

            // Tamamen yeni olan servisleri bul ve ekle
            List<int> existingServiceIds = existingServices.Select(es => es.ExtraServiceId).ToList();
            List<ReservationExtraService> servicesToAdd = newExtraServiceIds
                .Where(id => !existingServiceIds.Contains(id))
                .Select(id => new ReservationExtraService
                {
                    ReservationId = reservationId,
                    ExtraServiceId = id,
                    Status = DataStatus.Updated,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }).ToList();

            if (servicesToAdd.Any())
            {
                await _repository.CreateRangeAsync(servicesToAdd);
            }
        }

        /// <summary>
        /// DTO listesini alarak, BaseManager üzerinden tek tek CreateAsync çağırır.
        /// </summary>
        public async Task CreateRangeAsync(List<ReservationExtraServiceDto> dtoList)
        {
            foreach (ReservationExtraServiceDto dto in dtoList)
            {
                await CreateAsync(dto);
            }
        }

        /// <summary>
        /// Verilen rezervasyon ID’sine ait ekstra servisleri DTO olarak getirir.
        /// </summary>
        public async Task<List<ReservationExtraServiceDto>> GetByReservationIdAsync(int reservationId)
        {
            List<ReservationExtraService> extraServices = await _repository.Where(res => res.ReservationId == reservationId).ToListAsync();
            return _mapper.Map<List<ReservationExtraServiceDto>>(extraServices);
        }

        /// <summary>
        /// Verilen DTO'ya karşılık gelen veriyi Deleted duruma getirir.
        /// </summary>
        public async Task UpdateDeletedAsync(ReservationExtraServiceDto dto)
        {
            dto.Status = DataStatus.Deleted;
            dto.DeletedDate = DateTime.Now;

            ReservationExtraService existingEntity = await _repository.GetByIdAsync(dto.Id);
            ReservationExtraService updatedEntity = _mapper.Map<ReservationExtraService>(dto);

            await _repository.UpdateAsync(existingEntity, updatedEntity);
        }

        /// <summary>
        /// Belirli bir rezervasyona ait tüm aktif ekstra hizmetleri iptal eder.
        /// </summary>
        public async Task CancelExtraServicesByReservationIdAsync(int reservationId)
        {
            List<ReservationExtraService> extraServices = await _repository.Where(res => res.ReservationId == reservationId).ToListAsync();

            foreach (ReservationExtraService service in extraServices.Where(x => x.Status != DataStatus.Deleted))
            {
                service.Status = DataStatus.Deleted;
                service.DeletedDate = DateTime.Now;
                service.ModifiedDate = DateTime.Now;
                await _repository.UpdateAsync(service, service);
            }
        }
    }
}
