using StudentMvc.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMvc.Controllers
{
    public class StudentController : Controller
    {
        db_testEntities dbObj = new db_testEntities();
        // GET: Student
        public ActionResult Student(tbl_Student obj )
        {
            if (obj != null)
                return View(obj);
            else
                return View();
        }
        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            tbl_Student obj = new tbl_Student();
            if (ModelState.IsValid)
            {
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;
                obj.Result = model.Result;
                obj.Fee = model.Fee;
                if (model.ID == 0)
                {
                    dbObj.tbl_Student.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                }
                ModelState.Clear();
            }

            return View("Student");
        }
         public ActionResult StudentList()
        {
            var res = dbObj.tbl_Student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.tbl_Student.Where(x=> x.ID==id).First();
            dbObj.tbl_Student.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.tbl_Student.ToList();
            return View("StudentList",list);
        }
        public ActionResult Grade()
        {
            var res = dbObj.tbl_Student.ToList();
            return View(res);
        }
        public ActionResult Fee()
        {
            var res = dbObj.tbl_Student.ToList();
            return View(res);
        }
        public ActionResult Login()
        {
            return View();
        }




    }
}