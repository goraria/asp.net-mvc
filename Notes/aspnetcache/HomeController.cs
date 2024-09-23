// HomeController.cs (ASP.NET MVC Cache)

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public ActionResult GetCachedData()
    {
        // var cache = HttpRuntime.Cache["myData"] as List<object>;

        if (cache == null)
        {
            cache = new List<object>
            {
                new { Id = 1, Name = "John Doe", Age = 30 },
                new { Id = 2, Name = "Jane Smith", Age = 25 },
                new { Id = 3, Name = "Jim Brown", Age = 40 }
            };

            // HttpRuntime.Cache.Insert("myData", cache, null, DateTime.Now.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        // return Json(cache, JsonRequestBehavior.AllowGet);
    }
}
