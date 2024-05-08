using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
namespace Localization;

public class TestController : Controller
{
    private readonly IStringLocalizer _localizer;
    private readonly IStringLocalizer _localizer2;

    public TestController(IStringLocalizerFactory factory)
    {
        var type = typeof(SharedResource);
        var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
        _localizer = factory.Create(type);
        _localizer2 = factory.Create("SharedResource", assemblyName.Name);
    }       

    public IActionResult About()
    {
        ViewData["Message"] = _localizer["Your application description page."] 
            + " loc 2: " + _localizer2["Your application description page."];

        return View();
    }
}


public class SharedResource
{
}