using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using CarDealers.Controllers;
using System.Linq;
using System.Collections.Generic;
using CarDealers.Models;
using Moq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.Tests.Controllers
{
    [TestClass]
    public class CarsControllerTest
    {
        //moq data
        carsController controller;
        List<car> Car;
        Mock<IMockCars> mock;
        [TestInitialize]
        public void TestInitialize()
        {
            Car = new List<car>
            {
                new car {carno = 5,Name = "innova", price =9040,color ="red"},
                new car {carno=6,Name = "etios", price =1000,color ="gery"},
                new car {carno=7,Name = "swift", price =7000,color ="black"}
            };
            mock = new Mock<IMockCars>();
            mock.Setup(c => c.Cars).Returns(Car.AsQueryable());
            //object
            controller = new carsController(mock.Object);
        }
        // [TestMethod]
        //public void LoadsindexView()
        //{
        //    ViewResult result = controller.Index() as ViewResult;
        //    //assert
        //    Assert.AreEqual("Index", result.ViewName);
        //}
        //[TestMethod]
        //public void IndexLoadsCar()
        //{
        //    var result =(List<car>)((ViewResult)controller.Index()).Model;
        //    CollectionAssert.AreEqual(Car, result);
        //}
        //    [TestMethod]
        //    //public void  EditPostIndexViewLoads()
        //    //{
        //    //    // act
        //    //    RedirectToRouteResult result = controller.Edit(Car[0]) as RedirectToRouteResult;

        //    //    // assert
        //    //    Assert.IsNotNull(result);
        //    //}
        //}
    }
}
