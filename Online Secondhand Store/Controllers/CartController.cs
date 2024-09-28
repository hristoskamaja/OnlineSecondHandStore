using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Online_Secondhand_Store.Models;

public class CartController : Controller
{
    public ActionResult Index()
    {
        var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
        return View(cart);
    }

    public ActionResult AddToCart(int id, string category, string name, decimal price, string imageUrl)
    {

        var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

        var existingItem = cart.FirstOrDefault(c => c.ItemId == id && c.Category == category);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cart.Add(new CartItem
            {
                ItemId = id,
                Category = category,
                Name = name,
                Price = price,
                ImageUrl = imageUrl
            });
        }

        Session["Cart"] = cart;

        switch (category.ToLower())
        {
            case "cars":
                return RedirectToAction("Index", "Cars");
            case "clothings":
                return RedirectToAction("Index", "Clothings");
            case "furnitures":
                return RedirectToAction("Index", "Furnitures");
            case "computeranditequipments":
                return RedirectToAction("Index", "ComputerAndITEquipments");
            case "electricalappliances":
                return RedirectToAction("Index", "ElectricalAppliances");
            default:
                return RedirectToAction("Index", "Home");
        }
    }





    public ActionResult ClearCart()
    {
        Session["Cart"] = null;
        return RedirectToAction("Index");
    }


    public ActionResult RemoveFromCart(int id, string category)
    {
        var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

        var itemToRemove = cart.FirstOrDefault(c => c.ItemId == id && c.Category == category);
        if (itemToRemove != null)
        {
            cart.Remove(itemToRemove);
        }

        Session["Cart"] = cart;
        return RedirectToAction("Index");
    }

}
