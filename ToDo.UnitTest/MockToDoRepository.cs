using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ToDo.DataAccess.Data.Repositories;
using ToDo.Models;
using ToDo.Models.Models;

namespace ToDo.UnitTest
{
    public class MockToDoRepository : Mock<IToDoRepository>
    {
        List<ToDoList> mockToDoList = new List<ToDoList>
        {
            new ToDoList()
            {
              Id=1,
              Task="Unit Test Task",
              Priority = Priority.High,
              Duedate=DateTime.Now,
              CreatedDate=DateTime.Now
            }
        };

        public MockToDoRepository MockToDoList()
        {
            Setup(x => x.GetToDoList()).Returns(mockToDoList);
            return this;
        }
        public MockToDoRepository MockCreate()
        {
            Setup(x => x.AddTask(mockToDoList[0])).Returns(mockToDoList[0]);
            return this;
        }
        public MockToDoRepository MockGetToDoByTask()
        {
            Setup(x => x.GetToDoByTask(It.IsAny<string>())).Returns(mockToDoList);
            return this;
        }
    }
}