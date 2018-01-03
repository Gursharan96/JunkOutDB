using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkOut.Controllers;
using System.Web.Mvc;
using JunkOutDBModel;
using System.Net;

namespace JunkOut.Tests.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void IndexAction_Returns_IndexView()
        {
            //Arrange
            OrdersController oc = new OrdersController();

            //Act
            ViewResult actualResult = oc.Index() as ViewResult;
            string actualViewName = actualResult.ViewName;

            //Assert
            string expectedViewName = "Index";
            Assert.AreEqual(expectedViewName, actualViewName);
        }


      

        [TestMethod]

        public void DetailsAction_NullID_BADHTTP()
        {
            //Arrange
            OrdersController oc = new OrdersController();
            //Act
            HttpStatusCodeResult actualResult = oc.Details(null) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;

            //Assert
            int expectedStatusCode = new HttpStatusCodeResult(HttpStatusCode.BadRequest).StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }
    }
}
