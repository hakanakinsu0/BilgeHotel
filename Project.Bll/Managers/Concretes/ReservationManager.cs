using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class ReservationManager : BaseManager<ReservationDto, Reservation>, IReservationManager
    {
        readonly IReservationRepository _repository;
        readonly IRoomRepository _roomRepository;

        public ReservationManager(IReservationRepository repository, IRoomRepository roomRepository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _roomRepository = roomRepository;
        }

        // Çakışma kontrolü
        public bool CheckAvailability(int roomId, DateTime startDate, DateTime endDate)
        {
            return !_repository.Where(r => r.RoomId == roomId &&
                                           ((startDate >= r.StartDate && startDate < r.EndDate) ||
                                            (endDate > r.StartDate && endDate <= r.EndDate)))
                               .Any();
        }

        // Yeni rezervasyon ekleme
        public async Task<string> CreateReservation(ReservationDto dto)
        {
            if (!CheckAvailability(dto.RoomId, dto.StartDate, dto.EndDate))
            {
                return "Bu tarihler arasında oda dolu.";
            }

            dto.TotalPrice = CalculatePrice(dto); // Fiyat hesaplamasını entegre ediyoruz.
            await CreateAsync(dto);
            return "Rezervasyon başarıyla oluşturuldu.";
        }

        // Fiyat hesaplama
        private decimal CalculatePrice(ReservationDto dto)
        {
            var room = _roomRepository.GetByIdAsync(dto.RoomId).Result;
            decimal basePrice = room.PricePerNight * (dto.EndDate - dto.StartDate).Days;

            if (dto.PackageId.HasValue)
            {
                basePrice *= dto.PackageId == 1 ? 1.2m : 1.5m; // Tam Pansiyon: x1.2, Her Şey Dahil: x1.5
            }

            // **Erken Rezervasyon İndirimi**
            int daysBefore = (dto.StartDate - DateTime.Today).Days;

            if (daysBefore >= 90)
                basePrice *= 0.77m; // %23 indirim
            else if (daysBefore >= 30)
                basePrice *= dto.PackageId == 2 ? 0.82m : 0.84m; // Her Şey Dahil: %18, Tam Pansiyon: %16

            return basePrice;
        }
    }
}
