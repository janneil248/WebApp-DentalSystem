using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using MCOSMILE.Models;

namespace MCOSMILE.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {

           using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Patients.ToList());
            }
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View( dbModel.Patients.Where(x => x.Id == id).FirstOrDefault());
            }
               
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Patients.Add(patient);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Patients.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient patient)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(patient).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Patients.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    Patient patient = dbModel.Patients.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Patients.Remove(patient);
                    dbModel.SaveChanges();
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
