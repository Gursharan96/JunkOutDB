using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JunkOut.Controllers;
using JunkOutDBModel;
using System.Web.Http.Results;

namespace JunkOut.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        private static int _aID { get; set; }

        [TestMethod]
        public void Add_Test()
        {
            //arrange
            AddressesController ac = new AddressesController();
            Address a = new Address()
            {
                ID = 1,
                StreetAddress= "7899 McLaughlin Rd",
                AptNum="",
                City= "Brampton",
                Province= "ON ",
                Country="Canada",
                PostalCode= "L6Y 5H9",
                AddressType="Commercial"

            };

            //Act
            var result = ac.PostAddress(a) as CreatedAtRouteNegotiatedContentResult<Address>;

            //Assert
            Assert.AreEqual("Brampton", result.Content.City);
            _aID = result.Content.ID;
        }

        [TestMethod]
        public void Get_Test()
        {
            //arrange
            AddressesController ac = new AddressesController();

            //Act
            var result = ac.GetAddress(_aID) as OkNegotiatedContentResult<Address>;

            //Assert
            Assert.AreEqual("Brampton", result.Content.City);
        }

        [TestMethod]
        public void Delete_Test()
        {
            //arrange
            AddressesController ac = new AddressesController();

            //Act
            var result = ac.DeleteAddress(_aID) as OkNegotiatedContentResult<Address>;

            //Assert
            Assert.AreEqual("Brampton", result.Content.City);
        }
    }
}
