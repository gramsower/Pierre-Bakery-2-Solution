namespace Bakery.Models
{
  public class FlavorItem
  {
    public int FlavorItemId { get; set; }
    public int FlavorId { get; set; }
    public int ItemId { get; set; }
    public Flavor Flavor { get; set; }
    public Item Item { get; set; }
    public ApplicationUser User { get; set; }
  }
}