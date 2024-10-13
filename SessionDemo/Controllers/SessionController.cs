using Microsoft.AspNetCore.Mvc;

public class SessionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SetSession(string value)
    {
        HttpContext.Session.SetString("SessionKey", value);
        return RedirectToAction("Index");
    }

    public IActionResult GetSession()
    {
        var value = HttpContext.Session.GetString("SessionKey");
        ViewBag.SessionValue = value ?? "Session is empty";
        return View("Index");
    }
}
