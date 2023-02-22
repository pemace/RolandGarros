using Microsoft.EntityFrameworkCore;
using RolandGarros.Data;

var builder = WebApplication.CreateBuilder(args); //https://localhost:7012/
builder.Services.AddControllersWithViews();
var baseAdress = "https://localhost:44346";
builder.Services.AddHttpClient("API", o => { o.BaseAddress = new Uri(baseAdress); });

// Add services to the container. 
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
