using Project.Dal.ContextClasses;
using Project.Entities.Models;
using Project.Bll.DependencyResolvers;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// **Dependency Resolvers Kullanýmý**
builder.Services.AddDbContextService();
builder.Services.AddIdentityService();
builder.Services.AddRepositoryService();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
