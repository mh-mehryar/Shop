using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Online_Shop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private MyCmsContext db = new MyCmsContext();

        public ProductsController()
        {
            productRepository = new ProductRepository(db);
            categoryRepository = new CategoryRepository(db);
        }

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(productRepository.GetAllProducts());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Cat_Id = new SelectList(categoryRepository.GetAllCategories(), "Cat_Id", "Cat_Title");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pro_Id,Cat_Id,Pro_Title,Pro_Code,Description,Is_Active,Image")] Product product,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    product.Image = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + product.Image));
                }


                productRepository.InsertProduct(product);
                productRepository.save();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_Id = new SelectList(db.Categories, "Cat_Id", "Cat_Title", product.Cat_Id);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_Id = new SelectList(categoryRepository.GetAllCategories(), "Cat_Id", "Cat_Title", product.Cat_Id);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pro_Id,Cat_Id,Pro_Title,Pro_Code,Description,Is_Active,Image")] Product product,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (product.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + product.Image));
                    }
                    product.Image = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + product.Image));
                }


                productRepository.UpdateProduct(product);
                productRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.Cat_Id = new SelectList(db.Categories, "Cat_Id", "Cat_Title", product.Cat_Id);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productRepository.GetProductById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = productRepository.GetProductById(id);
            if (product.Image != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + product.Image));
            }
            productRepository.DeleteProduct(product);
            productRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categoryRepository.Dispose();
                productRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
