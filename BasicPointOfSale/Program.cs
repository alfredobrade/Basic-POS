using BasicPointOfSale.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//services add session
builder.Services.AddSession(options =>
{
    // Configurar las opciones de sesi�n seg�n tus necesidades
    options.IdleTimeout = TimeSpan.FromDays(1);
});

builder.Services.AddControllersWithViews();

builder.Services.DependencyInyection(builder.Configuration); //para inyectar las dependencias desde otra clase
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Access/Index";
        option.ExpireTimeSpan = TimeSpan.FromDays(1);
        option.AccessDeniedPath = "/Home/Privacy";

    });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//use session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Index}/{id?}");

app.Run();
