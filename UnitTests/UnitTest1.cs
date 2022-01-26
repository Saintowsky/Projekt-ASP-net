using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt_ASP.Controllers;
using Projekt_ASP.Data;
using Projekt_ASP.Models;
using System;
using Xunit;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ImageDbContext _context;
        private readonly IWebHostEnvironment ___hostEnvironment;

        [Fact]
        public void Test()
        {
            // Given
            ImageController controller = new ImageController(_context, ___hostEnvironment);
            ImageModel expected = new ImageModel()
            {
                ImageID = 1,
                Author = "Dupa",
                Title = "Dupa",
                ImageFile = null
            };

            //When
            ImageModel actual = controller.Create(1, "Dupa", "Dupa", null);
        }
    }
}
