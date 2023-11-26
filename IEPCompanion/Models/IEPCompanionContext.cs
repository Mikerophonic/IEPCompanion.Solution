using Microsoft.EntityFrameworkCore;

namespace IEPCompanion.Models;
public class IEPCompanionContext: DbContext
{
  public DbSet<Person> Persons {get; set;}
  public DbSet<IEP> IEPs {get; set;}
  public DbSet<PersonIEP> PersonIEPs {get; set;}

  public IEPCompanionContext(DbContextOptions options) : base(options) {}
}


