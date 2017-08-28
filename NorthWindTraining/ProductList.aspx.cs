using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthWindTraining.Models;

namespace NorthWindTraining
{
    public partial class ProductList : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            // LoadProduct();
            //using(NorthwindEntities db = new NorthwindEntities())
            //{
            //    var result = from p in db.Products
            //                 where p.UnitPrice > 30 && p.UnitsInStock > 0
            //                 select p;
            //    GridView1.DataSource = result.ToList();
            //    GridView1.DataBind();               
            //}
            //condition();
            //urungetir();
            //using (NorthwindEntities db = new NorthwindEntities())
            //{
            //    var result = (from p in db.Products
            //                  where p.UnitPrice>30
            //                 select p).OrderByDescending(p=>p.ProductName).OrderByDescending(p=>p.UnitPrice)
            //                 .Take(10);
            //    GridView1.DataSource = result.ToList();
            //    GridView1.DataBind();


            //}
            //son10();
            //ikinci10();
            //O kategerideki Ürün sayısı
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var result = from c in db.Categories
                             select new
                             {
                                 c.CategoryName,
                                 UrunSayisi = c.Products.Count(),
                                 TotalPrice = c.Products.Sum(p=>p.UnitPrice),
                                 MinPrice = c.Products.Min(p => p.UnitPrice),
                                 MaxPrice = c.Products.Max(p => p.UnitPrice),
                                 AveragePrice = c.Products.Average(p => p.UnitPrice),
                             };
                GridView1.DataSource = result.ToList();
                GridView1.DataBind();
            }
            joins();
            //ekle();
            //Priceupdate();
            //CatProupdate();
        }
        private void LoadProduct()
        {
            NorthwindEntities db = new NorthwindEntities();
            var products = from p in db.Products
                           select p;

            GridView1.DataSource = db.Products.ToList();
            GridView1.DataBind();
        }
        private void condition()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var result = from p in db.Products
                             where p.ProductName.StartsWith("a")
                             select p;
                GridView2.DataSource = result.ToList();
                GridView2.DataBind();


            }
        }
        private void urungetir()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var result = from p in db.Products
                             select new
                             {
                                 Ürünismi = p.ProductName,
                                 Fiyat = p.UnitPrice*1.25m,
                                 Miktar =p.UnitsInStock
                             };
                GridView2.DataSource = result.ToList();
                GridView2.DataBind();
            }
        }

        private void son10()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var result = (from p in db.Products
                              select p).OrderByDescending(p => p.ProductID)
                             .Take(10);
                GridView2.DataSource = result.ToList();
                GridView2.DataBind();


            }
        }
        private void ikinci10()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                int count = (from p in db.Products
                             select p).Count();
                var result = (from p in db.Products
                              select p).OrderBy(p => p.ProductID).Skip(count/2+1)
                             .Take(10);
                GridView2.DataSource = result.ToList();
                GridView2.DataBind();


            }
        }
        private void joins()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //var result = from p in db.Products
                //             select new
                //             {
                //                 p.ProductName,
                //                 p.UnitPrice,
                //                 p.Category.CategoryName
                //             };
                //GridView2.DataSource = result.ToList();
                //GridView2.DataBind();
                
                //var result = from c in db.Categories
                //             select new
                //             {
                //                 c.CategoryName,
                //                 c.Products
                //             };
                //RepeaterCategory.DataSource = result.ToList();
                //RepeaterCategory.DataBind();
            }
        }

        private void ekle()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                Category category = new Category();
                category.CategoryName = "Spor";
                category.Description = "Böyle kod olmaz olsun";
                Product product = new Product();
                product.ProductName = "Krampon";
                product.UnitPrice = 100;
 			    product.UnitsInStock=5;
                product.Discontinued = true;

                category.Products.Add(product);
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }
        private void Priceupdate()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                List<Product> proList = (from p in db.Products
                                         where p.CategoryID == 1
                                         select p).ToList<Product>();
                foreach (Product product in proList)
                {
                    product.UnitPrice = product.UnitPrice * 1.5m;
                }
                db.SaveChanges();
            }
        }
        private void CatProupdate()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                Category cat = (from c in db.Categories
                                    where c.CategoryID == 1
                                    select c).FirstOrDefault();

                foreach (Product product in cat.Products)
                {
                    product.UnitPrice = product.UnitPrice * 2m;
                }
                db.SaveChanges();
            }
        }
        

    }
}