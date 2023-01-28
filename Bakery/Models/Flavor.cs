using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string FlavorName { get; set; }
    public List<FlavorItem> JoinEntities { get;}
    public ApplicationUser User { get; set; }
  }
}