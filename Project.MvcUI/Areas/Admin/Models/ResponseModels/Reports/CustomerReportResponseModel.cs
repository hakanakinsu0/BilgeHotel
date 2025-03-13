namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    public class CustomerReportResponseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } // Ad + Soyad
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public int ReservationCount { get; set; } // Bu müşterinin rezervasyon sayısı
    }
}
