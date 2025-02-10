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
    public static class RoomTypeSeed
    {
        public static void SeedRoomTypes(ModelBuilder modelBuilder)
        {
            List<RoomType> roomTypes = new()
            {

                new RoomType { Id = 1, Name = "Tek Kişilik", Description = "1 tek kişilik yatak", CreatedDate = DateTime.Now,Status = DataStatus.Inserted },
                new RoomType { Id = 2, Name = "Çift Kişilik (Duble)", Description = "1 büyük yatak", CreatedDate=DateTime.Now,Status = DataStatus.Inserted},
                new RoomType { Id = 3, Name = "Üç Kişilik", Description = "3 tek kişilik yatak", CreatedDate = DateTime.Now, Status = DataStatus.Inserted},
                new RoomType { Id = 4, Name = "Dört Kişilik", Description = "1 büyük + 2 tek kişilik yatak", CreatedDate = DateTime.Now,Status = DataStatus.Inserted},
                new RoomType { Id = 5, Name = "Kral Dairesi", Description = "Lüks konaklama, özel hizmetler", CreatedDate = DateTime.Now, Status = DataStatus.Inserted},
            };

            modelBuilder.Entity<RoomType>().HasData(roomTypes);
        }
    }
}
