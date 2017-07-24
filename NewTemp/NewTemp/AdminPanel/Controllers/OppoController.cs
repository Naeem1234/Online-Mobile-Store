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
    public class OppoController : Controller
    {
        private NewTempEntities db = new NewTempEntities();

        // GET: /Oppo/
        public ActionResult Index()
        {
            return View(db.oppoes.ToList());
        }

        // GET: /Oppo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oppo oppo = db.oppoes.Find(id);
            if (oppo == null)
            {
                return HttpNotFound();
            }
            return View(oppo);
        }

        // GET: /Oppo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Oppo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(oppo oppo)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(oppo.ImageFile.FileName);
                string extension = Path.GetExtension(oppo.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                oppo.url = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                oppo.ImageFile.SaveAs(fileName);

                db.oppoes.Add(oppo);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oppo);
        }

        // GET: /Oppo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oppo oppo = db.oppoes.Find(id);
            if (oppo == null)
            {
                return HttpNotFound();
            }
            return View(oppo);
        }

        // POST: /Oppo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,url,name,price,ram,rom,backcam,frontcam,color")] oppo oppo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oppo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oppo);
        }

        // GET: /Oppo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oppo oppo = db.oppoes.Find(id);
            if (oppo == null)
            {
                return HttpNotFound();
            }
            return View(oppo);
        }

        // POST: /Oppo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oppo oppo = db.oppoes.Find(id);
            db.oppoes.Remove(oppo);
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
