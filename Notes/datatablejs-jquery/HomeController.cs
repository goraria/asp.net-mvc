// HomeController.cs (ASP.NET MVC)

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public ActionResult GetUsers()
    {
        var users = new[]
        {
            new { Id = 1, Name = "John Doe", Age = 30 },
            new { Id = 2, Name = "Jane Smith", Age = 25 },
            new { Id = 3, Name = "Jim Brown", Age = 40 }
        };
        // return Json(users, JsonRequestBehavior.AllowGet);
    }

    public ActionResult Index()
    {
        return View();
    }
}