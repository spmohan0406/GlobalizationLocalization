using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(option=> 
{
 var supportedCultures =new[] 
 {
    new CultureInfo("en-US"),
    new CultureInfo("ta"),
    new CultureInfo("ja"),
    new CultureInfo("ru-RU"),
    new CultureInfo("de-DE")
 };
 option.DefaultRequestCulture = new RequestCulture("en-US");
 option.SupportedUICultures = supportedCultures;
});

builder.Services.AddRazorPages().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

var app = builder.Build();

// var supportedCultures = new[] { "en", "fr" };
// var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
