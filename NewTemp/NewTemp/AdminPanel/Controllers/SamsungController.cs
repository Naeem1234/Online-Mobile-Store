using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models;
using System.IO;

namespace AdminPanel.Controllers
{
    public class SamsungController : Controller
    {
        private NewTempEntities db = new NewTempEntities();

        // GET: /Samsung/
        public ActionResult Index()
        {
            return View(db.samsungs.ToList());
        }

        // GET: /Samsung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            samsung samsung = db.samsungs.Find(id);
            if (samsung == null)
            {
                return HttpNotFound();
            }
            return View(samsung);
        }

        // GET: /Samsung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Samsung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(samsung samsung)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(samsung.ImageFile.FileName);
                string extension = Path.GetExtension(samsung.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                samsung.url = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                samsung.ImageFile.SaveAs(fileName);

                db.samsungs.Add(samsung);
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samsung);
        }

        // GET: /Samsung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            samsung samsung = db.samsungs.Find(id);
            if (samsung == null)
            {
                return HttpNotFound();
            }
            return View(samsung);
        }

        // POST: /Samsung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,url,name,price,ram,rom,backcam,frontcam,color")] samsung samsung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samsung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samsung);
        }

        // GET: /Samsung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            samsung samsung = db.samsungs.Find(id);
            if (samsung == null)
            {
                return HttpNotFound();
            }
            return View(samsung);
        }

        // POST: /Samsung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            samsung samsung = db.samsungs.Find(id);
            db.samsungs.Remove(samsung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
