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
    public class IphoneController : Controller
    {
        private NewTempEntities db = new NewTempEntities();

        // GET: /Iphone/
        public ActionResult Index()
        {
            return View(db.iphones.ToList());
        }

        // GET: /Iphone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iphone iphone = db.iphones.Find(id);
            if (iphone == null)
            {
                return HttpNotFound();
            }
            return View(iphone);
        }

        // GET: /Iphone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Iphone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(iphone iphone)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(iphone.ImageFile.FileName);
                string extension = Path.GetExtension(iphone.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                iphone.url = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                iphone.ImageFile.SaveAs(fileName);

                db.iphones.Add(iphone);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iphone);
        }

        // GET: /Iphone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iphone iphone = db.iphones.Find(id);
            if (iphone == null)
            {
                return HttpNotFound();
            }
            return View(iphone);
        }

        // POST: /Iphone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,url,name,price,ram,rom,backcam,frontcam,color")] iphone iphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iphone);
        }

        // GET: /Iphone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            iphone iphone = db.iphones.Find(id);
            if (iphone == null)
            {
                return HttpNotFound();
            }
            return View(iphone);
        }

        // POST: /Iphone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            iphone iphone = db.iphones.Find(id);
            db.iphones.Remove(iphone);
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
