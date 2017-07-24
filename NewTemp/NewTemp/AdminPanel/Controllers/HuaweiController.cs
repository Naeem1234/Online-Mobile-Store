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
    public class HuaweiController : Controller
    {
        private NewTempEntities db = new NewTempEntities();

        // GET: /Huawei/
        public ActionResult Index()
        {
            return View(db.huaweis.ToList());
        }

        // GET: /Huawei/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            huawei huawei = db.huaweis.Find(id);
            if (huawei == null)
            {
                return HttpNotFound();
            }
            return View(huawei);
        }

        // GET: /Huawei/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Huawei/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(huawei huawei)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(huawei.ImageFile.FileName);
                string extension = Path.GetExtension(huawei.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                huawei.url = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                huawei.ImageFile.SaveAs(fileName);

                db.huaweis.Add(huawei);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(huawei);
        }

        // GET: /Huawei/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            huawei huawei = db.huaweis.Find(id);
            if (huawei == null)
            {
                return HttpNotFound();
            }
            return View(huawei);
        }

        // POST: /Huawei/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,url,name,price,ram,rom,backcam,frontcam,color")] huawei huawei)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huawei).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(huawei);
        }

        // GET: /Huawei/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            huawei huawei = db.huaweis.Find(id);
            if (huawei == null)
            {
                return HttpNotFound();
            }
            return View(huawei);
        }

        // POST: /Huawei/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            huawei huawei = db.huaweis.Find(id);
            db.huaweis.Remove(huawei);
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
