using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        MobileStoreEntities _db = new MobileStoreEntities();
        public Cart_ GetCart()
        {
            Cart_ cart = Session["Cart"] as Cart_;
            if (cart == null || Session["Cart"] == null )
            {
                cart = new Cart_();
                Session["Cart"] = cart;

            }
            return cart;
        }
        // GET: ShoppingCart
        // add item vao gio hang
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.Products.SingleOrDefault(s => s.ProductID == id);
            if(pro!=null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        // trang gio hang
        public ActionResult ShowToCart()
        {
            if(Session["Cart"] == null)
            {
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            Cart_ cart = Session["Cart"] as Cart_;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart_ cart = Session["Cart"] as Cart_;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart_ cart = Session["Cart"] as Cart_;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart_ cart = Session["cart"] as Cart_;
            if(cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }

    }
}