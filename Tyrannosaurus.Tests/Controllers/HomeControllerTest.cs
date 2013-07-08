using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyrannosaurus;
using Tyrannosaurus.UI.Controllers;

namespace Tyrannosaurus.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;
        private ViewResult _result;

        [TestInitialize]
        public void SetupContext()
        {
            _controller = new HomeController();
            _result = _controller.Index();
        }

        [TestMethod]
        public void About()
        {
            // Assert
            Assert.IsNotNull(_result);
        }

        [TestMethod]
        public void Contact()
        {
            // Assert
            Assert.IsNotNull(_result);
        }

        [TestMethod]
        public void IndexShouldReturnView()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void AboutShouldReturnView()
        {
            var controller = new HomeController();
            var result = controller.About();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ContactShouldReturnView()
        {
            var controller = new HomeController();
            var result = controller.Contact();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
