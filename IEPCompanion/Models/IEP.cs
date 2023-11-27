namespace IEPCompanion.Models;
public class IEP
{
  public int IEPId { get; set; }
  public int PersonId { get; set; } //ToDo: filter to persons of category "student"
  public int SchoolYear { get; set; }
  public List<PersonIEP> JoinEntities { get; set; }
}