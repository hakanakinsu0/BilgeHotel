using Project.Bll.DependencyResolvers;
using Project.MvcUI.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// **Dependency Resolvers Kullanımı**
builder.Services.AddDbContextService();
builder.Services.AddIdentityService();
builder.Services.AddRepositoryService();
builder.Services.AddMapperServices();
builder.Services.AddManagerService();

builder.Services.AddVmMapperService(); // AutoMapper'ı MvcUI için ekliyoruz

// **Session Yapılandırması (5 Dakika)**
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5); // Oturum süresi 5 dakika
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

// **Kimlik Doğrulama ve Yetkilendirme**
builder.Services.ConfigureApplicationCookie(x =>
{
    x.AccessDeniedPath = "/Home/SignIn";
    x.LoginPath = "/Home/SignIn";
});

WebApplication app = builder.Build();

// **Hata Yönetimi (Sadece Yönlendirme)**
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
