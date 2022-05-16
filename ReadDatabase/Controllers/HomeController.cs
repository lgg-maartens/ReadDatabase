using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ReadDatabase.Database;
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
      // alle producten ophalen
      var rows = DatabaseConnector.GetRows("select * from product");

      // lijst maken om alle namen in te stoppen
      List<string> names = new List<string>();

      foreach (var row in rows)
      {
        // elke naam toevoegen aan de lijst met namen
        names.Add(row["naam"].ToString());
      }

      // de lijst met namen in de html stoppen
      return View(names);
    }

    private void SavePerson(Person person)
    {
      MySqlCommand cmd = new MySqlCommand("INSERT INTO klant(voornaam, achternaam, email, bericht) VALUES(?voornaam, ?achternaam, ?email, ?bericht)", conn);

      cmd.Parameters.Add("?voornaam", MySqlDbType.Text).Value = person.FirstName;
      cmd.Parameters.Add("?achternaam", MySqlDbType.Text).Value = person.LastName;
      cmd.Parameters.Add("?email", MySqlDbType.Text).Value = person.Email;
      cmd.Parameters.Add("?bericht", MySqlDbType.Text).Value = person.Description;
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