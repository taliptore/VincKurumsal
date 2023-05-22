using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using KurumsalWebVinc.AutofacModules;
using KurumsalWebVinc.Models;
using KurumsalWebVinc.Services.Mapping;
using KurumsalWebVinc.Services.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews().AddFluentValidation(x =>
//{
//     x.RegisterValidatorsFromAssemblyContaining<TalepFormuValidator>();
//    //x.RegisterValidatorsFromAssemblyContaining<RegisterModelDtoValidator>();
//});


builder.Services.AddAutoMapper(typeof(MapProfile));//typeof: tip türü çaðýrda bu þekilde yapýnca dosyý gidip kendi bulup yüklüyor

builder.Services.AddDbContext<AppDbContext>(x =>
{ // veri tabaný eriþimi
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        // burasý magration yapýlacak projenin yerini bildiriyoruz NLayer.Repository al diyoruz type bazlý girildiki proje adý deðiþsede çalýþþsýn
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
        // bu kod þunu yapýyor AppDbContext bulunduðu projenin nameini alýyor
    });


});
//seri log ayarlandý
//log seviyeleri https://www.gencayyildiz.com/blog/asp-net-core-signalr-serisi-4-signalr-log-seviyeleri/
builder.Host.UseSerilog((hostContext, services, configuration) => {
    configuration
    .MinimumLevel.Error()// loglama seviyesi warning üstünü tutar
        .WriteTo.File("wwwroot/logs/serilog-file.json",rollingInterval:RollingInterval.Day)
		.WriteTo.Console();
});


builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    //user ayarlarý
    opt.User.RequireUniqueEmail = true;
    opt.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöpqrsþtuüvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";

    //password ayarlarý
    opt.Password.RequiredLength = 6;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddErrorDescriber<TurkishErrorMessage>().AddDefaultTokenProviders();

//Cookie Ayarlarý
CookieBuilder cookieBuilder = new CookieBuilder();
cookieBuilder.Name = "KurumsalWeb";
cookieBuilder.HttpOnly = false;
cookieBuilder.SameSite = SameSiteMode.Lax;
cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = new PathString("/Admin/Login");//kullanýcý üye deðilse ya da yetkisi yoksa bu sayfaya gidecek
    options.LogoutPath = new PathString("/Admin/LogOut");
    options.Cookie = cookieBuilder;
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(60);
    options.AccessDeniedPath = new PathString("/Member/AccessDenied");
});
//builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//burada modülleri tanýmladýðýmýzý baðý kuruyoruz
builder.Host.ConfigureContainer<ContainerBuilder>
        (containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

 
 
//html yapýlan düzelme refres yapýnca yansýr
//Nuget package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// Add services to the container.

//builder.Services.addf<TalepFormuValidator>(); // register validators
builder.Services.AddValidatorsFromAssembly(typeof(TalepFormuDtoValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(AracBilgisiValidator).Assembly);
//builder.Services.AddValidatorsFromAssemblyContaining<TalepFormuDtoValidator>();
builder.Services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddControllersWithViews();



 

 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseExceptionHandler("/Home/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseDeveloperExceptionPage();
//app.UseStatusCodePages(); //404 sayfasý yapadýysan burada otomatik hatayý yazar
//app.UseStatusCodePagesWithRedirects("~/ErrorPage/Error404"); // özelleþmiþ eror sayfasý
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?statusCode={0}"); // status kodlusu
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedAdminData.Initialize(app.Services); // sistem açýlýnca birkez çalýþsa yeterli
 
 
app.Run();
