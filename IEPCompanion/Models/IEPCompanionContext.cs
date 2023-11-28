using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEPCompanion.Models;
public class IEPCompanionContext: IdentityDbContext<ApplicationUser>
{
  public DbSet<Student> Students {get; set;}
  public DbSet<Teacher> Teachers {get; set;}
  public DbSet<IEP> IEPs {get; set;}
  public DbSet<PersonIEP> StudentIEPs {get; set;}

  public IEPCompanionContext(DbContextOptions options) : base(options) {}
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Student>().HasData(
      new Person{PersonId=1, FirstName = "Harold", LastName="Gold", Category="Administrator"},
      new Person{PersonId=2, FirstName = "Mary", LastName="Berry", Category="Teacher"},
      new Person{PersonId=3, FirstName = "Aaron", LastName="Holland", Category="Student"},
      new Person{PersonId=4, FirstName = "Mary", LastName="Holland", Category="Parent"}
    );
  }
}
