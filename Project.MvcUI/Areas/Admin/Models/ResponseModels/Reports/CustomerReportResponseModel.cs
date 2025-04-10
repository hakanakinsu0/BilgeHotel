namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Müşteri raporlarında her bir müşteriye ait bilgileri temsil eden modeldir.
    /// Ad-soyad, e-posta, kimlik numarası ve yaptığı rezervasyon sayısı gibi detayları içerir.
    /// </summary>
    public class CustomerReportResponseModel
    {
        public int Id { get; set; } // Müşteri ID'si
        public string FullName { get; set; } // Ad Soyad bilgisi
        public string Email { get; set; } // E-posta adresi
        public string IdentityNumber { get; set; } // TC Kimlik No veya Pasaport No
        public int ReservationCount { get; set; } // Toplam rezervasyon sayısı
    }
}
