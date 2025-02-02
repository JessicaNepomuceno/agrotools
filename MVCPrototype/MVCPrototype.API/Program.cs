using Microsoft.AspNetCore.Localization;
using MVCPrototype.Application.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add localization support in resources
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Default and supported culture configuration
var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("pt-BR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/View/Error");
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
