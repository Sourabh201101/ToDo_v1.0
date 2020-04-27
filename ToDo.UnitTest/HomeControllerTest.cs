using System;
using ToDo.Models;
using ToDo.Models.Models;
using Xunit;
using ToDo.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.UnitTest
{
    public class HomeControllerTest
    {
        #region Initialize
        ToDoList mockToDoList = new ToDoList()
        {
            Id = 1,
            Task = "Unit Test Task",
            Priority = Priority.High,
            Duedate = DateTime.Now,
            CreatedDate = DateTime.Now
        };
        string taskName = "Unit Test Task";
        #endregion
        [Fact]
        public void ToDoList_DataPresent()
        {
            // Arrange
            var mockToDoRepository = new MockToDoRepository().MockToDoList();
            var homeController = new HomeController(mockToDoRepository.Object);
            // Act
            var result = homeController.GetToDoList();
            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }
        [Fact]
        public void Create_NoError()
        {
            // Arrange
            var mockToDoRepository = new MockToDoRepository().MockCreate();
            var homeController = new HomeController(mockToDoRepository.Object);
            // Act
            var result = homeController.Create(mockToDoList);
            // Assert
            Assert.IsAssignableFrom<RedirectToActionResult>(result);
            var redirectToAction = (RedirectToActionResult)result;
            Assert.Equal("GetToDoList", redirectToAction.ActionName);
        }
        [Fact]
        public void Create_ModelStateInvalid()
        {
            // Arrange
            var mockToDoRepository = new MockToDoRepository().MockCreate();
            var homeController = new HomeController(mockToDoRepository.Object);
            homeController.ModelState.AddModelError("Unit test","Unit test error");
            // Act
            var result = homeController.Create(mockToDoList);
            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }
        [Fact]
        public void GetToDoByTask()
        {
            // Arrange
            var mockToDoRepository = new MockToDoRepository().MockGetToDoByTask();
            var homeController = new HomeController(mockToDoRepository.Object);
            // Act
            var result = homeController.GetToDoByTask(taskName);
            //Assert
            Assert.IsAssignableFrom<JsonResult>(result);
        }
    }
}