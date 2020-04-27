using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataAccess.Data.Repositories;
using ToDo.Models;
using ToDo.Models.Models;
using System.Linq;

namespace ToDo.DataAccess.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private List<ToDoList> _toDoLists;
        public ToDoRepository()
        {
            _toDoLists = new List<ToDoList>() {
            new ToDoList(){ Id=1,Task="Task 1",Duedate = new DateTime(2020,04,25),Priority=Priority.High, CreatedDate=new DateTime(2020,04,25)},
            new ToDoList(){ Id=2,Task="Task 2",Duedate = new DateTime(2020,04,26),Priority=Priority.Medium, CreatedDate=new DateTime(2020,04,25)},
            new ToDoList(){ Id=3,Task="Task 3",Duedate = new DateTime(2020,04,27),Priority=Priority.Low, CreatedDate=new DateTime(2020,04,25)},
            };
        }

        public ToDoList AddTask(ToDoList toDoList)
        {
            toDoList.Id = _toDoLists.Max(x => x.Id) + 1;
            _toDoLists.Add(toDoList);
            return toDoList;
        }

        public List<ToDoList> GetToDoByTask(string TaskName)
        {
            return _toDoLists.Where(x => x.Task.ToLower().Contains(TaskName.ToLower())).ToList();
        }

        public List<ToDoList> GetToDoList()
        {
            return _toDoLists;
        }
    }
}
