using Microsoft.AspNetCore.Mvc;
using Moq;
using myWebAppTest.Controllers;
using myWebAppTest.Models;
using myWebAppTest.Models.Entities;
using myWebAppTest.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWebApp.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void index_Test()
        {
            //Arange
            moqData moqdata = new moqData();

            var moq = new Mock<IProductService>();

            moq.Setup(p => p.GetAll()).Returns(moqdata.GetAll());

            ProductController product = new ProductController(moq.Object);
            //act
            var result = product.Index();

            //Assert

            Assert.IsType<ViewResult>(result);
        }
        [Theory]
        [InlineData(1, -1)]
        public void Detail_Test(int validId, int inValidId)
        {
            //Arange
            moqData moqdata = new moqData();

            var moq = new Mock<IProductService>();

            moq.Setup(p => p.GetById(validId)).Returns(moqdata.GetAll().FirstOrDefault(p => p.Id == validId));

            ProductController product = new ProductController(moq.Object);
            //act
            var result = product.Details(validId);
            //Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);
            //-----------------------------------------
            //Assert
            moq.Setup(p => p.GetById(inValidId)).Returns(moqdata.GetAll().FirstOrDefault(p => p.Id == inValidId));
            //Act
            var invalidResult = product.Details(inValidId);
            Assert.IsType<NotFoundResult>(invalidResult);
        }
        [Fact]
        public void Create_Test()
        {
            //Arrange
            var moq = new Mock<IProductService>();
            ProductController productController = new(moq.Object);
            Product product = new()
            {
                Id = 1,
                Name = "Amir",
                Description = "good",
                Price = 1000
            };
            //Act
            var result = productController.Create(product);

            //Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Null(redirect.ControllerName);

            //-------------------------
            Product product2 = new()
            {
                Id = 2,
            };
            productController.ModelState.AddModelError("Name", "Name is inValid");

            var inValidresult = productController.Create(product2);


            Assert.IsType<BadRequestResult>(inValidresult);
        }
        [Theory]
        [InlineData(1,-1)]
        public void Delete_Test(int validId,int inValidId)
        {
            //Arange
            moqData moqdata = new moqData();

            var moq = new Mock<IProductService>();

            moq.Setup(p => p.GetById(validId)).Returns(moqdata.GetAll().FirstOrDefault(p => p.Id == validId));

            ProductController product = new ProductController(moq.Object);
            //act
            var result = product.Delete(validId);
            //Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Null(redirect.ControllerName);

            //-----------------------------------------
            //Assert
            moq.Setup(p => p.GetById(inValidId)).Returns(moqdata.GetAll().FirstOrDefault(p => p.Id == inValidId));
            //Act
            var invalidResult = product.Delete(inValidId);
            Assert.IsType<NotFoundResult>(invalidResult);
        }
    }
}
