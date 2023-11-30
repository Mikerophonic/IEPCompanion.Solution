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
    // string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    // ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    // if (currentUser == null)
    // {
    //   return NotFound();
    // }
    // List<IEP> personIEPs = await _db.IEPs
    //   .Where(entry => entry.PersonId == currentUser.Id)
    //   .ToListAsync();
    return View();
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