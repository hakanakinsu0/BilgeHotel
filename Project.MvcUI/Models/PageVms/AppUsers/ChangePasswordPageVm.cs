namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Şifre değiştirme işlemi için kullanılan PageVM.
    /// Gerekli form modelini, sayfa başlığını, yardım metnini ve işlem sonucu mesajlarını içerir.
    /// </summary>
    public class ChangePasswordPageVm
    {
        /// <summary>
        /// Sayfa başlığı ve yardım metni ile birlikte varsayılan değerler atanır.
        /// </summary>
        public ChangePasswordPageVm()
        {
            PageTitle = "Şifre Değiştir";
            HelpText = "Yeni şifrenizi giriniz.";
        }

        /// <summary>
        /// Şifre değiştirme işlemi için gerekli olan form verilerini içeren request model.
        /// </summary>
        public UserChangePasswordRequestModel ChangePasswordRequest { get; set; }

        /// <summary>
        /// Sayfanın başlığı. View'da başlık olarak kullanılır.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Kullanıcıya gösterilecek yardım metni.
        /// </summary>
        public string? HelpText { get; set; }

        /// <summary>
        /// Eğer işlem sırasında bir hata oluşursa, bu alanda mesaj View'a iletilir.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// İşlem başarıyla tamamlanırsa, bu alanda View'a gösterilecek başarı mesajı yer alır.
        /// </summary>
        public string? SuccessMessage { get; set; }
    }
}
