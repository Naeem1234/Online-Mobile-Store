using NewTemp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewTemp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


       

        public ActionResult products_detail(int? id)
        {
            NewTempEntities4 db6 = new NewTempEntities4();

            samsung samsung_products = db6.samsungs.Where(m => m.id == id).Single();

            return View(samsung_products);


        }


        public ActionResult huawei_detail(int? id)
        {
            NewTempEntities4 db6 = new NewTempEntities4();

            huawei huawei_products = db6.huaweis.Where(m => m.id == id).Single();

            return View(huawei_products);


        }

        public ActionResult iphone_detail(int? id)
        {
            NewTempEntities4 db6 = new NewTempEntities4();

            iphone huawei_products = db6.iphones.Where(m => m.id == id).Single();

            return View(huawei_products);


        }

        public ActionResult gridview_detail(int? id)
        {
            NewTempEntities2 db6 = new NewTempEntities2();

            gridView huawei_products = db6.gridViews.Where(m => m.id == id).Single();

            return View(huawei_products);


        }





        public ActionResult lg_detail(int? id)
        {
            NewTempEntities4 db6 = new NewTempEntities4();

            lg huawei_products = db6.lgs.Where(m => m.id == id).Single();

            return View(huawei_products);


        }



        public ActionResult oppo_detail(int? id)
        {
            NewTempEntities4 db6 = new NewTempEntities4();

            oppo huawei_products = db6.oppoes.Where(m => m.id == id).Single();

            return View(huawei_products);


        }




        public ActionResult qmobile_detail(int? id)
        {
            NewTempEntities4 db6 = new NewTempEntities4();

            qmobile huawei_products = db6.qmobiles.Where(m => m.id == id).Single();

            return View(huawei_products);


        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ListView()
        {
            ViewBag.Message = "Your List View page.";
            return View();
        }

        public ActionResult GridView()
        {
            NewTempEntities2 db = new NewTempEntities2();


            ViewBag.Message = "Your Grid View page.";
            return View(db.gridViews.ToList());
        }


        public ActionResult ThreeCol()
        {
            ViewBag.Message = "Your three col page.";

            return View();
        }

        public ActionResult Samsung()
        {
            NewTempEntities4 db1 = new NewTempEntities4();
            ViewBag.Message = "Your samsung page.";

            return View(db1.samsungs.ToList());
        }

        public ActionResult Huawei()
        {
            NewTempEntities4 db2 = new NewTempEntities4();
            ViewBag.Message = "Your Huawei page.";

            return View(db2.huaweis.ToList());
        }

        public ActionResult Qmobile()
        {

            NewTempEntities4 db3 = new NewTempEntities4();
            ViewBag.Message = "Your qmobile page.";

            return View(db3.qmobiles.ToList());
        }

        public ActionResult Lg()
        {

            NewTempEntities4 db4 = new NewTempEntities4();
            ViewBag.Message = "Your Lg page.";

            return View(db4.lgs.ToList());
        }


        public ActionResult Oppo()
        {

            NewTempEntities4 db5 = new NewTempEntities4();
            ViewBag.Message = "Your oppo page.";

            return View(db5.oppoes.ToList());
        }

        public ActionResult Iphone()
        {
            NewTempEntities4 db6 = new NewTempEntities4();
            ViewBag.Message = "Your iphone page.";

            return View(db6.iphones.ToList());
        }

        public ActionResult Register()
        {
            string first = Request["fname"];
            string last = Request["lname"];
            string email = Request["email"];
            string passw = Request["pass"];
            string contactNO = Request["contact"];


            NewTempEntities5 db7 = new NewTempEntities5();

            register r = new register();

            r.firstname = first;
            r.lastname = last;
            r.email = email;
            r.password = passw;
            r.contact = contactNO;

            db7.registers.Add(r);
            db7.SaveChanges();
            ViewBag.Message = "Your register page.";

            return View();
        }

       


        public ActionResult Login()
        {
            
            NewTempEntities5 db7 = new NewTempEntities5();
            login l = new login();
            string name = Request["user"];
            string password = Request["pass"];

            

          



     


           return View();
           

           
        }


        public ActionResult Login(login u)
        {

            return View();


        }

        public ActionResult Product_details()
        {
            ViewBag.Message = "Your details page.";

            return View();
        }

    }
}