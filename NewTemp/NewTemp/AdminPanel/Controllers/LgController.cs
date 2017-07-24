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
    public class LgController : Controller
    {
        private NewTempEntities db = new NewTempEntities();

        // GET: /Lg/
        public ActionResult Index()
        {
            return View(db.lgs.ToList());
        }

        // GET: /Lg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lg lg = db.lgs.Find(id);
            if (lg == null)
            {
                return HttpNotFound();
            }
            return View(lg);
        }

        // GET: /Lg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Lg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(lg lg)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(lg.ImageFile.FileName);
                string extension = Path.GetExtension(lg.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                lg.url = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                lg.ImageFile.SaveAs(fileName);

                db.lgs.Add(lg);

                db.SaveChanges();
                return RedirectToAction("Index"); ;
            }

            return View(lg);
        }

        // GET: /Lg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lg lg = db.lgs.Find(id);
            if (lg == null)
            {
                return HttpNotFound();
            }
            return View(lg);
        }

        // POST: /Lg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,url,name,price,ram,rom,backcam,frontcam,color")] lg lg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lg);
        }

        // GET: /Lg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lg lg = db.lgs.Find(id);
            if (lg == null)
            {
                return HttpNotFound();
            }
            return View(lg);
        }

        // POST: /Lg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lg lg = db.lgs.Find(id);
            db.lgs.Remove(lg);
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
