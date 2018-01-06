using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkOutDBModel;
using JunkOut.Controllers;
using System.Web.Mvc;
using System.Net;

namespace JunkOut.Tests.Controllers
{
    [TestClass]
    public class BinControllerTest
    {
        [TestMethod]
        public void IndexAction_Returns_IndexView()
        {
            //Arrange
            BinsController bc = new BinsController();

            //Act
            ViewResult actualResult = bc.Index() as ViewResult;
            string actualViewName = actualResult.ViewName;

            //Assert
            string expectedViewName = "Index";
            Assert.AreEqual(expectedViewName, actualViewName);
        }

        [TestMethod]
        public void DetailsAction_NullID_BADHTTP()
        {
            //Arrange
            BinsController bc = new BinsController();
            //Act
            HttpStatusCodeResult actualResult = bc.Details(null) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;

            //Assert
            int expectedStatusCode = new HttpStatusCodeResult(HttpStatusCode.BadRequest).StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod]
        public void DetailsAction_InvalidID_NotFoundHTTP()
        {
            //Arrange
            BinsController bc = new BinsController();

            //Act
            HttpStatusCodeResult actualResult = bc.Details(-1) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;

            //Assert
            int expectedStatusCode = new HttpStatusCodeResult(HttpStatusCode.NotFound).StatusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod()]
        public void DetailsAction_DB_ValidOrder()
        {
            //Arrange
            BinsController bc = new BinsController();

            //Act
            ViewResult actualResult = bc.Details(1) as ViewResult;
            Bin actualBin = actualResult.Model as Bin;
            string actualBinSize = actualBin.BinSize;

            //Assert

            string ExpectedBinSize = "5";
            Assert.AreEqual(ExpectedBinSize, actualBinSize);

        }


    }
}
