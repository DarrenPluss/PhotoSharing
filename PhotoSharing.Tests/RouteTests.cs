using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using MvcRouteTester;
using PhotoSharingApplication.Controllers;

namespace PhotoSharing.Tests
{
    [TestClass]
    public class RouteTests
    {
        RouteCollection _routes;

        [TestInitialize]
        public void Setup()
        {
            _routes = new RouteCollection();
            RouteConfig.RegisterRoutes(_routes);
        }

        [TestMethod]
        public void SampleRouteTests()
        {
            _routes.ShouldMap("~/photo/1").To<PhotoController>(c => c.Details(1));
            _routes.ShouldMap("~/photo/test").To<PhotoController>(c => c.Title("test"));
        }
    }
}
