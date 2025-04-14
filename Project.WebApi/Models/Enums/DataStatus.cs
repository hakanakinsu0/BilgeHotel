namespace Project.WebApi.Models.Enums
{
    /// <summary>
    /// Verinin yaşam döngüsündeki durumunu belirten enum yapısıdır.
    /// Bu yapı sayesinde verilerin eklendiği, güncellendiği veya silindiği durumlar izlenebilir.
    /// </summary>
    public enum DataStatus
    {
        Inserted = 1, // Veri ilk kez oluşturulduğunda atanır (Default)
        Updated = 2,  // Veri güncellendiğinde atanır
        Deleted = 3   // Veri silindiğinde atanır (Soft delete - fiziksel silinme değil)
    }
}
