using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using IEPCompanion.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace IEPCompanion.Controllers
{
  public class HomeController : Controller
  {

    private readonly IEPCompanionContext _db;
    public HomeController(IEPCompanionContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      var model = new Dictionary<string, List<object>>
      {
        {"ieps", _db.IEPs.Cast<object>().ToList()},
        {"people", _db.Persons.Cast<object>().ToList()}
      };
      return View(model);
    }
  }
}