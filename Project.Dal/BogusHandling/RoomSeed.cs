using Bogus;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.BogusHandling
{
    public static class RoomSeed
    {
        public static void SeedRooms(ModelBuilder modelBuilder)
        {
            var faker = new Faker();
            List<Room> rooms = new();

            int roomId = 1;

            // **1. Kat - Tek Kişilik ve Üç Kişilik Odalar**
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = faker.Random.Int(100, 199).ToString(), // 100-199 arası oda numarası
                    Floor = 1,
                    PricePerNight = faker.Finance.Amount(50, 200, 2), // 50-200 TL arası
                    RoomStatus = faker.PickRandom<RoomStatus>(), // Rastgele durum
                    RoomTypeId = faker.PickRandom(new int[] { 1, 3 }), // Tek Kişilik (1) veya Üç Kişilik (3)
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                });
            }

            // **2. Kat - Tek Kişilik ve İki Kişilik Odalar**
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = faker.Random.Int(200, 299).ToString(),
                    Floor = 2,
                    PricePerNight = faker.Finance.Amount(100, 250, 2),
                    RoomStatus = faker.PickRandom<RoomStatus>(),
                    RoomTypeId = faker.PickRandom(new int[] { 1, 2 }) // Tek Kişilik (1) veya Çift Kişilik (2)
                });
            }

            // **3. Kat - Çift Kişilik (Duble) ve Üç Kişilik Odalar**
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = faker.Random.Int(300, 399).ToString(),
                    Floor = 3,
                    PricePerNight = faker.Finance.Amount(150, 300, 2),
                    RoomStatus = faker.PickRandom<RoomStatus>(),
                    RoomTypeId = faker.PickRandom(new int[] { 2, 3 }), // Çift Kişilik (2) veya Üç Kişilik (3)
                });
            }

            // **4. Kat - Çift Kişilik, Dört Kişilik ve Kral Dairesi**
            for (int i = 0; i < 10; i++)
            {
                rooms.Add(new Room
                {
                    Id = roomId++,
                    RoomNumber = faker.Random.Int(400, 499).ToString(),
                    Floor = 4,
                    PricePerNight = faker.Finance.Amount(200, 500, 2),
                    RoomStatus = faker.PickRandom<RoomStatus>(),
                    RoomTypeId = faker.PickRandom(new int[] { 2, 4 }) // Çift Kişilik (2) veya Dört Kişilik (4)
                });
            }

            // **Özel Kral Dairesi (4. Kat)**
            rooms.Add(new Room
            {
                Id = roomId++,
                RoomNumber = "500",
                Floor = 4,
                PricePerNight = 1000, // Kral Dairesi için sabit fiyat
                RoomStatus = RoomStatus.Empty, // Varsayılan olarak boş
                RoomTypeId = 5 // Kral Dairesi (5)
            });

            modelBuilder.Entity<Room>().HasData(rooms);
        }
    }
}
