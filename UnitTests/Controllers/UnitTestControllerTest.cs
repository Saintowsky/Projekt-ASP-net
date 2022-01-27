using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Projekt_ASP.Areas.Identity.Data;
using Projekt_ASP.Controllers;
using Projekt_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Controllers
{
    [TestClass]
    public class UnitTestControllerTest
    {


        [TestMethod]
        public void HomeIndexCheck()
        {
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;
            logger = Mock.Of<ILogger<HomeController>>();
            HomeController homeController = new HomeController(logger);

            ViewResult viewResult = homeController.Index() as ViewResult;
            Assert.AreEqual(null, viewResult.ViewName);

        }
     
    }   
}
