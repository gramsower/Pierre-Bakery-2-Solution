using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public List<FlavorItem> JoinEntities { get; set; }
    public ApplicationUser User { get; set; }
  }
}