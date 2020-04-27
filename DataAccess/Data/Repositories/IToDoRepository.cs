using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Models;
namespace ToDo.DataAccess.Data.Repositories
{
    public interface IToDoRepository
    {
        List<ToDoList> GetToDoList();
        List<ToDoList> GetToDoByTask(string Task);
        ToDoList AddTask(ToDoList toDoList);
    }
}
