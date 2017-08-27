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
            using(NorthwindEntities db = new NorthwindEntities())
            {
                var result = from p in db.Products
                             where p.UnitPrice > 30 && p.UnitsInStock > 0
                             select p;
                GridView1.DataSource = result.ToList();
                GridView1.DataBind();               
            }
            //condition();
            urungetir();
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
    }
}