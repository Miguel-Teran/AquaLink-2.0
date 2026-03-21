using AquaLink2._0.Services;
using AquaLink2._0.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AutenService>();
builder.Services.AddScoped<ReporteService>();
builder.Services.AddScoped<ComentarioService>();
builder.Services.AddScoped<EviService>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
