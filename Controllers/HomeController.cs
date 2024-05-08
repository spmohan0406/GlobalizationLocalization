using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BreadCrumbs.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;

namespace BreadCrumbs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger,IStringLocalizer<HomeController> _localizer)
    {
        this._logger = logger;
        this._localizer=_localizer;
    }

    public IActionResult Index()
    {
        var localizedTitle = _localizer["Welcome"];
        return View();
    }

    [HttpPost]
    public IActionResult CultureManagement(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
        new CookieOptions {Expires=DateTimeOffset.Now.AddDays(30)});
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
