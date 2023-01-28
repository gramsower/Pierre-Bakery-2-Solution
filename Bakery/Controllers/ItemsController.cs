using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
  [Authorize]
  public class TagsController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ItemsController(UserManager<ApplicationUser> userManager, BakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Items> userItems = _db.Items
                              .Where(entry => entry.User.Id == currentUser.Id)
                              .ToList();
      return View(userItems);
    }

    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items  
                        .Include(item => item.JoinEntities)
                        .ThenInclude(join => join.Flavor)
                        .FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Item item)
    {
      if (!ModelState.IsValid)
      {
        return View(item);
      }
      else 
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        item.User = currentUser;
        _db.Items.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult AddItem(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => items.ItemId == id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Item");
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult AddItem(Item item, int itemId)
    {
      #nullable enable
      FlavorItem? joinEntity = _db.FlavorItems.FirstOrDefault(join => (join.FlavorId == flavorId && join.ItemId == item.ItemId));
      #nullable disable
      if (joinEntity == null && flavorId != 0)
      {
        _db.FlavorItems.Add(new FlavorItem() { FlavorId = flavorId, ItemId = item.ItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = item.ItemId });
    }

    public ActionResult Edit(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item)
    {
      _db.Items.Update(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorItem joinEntry = _db.FlavorItems.FirstOrDefault(entry => entry.FlavorItemId == joinId);
      _db.FlavorItems.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}