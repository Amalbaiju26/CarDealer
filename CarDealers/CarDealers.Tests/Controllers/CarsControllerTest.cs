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
       
        [TestMethod]
        public void EditViewName()
        {
            controller.ModelState.AddModelError("Deatails", "error");
            // act
            ViewResult result = controller.Edit(Car[0]) as ViewResult;

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }
        [TestMethod]
        public void EditViewLoads()
        {
            controller.ModelState.AddModelError("Deatails", "error");
            // act
            ViewResult result = controller.Edit(Car[0]) as ViewResult;

            // assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateLoads()
        {
            // Arrange
            controller = new carsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }
        [TestMethod]

        public void DetailsId()

        {

            //Act

            HttpStatusCodeResult res = controller.Details(null) as HttpStatusCodeResult;

            //Assert

            Assert.AreEqual(500, res.StatusCode);

        }
        [TestMethod]

        public void DetailsCars()

        {

            //Act

            HttpNotFoundResult res = controller.Details(200) as HttpNotFoundResult;

            //Assert

            Assert.AreEqual(004, res.StatusCode);

        }


        [TestMethod]

        public void Carsview()

        {

            //Act

            var res = ((ViewResult)controller.Details(123)).Model;

            //Assert

            Assert.AreEqual(Car.SingleOrDefault(p => p.carno == 45), res);

        }
        [TestMethod]

        public void Check()

        {

            // act

            RedirectToRouteResult result = controller.DeleteConfirmed(500) as RedirectToRouteResult;
            
            var resultlist = result.RouteValues.ToArray();

            // assert

            Assert.AreEqual("Index", resultlist[0].Value);

        }
        [TestMethod]

        public void CheckInvalidIdRedirect()

        {

            RedirectToRouteResult result = controller.DeleteConfirmed(700) as RedirectToRouteResult;


            var resultlist = result.RouteValues.ToArray();


            Assert.AreEqual("Index", resultlist[0].Value);

        }

    }
}
