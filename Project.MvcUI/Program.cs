using Project.MvcUI.DependencyResolvers;
using Project.Bll.DependencyResolvers;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// **Dependency Resolvers Kullanımı**
builder.Services.AddDbContextService();
builder.Services.AddIdentityService();
builder.Services.AddRepositoryService();
builder.Services.AddMapperServices();
builder.Services.AddManagerService();
builder.Services.AddVmMapperService();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromSeconds(1);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

builder.Services.ConfigureApplicationCookie(x =>
{
    x.AccessDeniedPath = "/Home/SignIn"; //Authorization hatalari icin gidilecek path
    x.LoginPath = "/Home/SignIn"; //Authentication hatalari icin gidilecek path
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
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
