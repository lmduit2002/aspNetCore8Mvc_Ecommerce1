
using aspNetCore8Mvc_Ecommerce1.Data;
using aspNetCore8Mvc_Ecommerce1.Impls;
using aspNetCore8Mvc_Ecommerce1.Intfs;
using aspNetCore8Mvc_Ecommerce1.Models.Services.HangHoa;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
//Scaffold-DbContext "Data Source=DESKTOP-L4BLRQD\SQLEXPRESS;Database=Hshop2023;User Id=user1;Password=123456;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -f
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// define db context
builder.Services.AddDbContext<Hshop2023Context>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddTransient<HangHoaServicesInject>();

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

// ADD SCOPE
builder.Services.AddScoped<IHangHoaAppService, HangHoaAppService>();
builder.Services.AddScoped<ICartAppService, CartAppService>();


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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
