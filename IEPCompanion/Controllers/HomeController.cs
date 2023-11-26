using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using IEPCompanion.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace IEPCompanion.Controllers;

public class HomeController: Controller
{
  [HttpGet("/")]
  public ActionResult Index()
  {
    return View();
  }
}