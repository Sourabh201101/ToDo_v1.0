using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.DataAccess.Data.Repositories;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository _toDoRepository;

        public HomeController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;

        }
        public IActionResult GetToDoList()
        {
            List<ToDoList> toDoLists = _toDoRepository.GetToDoList();
            return View(toDoLists);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                toDoList.CreatedDate = DateTime.Now;
                _toDoRepository.AddTask(toDoList);
                return RedirectToAction("GetToDoList");
            }
            else 
                return View();
        }
        public IActionResult GetToDoByTask(string TaskName) 
        {
            List<ToDoList> toDoLists = _toDoRepository.GetToDoByTask(TaskName);
            return Json(toDoLists);
        }
    }
}