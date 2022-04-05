using Microsoft.AspNetCore.Mvc;
using ReadDatabase.Models;
using System.Diagnostics;

namespace ReadDatabase.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var rows = DatabaseConnector.GetRows("select * from product");

      List<string> names = new List<string>();

      foreach (var row in rows)
      {
        names.Add(row["naam"].ToString());
      }

      return View(names);
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
}