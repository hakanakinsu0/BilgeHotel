﻿using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    public static class RoomTypeSeed
    {
        public static void SeedRoomTypes(ModelBuilder modelBuilder)
        {
            List<RoomType> roomTypes = new()
            {
                new RoomType {
                    Id = 1,
                    Name = "Tek Kişilik",
                    Description = "1 adet tek kişilik yatak. Balkon ve minibar bulunmaz. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new RoomType {
                    Id = 2,
                    Name = "Çift Kişilik (Duble)",
                    Description = "1 adet büyük (duble) yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new RoomType {
                    Id = 3,
                    Name = "Çift Kişilik (Tek Kişilik 2 Yataklı)",
                    Description = "2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new RoomType {
                    Id = 4,
                    Name = "Üç Kişilik (Tek Kişilik 3 Yataklı)",
                    Description = "3 adet tek kişilik yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new RoomType {
                    Id = 5,
                    Name = "Üç Kişilik (1 Tek, 1 Duble Yataklı)",
                    Description = "Bir tek bir duble yatak.  Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new RoomType {
                    Id = 6,
                    Name = "Dört Kişilik",
                    Description = "1 adet büyük (duble) yatak + 2 adet tek kişilik yatak. Klima, TV, saç kurutma makinesi ve WiFi mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new RoomType {
                    Id = 7,
                    Name = "Kral Dairesi",
                    Description = "Geniş ve lüks oda. Özel oturma alanı, büyük yatak, balkon, minibar, özel banyo ve lüks hizmetler. Klima, TV, saç kurutma makinesi, WiFi ve özel hizmetler mevcuttur.",
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<RoomType>().HasData(roomTypes);
        }
    }
}
