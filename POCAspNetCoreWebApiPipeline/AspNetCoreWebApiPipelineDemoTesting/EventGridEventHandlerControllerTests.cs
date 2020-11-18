using AspNetCoreWebApiPipelineDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace NUnitTestProject1
{

    public class EventGridEventHandlerControllerTests
    {
        EventGridEventHandlerController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new EventGridEventHandlerController();
        }

        [Test]
        public void Ping_WhenCalled_ReturnOkResult()
        {
            // Act
            var okResult = _controller.Ping();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }
    }
}