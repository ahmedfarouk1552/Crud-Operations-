using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc4.Models;

namespace mvc4.Controllers
{
    public class instructorController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: instructor
        public ActionResult getinstructor()
        {
            return View(db.Instructors.ToList());
        }

        public ActionResult create()
        {
            SelectList depts = new SelectList(db.Departments.ToList(),"Dept_Id","Dept_Name");
            ViewBag.depts = depts;
            return View();
        }
         [HttpPost]
        public ActionResult create(Instructor ins,HttpPostedFileBase img)
        {
            if(img != null)
            {
                img.SaveAs(Server.MapPath($"~/attach/{img.FileName}"));
                ins.photo = img.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Instructors.Add(ins);
                db.SaveChanges();
                return RedirectToAction("getinstructor");
            }
            else
            {
                SelectList depts = new SelectList(db.Departments.ToList(), "Dept_Id", "Dept_Name");
                ViewBag.depts = depts;
                return View();
            }
        }

        public ActionResult save(Instructor ins,HttpPostedFileBase img)
        {
            if(img != null)
            {
                img.SaveAs(Server.MapPath($"~/attach/{img.FileName}"));
                ins.photo=img.FileName;
            }
            db.Instructors.Add(ins);
            db.SaveChanges();
            return RedirectToAction("getinstructor");
        }

        public ActionResult delete(int id)
        {
            Instructor ins = db.Instructors.Where(n => n.Ins_Id == id).SingleOrDefault();
            db.Instructors.Remove(ins);
            db.SaveChanges();
            return RedirectToAction("getinstructor");
        }

        public ActionResult update(int id)
        {
            Instructor s = db.Instructors.Where(n => n.Ins_Id == id).SingleOrDefault();
            SelectList depts = new SelectList(db.Departments.ToList(), "Dept_Id", "Dept_Name");
            ViewBag.depts = depts;
            return View(s);
        }

        [HttpPost]
        public ActionResult update(Instructor s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("getinstructor");
            }
            else
            {
                SelectList depts = new SelectList(db.Departments.ToList(), "Dept_Id", "Dept_Name");
                ViewBag.depts = depts;
                return View(s);
            }
        }
        public ActionResult download(string name)
        {
            if(name != null)
            {
                return File($"~/attach/{name}", "image/png");
            }
            else
            {
                return File("~/attach/FB_IMG_1515922317434.jpg", "image");
            }
        }

    }
}