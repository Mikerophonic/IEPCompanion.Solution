using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using IEPCompanion.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Claims;



namespace IEPCompanion.Controllers;

public class IEPsController : Controller
{
  private readonly IEPCompanionContext _db;

  private readonly UserManager<ApplicationUser> _userManager;

  public IEPsController(IEPCompanionContext db, UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
    _db = db;
  }

  public async Task<ActionResult> Index()
  {
    string userId = Person.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    ApplicationUser currentUser = await _userManager.FindByIdAsync(PersonId);
    if (currentUser == null)
    {
      return NotFound();
    }
    List<IEP> PersonIEPs = _db.IEPs
      .Where(entry => entry.PersonId == currentPerson.Id)
      .ToList();
    return View(personIEPs);
  }

  //CREATE
  public ActionResult Create()
  {
    return View();
  }

  //READ 

  //UPDATE

  //DELETE
}