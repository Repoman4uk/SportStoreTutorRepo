﻿using System;
using System.Collections.Generic;
using System.Text;
using SportStore.Models;
using SportStore.Controllers;
using Moq;
using Xunit;
using System.Linq;

namespace SportStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void CanPaginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product{ProductID = 1, Name = "P1"},
                    new Product{ProductID = 2, Name = "P2"},
                    new Product{ProductID = 3, Name = "P3"},
                    new Product{ProductID = 4, Name = "P4"},
                    new Product{ProductID = 5, Name = "P5"}
                });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;

            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}
