using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_Panda.Models;
using Website_Panda.Models.DAL;
using System.Data.Entity;

namespace Website_Panda.Controllers
{
    public class HomeController : Controller
    {
        DB_Optical db = new DB_Optical();
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Menu()
        {
            var cate = db.Categories;
            var brand = db.Brands;
            ViewBag.cate = cate;
            ViewBag.brand = brand;
            return View();
        }
        public ActionResult CategoryList()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult BrandList()
        {
            return View(db.Brands.ToList());
        }
        public ActionResult Product(long? id)
        {
            var result = from r in db.Products
                         where r.CategoryID == id
                         select r;
            return PartialView("Product", result);
        }
        public ActionResult AllProduct(int? page, string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var result = db.Products.Where(s => s.ProductName.Contains(search));
                return View(result.ToList().ToPagedList(page ?? 1, 9));
            }
            return View(db.Products.ToList().ToPagedList(page ?? 1, 9));
            //return PartialView("AllProduct", db.Products.ToList().ToPagedList(page ?? 1, 9));
        }

        public ActionResult ProductList(long? id, int? page)
        {
            var result = from r in db.Products
                         where r.CategoryID == id
                         select r;
            return PartialView("ProductList", result.ToList().ToPagedList(page ?? 1, 9));
        }
        public ActionResult ProductBrandList(long? id, int? page)
        {
            var result = from r in db.Products
                         where r.BrandID == id
                         select r;
            return PartialView("ProductBrandList", result.ToList().ToPagedList(page ?? 1, 9));
        }
        public ActionResult MoreProduct(long? id)
        {
            var result = from r in db.Products
                         where r.CategoryID == id
                         select r;
            return PartialView("MoreProduct", result);
        }

        public ActionResult ProductDetail(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var pro = db.Products.SingleOrDefault(s => s.IDProduct == id);
            //if (pro != null)
            //{
            //    GetViewHistory().Add(pro);
            //}
            return View(product);
        }
        //public ActionResult ProductViewed() //ShowToGetViewHistoryt()
        //{
        //    ViewHistory vh = Session["ViewHistory"] as ViewHistory;
        //    return View(vh);
        //}
        public ActionResult Banner()
        {
            return View(db.Banners.ToList());
        }
        //public ActionResult BannerPage()
        //{
        //    return View(db.Banners.ToList());
        //}
        public ActionResult NewProduct()
        {
            return View(db.Products.OrderBy(m => m.CreatedDate).Take(4).ToList());
        }
        public ActionResult HotProduct()
        {
            return View(db.Products.OrderBy(m => m.Quantity).Take(10).ToList());
        }
        public ActionResult Search()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Search(string search, int? page)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var result = db.Products.Where(s => s.ProductName.Contains(search));
                return View(result.ToList().ToPagedList(page ?? 1, 9));
            }
            return View(db.Products.ToList().ToPagedList(page ?? 1, 9));
        }
    }
}