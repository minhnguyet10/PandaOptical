using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Panda.Models;
using Website_Panda.Models.DAL;
using Website_Panda.Models.QueryModel;

namespace Website_Panda.Controllers
{
    public class ShoppingCartController : Controller
    {
        DB_Optical db = new DB_Optical();
        // GET: ShoppingCart
        public CartSession GetCart()
        {
            CartSession cart = Session["CartSession"] as CartSession;
            if (cart == null || Session["CartSession"] == null)
            {
                cart = new CartSession();
                Session["CartSession"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(long id)
        {
            var pro = db.Products.SingleOrDefault(s => s.IDProduct == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart", new { r = Request.Url.ToString() });
        }
        public ActionResult ShowToCart()
        {
            if (Session["CartSession"] == null)
            {
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            CartSession cart = Session["CartSession"] as CartSession;
            return View(cart);
        }
        //public ActionResult CartShow()
        //{
        //    CartSession cart = Session["CartSession"] as CartSession;
        //    return View(cart);
        //}

        //public ActionResult CartShowMenu()
        //{
        //    CartSession cart = Session["CartSession"] as CartSession;
        //    return View(cart);
        //}
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            CartSession cart = Session["CartSession"] as CartSession;
            int id_pro = int.Parse(form["ID_Product"]);

            Product _pro = db.Products.Find(id_pro);

            int quantity = int.Parse(form["Quantity"]);
            if (quantity > _pro.Quantity)
            {
                return RedirectToAction("Err", "ShoppingCart");
            }
            else
            {
                cart.Update_Quantity_Shopping(id_pro, quantity);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            CartSession cart = Session["CartSession"] as CartSession;
            cart.Remove_Cart_Item(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            CartSession cart = Session["CartSession"] as CartSession;
            if (cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }
        public ActionResult Shopping_Success()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
         {
            var session = (Website_Panda.Models.Login.UserLogin)Session[Website_Panda.Models.Login.Common.USER_SESSION];
            if (session == null)
            {
                return View();
            }
            else 
            { 
                    CartSession cart = Session["CartSession"] as CartSession;
                    Order _order = new Order();
                    _order.OrderDate = DateTime.Now;
                    _order.IdCus = session.UserID;
                    db.Order.Add(_order);
                    foreach (var item in cart.Items)
                    {
                        OrderDetail _order_Detail = new OrderDetail();
                        _order_Detail.IDOrder = _order.IDOrder;
                        _order_Detail.IDProduct = item._shopping_product.IDProduct;
                        _order_Detail.Price = item._shopping_product.Price;
                        _order_Detail.QuantitySale = item._shopping_quantity;
                        db.OrderDetails.Add(_order_Detail);
                    }
                    db.SaveChanges();
                    cart.ClearCart();
                    return RedirectToAction("Shopping_Success", "ShoppingCart");
                    //CartSession cart = Session["Cart"] as CartSession;
                    //var result = from r in db.Customers
                    //             where r.IdCus == session.UserID
                    //             select r;
                    //var cus2 = result.ToList().First();
                    //Order _order = new Order();
                    //_order.OrderDate = DateTime.Now;
                    //_order.Email_Cus = cus2.Email_Cus;
                    //_order.SDT_Cus = cus2.Phone_Cus;
                    //_order.Password_cus = cus2.Password;
                    //_order.Descriptions = cus2.Address_Cus;
                    //_order.CodeCus = cus2.CodeCus;
                    //_order.Deleted = false;
                    //_order.Cancelled = false;
                    //_order.Paid = false;
                    //_order.Status = false;
                    //db.Orders.Add(_order);
                
               
            }
        }
    }
}