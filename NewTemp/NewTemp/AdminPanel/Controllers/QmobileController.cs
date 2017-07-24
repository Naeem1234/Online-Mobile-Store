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
    public class QmobileController : Controller
    {
        private NewTempEntities db = new NewTempEntities();

        // GET: /Qmobile/
        public ActionResult Index()
        {
            return View(db.qmobiles.ToList());
        }

        // GET: /Qmobile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qmobile qmobile = db.qmobiles.Find(id);
            if (qmobile == null)
            {
                return HttpNotFound();
            }
            return View(qmobile);
        }

        // GET: /Qmobile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Qmobile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(qmobile qmobile)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(qmobile.ImageFile.FileName);
                string extension = Path.GetExtension(qmobile.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                qmobile.url = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                qmobile.ImageFile.SaveAs(fileName);

                db.qmobiles.Add(qmobile);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qmobile);
        }

        // GET: /Qmobile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qmobile qmobile = db.qmobiles.Find(id);
            if (qmobile == null)
            {
                return HttpNotFound();
            }
            return View(qmobile);
        }

        // POST: /Qmobile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,url,name,price,ram,rom,backcam,frontcam,color")] qmobile qmobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qmobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qmobile);
        }

        // GET: /Qmobile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qmobile qmobile = db.qmobiles.Find(id);
            if (qmobile == null)
            {
                return HttpNotFound();
            }
            return View(qmobile);
        }

        // POST: /Qmobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            qmobile qmobile = db.qmobiles.Find(id);
            db.qmobiles.Remove(qmobile);
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
