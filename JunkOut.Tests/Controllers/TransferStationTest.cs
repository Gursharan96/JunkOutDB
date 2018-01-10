using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkOut.Controllers;
using System.Web.Mvc;
using System.Net;
using JunkOutDBModel;

namespace JunkOut.Tests.Controllers
{
    [TestClass]
    public class TransferStationTest
    {
        [TestMethod]
        public void IndexAction_Returns_IndexView()
        {
            //Arrange
            TransferStationsController tc = new TransferStationsController();

            //Act
            ViewResult actualResult = tc.Index() as ViewResult;
            string actualViewName = actualResult.ViewName;

            //Assert
            string expectedViewName = "Index";
            Assert.AreEqual(expectedViewName, actualViewName);
        }

        [TestMethod]
        public void DetailsAction_NullID_BADHTTP()
        {
            //Arrange
            TransferStationsController tc = new TransferStationsController();
            //Act
            HttpStatusCodeResult actualResult = tc.Details(null) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;

            //Assert
            int expectedStatusCode = new HttpStatusCodeResult(HttpStatusCode.BadRequest).StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod]
        public void DetailsAction_InvalidID_NotFoundHTTP()
        {
            //Arrange
            TransferStationsController tc = new TransferStationsController();

            //Act
            HttpStatusCodeResult actualResult = tc.Details(-1) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;

            //Assert
            int expectedStatusCode = new HttpStatusCodeResult(HttpStatusCode.NotFound).StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod()]
        public void DetailsAction_DB_ValidOrder()
        {
            //Arrange
            TransferStationsController tc = new TransferStationsController();

            //Act
            ViewResult actualResult = tc.Details(1) as ViewResult;
            TransferStation actualTf = actualResult.Model as TransferStation;
            string actualCompany = actualTf.Company;

            //Assert

            string ExpectedCompany = "Progressive Waste";
            Assert.AreEqual(ExpectedCompany, actualCompany);

        }
    }
}
