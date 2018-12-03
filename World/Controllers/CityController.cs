using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;

namespace World.Controllers
{
  public class CitiesController : Controller
  {

    [HttpGet("/cities")]
    public ActionResult Index()
    {
     List<City> allCities = City.GetAll();
      return View(allCities);
    }

    // [HttpGet("/items/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }
    //
    // [HttpPost("/items")]
    // public ActionResult Create(string description)
    // {
    //   City myItem = new Item(description);
    //   return RedirectToAction("Index");
    // }
    //
    // [HttpPost("/items/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }
    // [HttpGet("/items/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Item item = Item.Find(id);
    //   return View(item);
    // }
  }
}
