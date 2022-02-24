using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudAnoop1.Models;

namespace CrudAnoop1.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext Dbcontext;
        public StudentController(ApplicationDbContext Dbcontext)
        {
            this.Dbcontext = Dbcontext;
        }
        public IActionResult Index()
        {
            var Stu = Dbcontext.students.ToList();
            return View(Stu);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            Dbcontext.students.Add(stu);
            Dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var obj = Dbcontext.students.SingleOrDefault(a => a.Id == id);
            Dbcontext.students.Remove(obj);
            Dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var obj = Dbcontext.students.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Address,Mobile,Email,Department")] Student student)
        {
            if (id != 0)
            {
                student.Id = id;
                Dbcontext.students.Update(student);
                Dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}
