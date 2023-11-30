using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IEPCompanion.Models
{
  public class IEPCompanionContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Person> Persons { get; set; }
    public DbSet<IEP> IEPs { get; set; }
    public DbSet<IEPPerson> IEPPerson { get; set; }

    public IEPCompanionContext(DbContextOptions<IEPCompanionContext> options) : base(options) { }


  }
}
