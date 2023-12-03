using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IEPCompanion.Models;
public class IEP
{
  public int IEPId { get; set; }
  public int PersonId { get; set; }
  public int SchoolYear { get; set; }
  public List<IEPPerson> JoinEntities { get; set; }
  public string Disability { get; set; }
  public string Goals { get; set; }
  public ApplicationUser User { get; set; }

}