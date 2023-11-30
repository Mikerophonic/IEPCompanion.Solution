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


  public IEPsController(IEPCompanionContext db)
  {
    _db = db;
  }

  public async Task<ActionResult> Index()
  {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<IEP> userIEPs = _db.IEPs.
                               Where(entry => entry.User.Id == currentUser.Id)
                               .ToList();
      return View(userIEPs); 
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