using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoSharing.Controllers;
using System.Web.Mvc;

namespace PhotoSharing.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [TestInitialize]
        public void Setup()
        {
            _controller = new HomeController();
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(_controller);
        }

        [TestMethod]
        public void Index_Returns_View()
        {
            var result = _controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

    }
}
