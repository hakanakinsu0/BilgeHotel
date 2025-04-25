# 🏨 **Otel Yönetim Sistemi**

## 📖 **Proje Tanıtımı**
**Bilge Hotel Management System**, **ASP.NET Core 8.0 MVC** ve **Entity Framework Core 8.0** kullanılarak geliştirilmiş tam kapsamlı bir **otel otomasyon** projesidir.  
Proje boyunca **Clean Architecture** prensipleri, **Hybrid N-Tier Architecture** ve **SOLID** prensipleri doğrultusunda:
- **Entities**, **DAL**, **BLL**, **Configuration**, **Common**, **MvcUI** ve **WebApi** katmanları ayrıştırılmıştır.
- **Dependency Injection**, **Repository Pattern** ve **Unit of Work** yapıları ile kod tekrarı önlenmiş, test edilebilirlik ve sürdürülebilirlik sağlanmıştır.
- **AutoMapper** ile entity–DTO dönüşümleri kolaylaştırılmıştır.
- **ASP.NET Identity** altyapısı kullanılarak güvenli kullanıcı yönetimi ve rol bazlı yetkilendirme yapılmıştır.

---

## 🚀 **Kullanılan Teknolojiler & Paketler**

### Backend
- **.NET 8 & ASP.NET Core MVC 8**  
- **Entity Framework Core 8**  
  - Code First Migration  
  - Lazy Loading Proxies  
  - Fluent API konfigürasyonları  
- **ASP.NET Core Identity**  
  - Özelleştirilmiş `AppUser` ve `AppUserProfile`  
  - E-posta doğrulama ve şifre sıfırlama  
- **AutoMapper**  
- **Swashbuckle (Swagger)**  
- **HttpClient Factory**  
- **Bogus** (Geliştirme & Test için sahte veri üretimi)

### Database
- **Microsoft SQL Server**  
- **Migrations** ve **Seed Data**  

### Frontend
- **Razor Views & Razor Pages**  
- **Tag Helpers** ve **View Components**  
- **Data Annotations** ile Model Validation  
- **Bootstrap 5** ile responsive tasarım  

### Common
- **MailService** (`System.Net.Mail`)  
- **DatabaseBackupHelper** (SQL `.bak` yedekleme)  
- **Session Management** (Distributed Memory Cache)  

---

## 🗂️ **Katmanlar & İçerikleri**

### 1. Entities
- Model sınıfları (`Reservation`, `Room`, `Employee`, `Package`, vb.)  
- Enum tanımları (`DataStatus`, `ReservationStatus`, `RoomStatus`, vb.)  

### 2. Project.Configuration
- **Fluent API** tabanlı entity konfigürasyonları  
  - `HasColumnType("money")`  
  - `HasOne/WithMany` ilişkileri  

### 3. Project.Common
- Yardımcı araç sınıfları:  
  - `MailService`  
  - `DatabaseBackupHelper`

### 4. Project.Dal
- **DbContext**: `MyContext` (Identity + Entity konfigürasyonlar)  
- Repository pattern implementasyonları  
- **Seed Data**: `Bogus` tabanlı `RoomSeed`, `EmployeeSeed`, vb.

### 5. Project.Bll
- Manager sınıfları (`IReservationManager`, `IEmployeeManager`, vb.)  
- DTO sınıfları (`ReservationDto`, `RoomDto`, vb.)  
- **MappingProfile** ile AutoMapper konfigürasyonu  

### 6. Project.MvcUI
- MVC **Controllers**, **Views**, **ViewModels**, **Helpers**  
- Kimlik Doğrulama & Yetkilendirme  
- Rezervasyon, Ödeme, Profil, Dashboard işlemleri  

### 7. Project.WebApi
- **Fake Banka API**: Ödeme başlatma, iptal, geçmiş  
- Swagger UI  

---

## 🎯 **Ana Fonksiyonlar & Özellikler**

1. **Kullanıcı Yönetimi**  
   - Kayıt, Giriş, Çıkış  
   - E-posta aktivasyonu (ActivationCode)  
   - Şifre sıfırlama linki (Token)  
   - Rol bazlı yetkilendirme (`Admin`, `Member`)

2. **Oda & Rezervasyon**  
   - Oda durum takibi (Boş, Dolu, Bakım)  
   - Rezervasyon oluşturma, iptal, güncelleme  
   - Tarihe, odaya, tipe, fiyata göre filtreleme  
   - Paket (Tam Pansiyon, Herşey Dahil) ve ekstra hizmet seçimi  

3. **Ödeme Süreci**  
   - **Fake Banka API** üzerinden ödeme başlatma ve iptal  
   - Rezervasyon onaylama ve ödeme kaydı  
   - Ödeme geçmişi sorgulama  

4. **Personel & Envanter**  
   - Çalışan CRUD işlemleri  
   - Vardiya yönetimi (Sabah, Akşam, Gece)  
   - Envanter takibi (Bilgisayar, Server, vb.)

5. **Yedekleme & Loglama**  
   - Veritabanı yedekleme (SQL `.bak`)  
   - Kullanıcı bazlı yedekleme logları  

6. **Genel**  
   - Soft delete (Logical delete)  
   - Audit alanları (`CreatedDate`, `ModifiedDate`, `DeletedDate`)  
   - Swagger ve SwaggerUI ile API dokümantasyonu  
   - Responsive UI (Bootstrap)

---

## 🛠️ **Kurulum & Çalıştırma**

1. **Repoyu klonla**
   ```bash
   git clone https://github.com/hakanakinsu0/BilgeHotel.git
   cd BilgeHotel
   ```
2. **Bağlantı dizesi**  
   `appsettings.json` içinde `ConnectionStrings:MyConnection` değerini güncelle.
3. **NuGet paketlerini** yükle.
4. **EF Core Migration** (isteğe bağlı)  
   ```bash
   dotnet ef database update --project Project.Dal
   ```
5. **Fake Banka API**  
   - Başlangıç projesi: **Project.WebApi**  
   - `https://localhost:5190`  
6. **MVC Uygulaması**  
   - Başlangıç projesi: **Project.MvcUI**  
   - `https://localhost:5114`  

> **Admin** kullanıcı:  
> - Kullanıcı Adı: `bilgehotel`
> - Email: `bilgehotel@email.com`
> - Şifre: `bilgehotel`

---

## 🤝 **Yazılım Geliştirici**

[Hakan Akınsu - Computer Engineer](https://github.com/hakanakinsu0)

---
