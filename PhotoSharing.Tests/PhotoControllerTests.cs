using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoSharing.App_Start;
using PhotoSharing.Model;
using PhotoSharing.Models;
using PhotoSharing.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhotoSharing.Tests
{
    [TestClass]
    public class PhotoControllerTests
    {
        private PhotoController _controller;
        private Mock<IPhotoRepository> _mockRep;

        [TestInitialize]
        public void Setup()
        {
            AutoMapperConfig.ConfigureMappings();
            _mockRep = new Mock<IPhotoRepository>();
            _controller = new PhotoController(_mockRep.Object);
        }

        [TestMethod]
        public void CanCreate()
        {
            Assert.IsNotNull(_controller);
        }

        [TestMethod]
        public void Details_Returns_View()
        {
            _mockRep.Setup(r => r.PhotoDetailsById(It.IsAny<int>()))
                .Returns(new PhotoDetails());

            var result = _controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as PhotoDisplayModel;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Title_ReturnsIndex_MultipleMatches()
        {
            _mockRep.Setup(r => r.PhotosByTitle(It.IsAny<string>()))
                .Returns(new List<PhotoDetails> { new PhotoDetails(), new PhotoDetails() });

            var res = _controller.Title("test") as ViewResult;
            Assert.IsNotNull(res);
            Assert.AreEqual("Index", res.ViewName);

            var model = res.Model as List<PhotoDisplayModel>;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Title_ReturnsDetails_SingleMatche()
        {
            _mockRep.Setup(r => r.PhotosByTitle(It.IsAny<string>()))
                .Returns(new List<PhotoDetails> { new PhotoDetails() });

            var res = _controller.Title("test") as ViewResult;
            Assert.IsNotNull(res);
            Assert.AreEqual("Details", res.ViewName);

            var model = res.Model as PhotoDisplayModel;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Title_RedirectsSearch_NoMatches()
        {
            _mockRep.Setup(r => r.PhotosByTitle(It.IsAny<string>()))
                .Returns(new List<PhotoDetails>());

            var res = _controller.Title("test") as RedirectToRouteResult;
            Assert.IsNotNull(res);
            Assert.AreEqual("Photo", res.RouteValues["Controller"]);
            Assert.AreEqual("Search", res.RouteValues["Action"]);
            Assert.AreEqual("test", res.RouteValues["Keyword"]);
        }

    }
}
