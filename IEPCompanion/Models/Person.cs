namespace IEPCompanion.Models
{
  public class Person
  {
    public int PersonId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get ; set; }
    public string Category { get; set; } // Student, Teacher, Parent, Administrator...
    public List<PersonIEP> JoinEntities {get; set;}
  }
}