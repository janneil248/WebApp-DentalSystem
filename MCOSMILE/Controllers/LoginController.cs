using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCOSMILE.Models;

namespace MCOSMILE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            using (DbModels2 dbModel2 = new DbModels2())
            {
                return View(dbModel2.Logins.ToList());
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels2 dbModel2 = new DbModels2())
            {
                return View(dbModel2.Logins.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        // GET: Login/Create
        public ActionResult Create1()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Login login)
        {
            try
            {
                using (DbModels2 dbModel2 = new DbModels2())
                {
                    dbModel2.Logins.Add(login);
                    dbModel2.SaveChanges();
                }
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels2 dbModel2 = new DbModels2())
            {
                return View(dbModel2.Logins.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Login login)
        {
            try
            {
                using (DbModels2 dbModel2 = new DbModels2())
                {
                    dbModel2.Entry(login).State = EntityState.Modified;
                    dbModel2.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels2 dbModel2 = new DbModels2())
            {
                return View(dbModel2.Logins.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels2 dbModel2 = new DbModels2())
                {
                    Login login = dbModel2.Logins.Where(x => x.Id == id).FirstOrDefault();
                    dbModel2.Logins.Remove(login);
                    dbModel2.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}