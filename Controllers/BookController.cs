using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Localization.Controllers;

public class BookController : Controller
{
    private readonly IHtmlLocalizer<BookController> _localizer;

    public BookController(IHtmlLocalizer<BookController> localizer)
    {
        _localizer = localizer;
    }

    public IActionResult Hello(string name)
    {
        ViewData["Message"] = _localizer["<b>Hello</b><i> {0}</i>", name];

        return View();
    }
}