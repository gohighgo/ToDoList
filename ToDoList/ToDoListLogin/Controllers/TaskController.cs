using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListLogin.Data;
using ToDoListLogin.Models;

namespace ToDoListLogin.Controllers
{
    public class TaskController : Controller
    {
        private readonly AuthDbContext _context;
        public TaskController(AuthDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<tbTask> tasks = _context.tbTasks.ToList();
     
            return View(tasks.Where(x=>x.UserId== userId));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            tbTask task = _context.tbTasks.Where(t => t.TaskId == Id).FirstOrDefault();
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(tbTask task)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            task.UserId = userId;

            _context.Attach(task);
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            tbTask task = _context.tbTasks.Where(t => t.TaskId == Id).FirstOrDefault();
            return View(task);
        }
        [HttpPost]
        public IActionResult Delete(tbTask task)
        {
            _context.Attach(task);
            _context.Entry(task).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create()
        {

            tbTask task = new tbTask();
            return View(task);
        }
        [HttpPost]
        public IActionResult Create(tbTask task)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            task.UserId = userId;
            _context.Attach(task);

            _context.Entry(task).State = EntityState.Added;
           if(userId== null)
                return RedirectToAction("index");
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
