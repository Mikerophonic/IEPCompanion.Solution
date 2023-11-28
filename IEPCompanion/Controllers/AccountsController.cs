using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IEPCompanion.Models;
using System.Threading.Tasks;
using IEPCompanion.ViewModels;

namespace IEPCompanion.Controllers;

public class AccountsController:Controller
{
  private readonly IEPCompanionContext _db;
  private readonly UserManager<ApplicationUser> _usrmgr;
  private readonly SignInManager<ApplicationUser> _signInMgr;

  public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEPCompanionContext db)
  {
    _usrmgr = userManager;
    _signInManager = signInManager;
    _db=db;
  }

  public ActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Register(RegisterViewModel model)
  {
    if(!ModelState.IsValid)
    {
      return View(model);
    }
    else
    {
      ApplicationUser user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if(result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        foreach (IdentityError err in result.Errors)
        {
          ModelState.AddModelError("", err.Description);
        }
        return View(model);
      }
    }
  }
  
  [HttpPost]
  public async Task<ActionResult> Login(LoginViewModel model)
  {
    if(!ModelState.IsValid)
    {
      return View(model);
    }
    else
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if(result.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
        return View(model);
      }
    }
  }

  [HttpPost]
  public async Task<ActionResult> LogOff()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }


}