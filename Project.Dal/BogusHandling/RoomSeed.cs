using Bogus;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    /// <summary>
    /// Sahte (fake) oda verilerini oluşturur ve veritabanına ekler.
    /// Room tablosuna örnek odaları eklemek için kullanılır.
    /// </summary>
    public static class RoomSeed
    {
        /// <summary>
        /// ModelBuilder kullanarak Room verilerini seed (ön yükleme) yapar.
        /// </summary>
        public static void SeedRooms(ModelBuilder modelBuilder)
        {
            List<Room> rooms = new();
            int roomId = 1;         // Oda Id başlangıç değeri
            int roomNumber = 100;   // Oda numarası başlangıç değeri

            // 1. Kat - Tek Kişilik (10) & Üç Kişilik (10)
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 1,
                    PricePerNight = 1000,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 1, // Tek Kişilik (1)
                    HasBalcony = false,
                    HasMinibar = false,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 1,
                    PricePerNight = 1500,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 4, // Üç Kişilik (Tek kişilik üç yatak) (4)
                    HasBalcony = false,
                    HasMinibar = false,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            // 2. Kat - Tek Kişilik (10) & İki Kişilik (10)
            roomNumber = 200;
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 2,
                    PricePerNight = 1200,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 1, // Tek Kişilik (1)
                    HasBalcony = false,
                    HasMinibar = false,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 2,
                    PricePerNight = 1800,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 3, // İki Kişilik (Tek kişilik iki yataklı) (3)
                    HasBalcony = false,
                    HasMinibar = true,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            // 3. Kat - İki Kişilik (10) & Üç Kişilik (10)
            roomNumber = 300;
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 3,
                    PricePerNight = 2200,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 2, // İki Kişilik (Duble yataklı) (2)
                    HasBalcony = true,
                    HasMinibar = true,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 3,
                    PricePerNight = 2500,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 5, // Üç Kişilik (1 Tek, 1 Duble yatak) (5)
                    HasBalcony = true,
                    HasMinibar = true,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            // 4. Kat - İki Kişilik (10) & Dört Kişilik (6) & Kral Dairesi (1)
            roomNumber = 400;
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 4,
                    PricePerNight = 2800,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 2, // İki Kişilik (Duble yataklı) (2)
                    HasBalcony = true,
                    HasMinibar = true,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            for (int i = 0; i < 6; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = roomNumber++.ToString(),
                    Floor = 4,
                    PricePerNight = 3500,
                    RoomStatus = RoomStatus.Empty,
                    RoomTypeId = 6, // Dört Kişilik (1 Duble, 2 Tek kişilik) (6)
                    HasBalcony = true,
                    HasMinibar = true,
                    HasAirConditioner = true,
                    HasTV = true,
                    HasHairDryer = true,
                    HasWifi = true,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            // Özel Kral Dairesi
            rooms.Add(new Room
            {
                Id = roomId++,
                RoomNumber = "417",
                Floor = 4,
                PricePerNight = 10000,
                RoomStatus = RoomStatus.Empty,
                RoomTypeId = 7, // Kral Dairesi (7)
                HasBalcony = true,
                HasMinibar = true,
                HasAirConditioner = true,
                HasTV = true,
                HasHairDryer = true,
                HasWifi = true,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            });

            // Tüm odaları EF Core ile seed et
            modelBuilder.Entity<Room>().HasData(rooms);
        }
    }
}
