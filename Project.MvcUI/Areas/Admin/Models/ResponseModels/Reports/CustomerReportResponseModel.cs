namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Müşteri raporlarında kullanılacak müşteri detay modelidir.
    /// Her bir müşteri için ad-soyad, e-posta, kimlik numarası ve rezervasyon sayısı bilgilerini içerir.
    /// </summary>
    public class CustomerReportResponseModel
    {
        public int Id { get; set; }                 // Müşterinin benzersiz kimlik numarası

        public string FullName { get; set; }        // Müşterinin tam adı (ad + soyad)

        public string Email { get; set; }           // Müşterinin e-posta adresi

        public string IdentityNumber { get; set; }  // Müşterinin kimlik numarası

        public int ReservationCount { get; set; }   // Müşterinin yaptığı rezervasyon sayısı
    }
}
