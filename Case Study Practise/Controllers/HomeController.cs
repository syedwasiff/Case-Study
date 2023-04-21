using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case_Study_Practise.Controllers
{
    public class HomeController : Controller
    {
        PractiseCaseStudyContext context = new PractiseCaseStudyContext();
        public ActionResult Index()
        {
            var listofData = context.Products.ToList();
            return View(listofData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                if (product.ID == 0){
                    Product _products = new Product();
                    _products.Product_Title = product.Product_Title;
                    _products.Price = Convert.ToInt32(product.Price);
                    _products.Stock = Convert.ToInt32(product.Stock);
                    _products.Image = product.Image;                    
                    context.Products.Add(_products);
                    context.SaveChanges();                    
                }
                else if(product.ID != 0)
                {
                    Product _products = new Product();
                    var data = context.Products.Where(x => x.ID == product.ID).FirstOrDefault();
                    data.Product_Title = product.Product_Title;
                    data.Price = Convert.ToInt32(product.Price);
                    data.Stock = Convert.ToInt32(product.Stock);
                    data.Image = product.Image;                    
                    context.SaveChanges();
                }
                return Json(product);
            }
            catch (Exception ex)
            {
                throw;
            }
        } 

        [HttpGet]
        public ActionResult GetAllProd()
        {
            try
            {
                var allProd = context.Products.ToList();
                return Json(allProd, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product obj)
        {
            try
            {
                var DeletedProd = context.Products.Remove(context.Products.Where(x => x.ID == obj.ID).FirstOrDefault());
                context.SaveChanges();
                return Json(DeletedProd, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}