namespace IEPCompanion.Models;
public class IEP
{
  public int IEPId { get; set; }
  public int PersonId { get; set; }
  public int SchoolYear { get; set; }
  public List<IEPPerson> JoinEntities {get; set;}
}