using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;

namespace World.Controllers
{
  public class CountriesController : Controller
  {

    [HttpGet("/countries")]
    public ActionResult Index()
    {
     List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }
    [HttpPost("/countries/info")]
    public ActionResult Create(string name)
    {
     List<Country> allCountriesInfo = Country.GetCountryInfo(name);
      return View("Show" , allCountriesInfo);
    }
  }
}
