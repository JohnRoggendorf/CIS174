using Xunit;
using Moq;
using CIS174_OlympicGames.Controllers;
using CIS174_OlympicGames.Models;
using CIS174_OlympicGames.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UnitTests
{
    public class TicketControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithTickets()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            mockService.Setup(s => s.GetAllTickets()).Returns(new List<TicketModel>
            {
                new TicketModel { Name = "Test 1", Description = "Desc", SprintNumber = 1, PointValue = 5, Status = "to do" }
            });

            var controller = new TicketController(mockService.Object);

            // Act
            var result = controller.Index() as ViewResult;
            var model = result?.Model as List<TicketModel>;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Single(model);
        }
    }
}