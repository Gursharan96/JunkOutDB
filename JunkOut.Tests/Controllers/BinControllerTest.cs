using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkOutDBModel;
using JunkOut.Controllers;
using System.Web.Mvc;

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

    }
}
