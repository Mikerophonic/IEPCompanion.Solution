namespace IEPCompanion.Models;
public class IEP
{
  public int IEPId { get; set; }
  public int SchoolYear { get; set; }
  public List<IEPStudent> JoinEntities {get; set;}
  public List<IEPTeacher> JoinEntities {get; set;}
}