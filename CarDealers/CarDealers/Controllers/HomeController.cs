using CarDealers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CarDealer()
        {
            /* var Carid = new List<string>();

                 for (int i = 1;i <=10; i++)
             {
                 Carid.Add("Car " + i.ToString());
             }
             ViewBag.CarDealer = Carid;
             */
            var cars = new List<Cars>();
            for (int i = 1; i <= 10; i++)
            {
                Cars car = new Cars();
                car.Name = "car" + i.ToString();
                cars.Add(car);
            }

                return View(cars);
        }
        public ActionResult Carsales(string carName)
        {
            ViewBag.carName = carName;
            return View();
        }
    }
}