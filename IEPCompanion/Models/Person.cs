using System.ComponentModel.DataAnnotations;

namespace IEPCompanion.Models
{
  public class Person
  {
    public int PersonId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public List<IEPPerson> JoinEntities { get; set; }
  }
}