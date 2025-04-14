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
    public static class InventoryItemSeed
    {
        public static void SeedInventoryItems(ModelBuilder builder)
        {
            int employeeId = 44;
            DateTime now = DateTime.Now;

            builder.Entity<InventoryItem>().HasData(
                // Resepsiyon - 4 Bilgisayar
                new InventoryItem { Id = 1, Name = "Masaüstü PC", SerialNumber = "PC-RSP-001", Location = "Resepsiyon", Description = "Intel i5 - 8GB RAM", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 2, Name = "Masaüstü PC", SerialNumber = "PC-RSP-002", Location = "Resepsiyon", Description = "Intel i5 - 8GB RAM", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 3, Name = "Masaüstü PC", SerialNumber = "PC-RSP-003", Location = "Resepsiyon", Description = "Intel i3 - 4GB RAM", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 4, Name = "Masaüstü PC", SerialNumber = "PC-RSP-004", Location = "Resepsiyon", Description = "Intel i7 - 16GB RAM", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },

                // Bar - 1 Bilgisayar
                new InventoryItem { Id = 5, Name = "Bar Terminali", SerialNumber = "PC-BAR-001", Location = "Bar", Description = "All-in-One Dokunmatik", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },

                // Havuzbaşı snackbar - 1 Bilgisayar
                new InventoryItem { Id = 6, Name = "Havuzbaşı PC", SerialNumber = "PC-HAVUZ-001", Location = "Havuzbaşı snackbar", Description = "Mini PC - Fanless", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },

                // Yönetici Ofisleri - 6 Bilgisayar
                new InventoryItem { Id = 7, Name = "Yönetici Laptop", SerialNumber = "PC-OFC-001", Location = "Yönetim Ofisi", Description = "Dell Latitude", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 8, Name = "Yönetici Laptop", SerialNumber = "PC-OFC-002", Location = "Yönetim Ofisi", Description = "Lenovo ThinkPad", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 9, Name = "Yönetici Laptop", SerialNumber = "PC-OFC-003", Location = "Yönetim Ofisi", Description = "HP EliteBook", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 10, Name = "Yönetici Masaüstü", SerialNumber = "PC-OFC-004", Location = "Yönetim Ofisi", Description = "Core i5 - 8GB", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 11, Name = "Yönetici Masaüstü", SerialNumber = "PC-OFC-005", Location = "Yönetim Ofisi", Description = "Core i7 - 16GB", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 12, Name = "Yönetici Masaüstü", SerialNumber = "PC-OFC-006", Location = "Yönetim Ofisi", Description = "Core i3 - 4GB", Category = "Bilgisayar", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },

                // Teknik Oda - 2 Server
                new InventoryItem { Id = 13, Name = "Mail Server", SerialNumber = "SRV-001", Location = "Teknik Sunucu Odası", Description = "Windows Server 2003", Category = "Server", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted },
                new InventoryItem { Id = 14, Name = "Wireless Router Server", SerialNumber = "SRV-002", Location = "Teknik Sunucu Odası", Description = "XP Professional - Domain dışı", Category = "Server", EmployeeId = employeeId, CreatedDate = now, Status = DataStatus.Inserted }
            );
        }
    }
}