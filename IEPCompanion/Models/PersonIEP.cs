namespace IEPCompanion.Models;

public class PersonIEP
{
  public int PersonId {get; set;}
  
  public int IEPId {get; set;}

  public int PersonIEPId {get; set;}
  
  public Person person {get; set;}

  public IEP Iep {get; set;}

}