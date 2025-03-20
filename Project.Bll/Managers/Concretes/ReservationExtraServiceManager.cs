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

        public async Task UpdateExtraServicesForReservation(int reservationId, List<int> newExtraServiceIds)
        {
            var existingServices = await _repository.Where(res => res.ReservationId == reservationId).ToListAsync();

            // 1️⃣ Silinecek hizmetleri belirle (Şu an seçili olmayanlar)
            var servicesToDelete = existingServices
                .Where(es => !newExtraServiceIds.Contains(es.ExtraServiceId) && es.Status != DataStatus.Deleted)
                .ToList();

            foreach (var service in servicesToDelete)
            {
                service.Status = DataStatus.Deleted; // Silinmek yerine işaretleniyor
                service.DeletedDate = DateTime.Now;
                service.ModifiedDate = DateTime.Now;
                await _repository.UpdateAsync(service, service); // Güncelleme yapılıyor
            }

            // 2️⃣ Daha önce Deleted olan hizmetleri geri aktif hale getirme
            var servicesToReactivate = existingServices
                .Where(es => newExtraServiceIds.Contains(es.ExtraServiceId) && es.Status == DataStatus.Deleted)
                .ToList();

            foreach (var service in servicesToReactivate)
            {
                service.Status = DataStatus.Updated; // Yeniden aktif hale getir
                service.DeletedDate = null;
                service.ModifiedDate = DateTime.Now;
                await _repository.UpdateAsync(service, service);
            }

            // 3️⃣ Yeni eklenen hizmetleri bul ve ekle
            var existingServiceIds = existingServices.Select(es => es.ExtraServiceId).ToList();
            var servicesToAdd = newExtraServiceIds
                .Where(id => !existingServiceIds.Contains(id))
                .Select(id => new ReservationExtraService
                {
                    ReservationId = reservationId,
                    ExtraServiceId = id,
                    Status = DataStatus.Inserted,
                    ModifiedDate = DateTime.Now
                }).ToList();

            if (servicesToAdd.Any())
            {
                await _repository.CreateRangeAsync(servicesToAdd);
            }
        }




        public async Task CreateRangeAsync(List<ReservationExtraServiceDto> dtoList)
        {
            foreach (var dto in dtoList)
            {
                await CreateAsync(dto); // BaseManager'daki CreateAsync metodunu kullanıyoruz.
            }
        }

        public async Task<List<ReservationExtraServiceDto>> GetByReservationIdAsync(int reservationId)
        {
            var extraServices = await _repository.Where(res => res.ReservationId == reservationId).ToListAsync();
            return _mapper.Map<List<ReservationExtraServiceDto>>(extraServices);
        }

        public async Task UpdateDeletedAsync(ReservationExtraServiceDto dto)
        {
            dto.Status = DataStatus.Deleted;
            dto.DeletedDate = DateTime.Now;

            var existingEntity = await _repository.GetByIdAsync(dto.Id); // Mevcut veriyi çekiyoruz.
            var updatedEntity = _mapper.Map<ReservationExtraService>(dto); // Güncellenmiş veriyi oluşturuyoruz.

            await _repository.UpdateAsync(existingEntity, updatedEntity); // Güncelleme yapılıyor.
        }


        /// <summary>
        /// Belirtilen rezervasyona ait ekstra servislerin tamamını iptal eder.
        /// Aktif durumda olan (Deleted olmayan) tüm ekstra servislerin statusunu Deleted yapar,
        /// DeletedDate ve ModifiedDate alanlarını günceller.
        /// </summary>
        /// <param name="reservationId">Ekstra servisleri iptal edilecek rezervasyonun ID'si</param>
        /// <returns>Asenkron işlem için Task</returns>
        public async Task CancelExtraServicesByReservationIdAsync(int reservationId)
        {
            // İlgili rezervasyona ait ekstra servisleri çekiyoruz.
            var extraServices = await _repository.Where(res => res.ReservationId == reservationId).ToListAsync();

            // Durumu Deleted olmayan tüm ekstra servisler için güncelleme yapıyoruz.
            foreach (var service in extraServices.Where(x => x.Status != DataStatus.Deleted))
            {
                service.Status = DataStatus.Deleted;
                service.DeletedDate = DateTime.Now;
                service.ModifiedDate = DateTime.Now;
                await _repository.UpdateAsync(service, service);
            }
        }


    }
}
