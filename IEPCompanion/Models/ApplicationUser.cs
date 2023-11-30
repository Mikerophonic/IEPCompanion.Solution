using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IEPCompanion.Models
{
public class ApplicationUser : IdentityUser
{
  public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}
}