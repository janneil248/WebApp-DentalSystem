using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCOSMILE.Models;

namespace MCOSMILE.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {

            using (DbModels3 dbModel3 = new DbModels3())
            {
               
                return View(dbModel3.Appointments.ToList());
            }
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels3 dbModel3 = new DbModels3())
            {
                return View(dbModel3.Appointments.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            DbModels sd = new DbModels();
            ViewBag.Patients = new SelectList(sd.Patients, "Name", "Name");
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            try
            {
                using (DbModels3 dbModel3 = new DbModels3())
                {
                    DbModels sd = new DbModels();
                    ViewBag.Patients = new SelectList(sd.Patients, "Id", "Name");
                    dbModel3.Appointments.Add(appointment);
                    dbModel3.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels3 dbModel3 = new DbModels3())
            {
                return View(dbModel3.Appointments.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Appointment appointment)
        {
            try
            {
                using (DbModels3 dbModel3 = new DbModels3())
                {
                    dbModel3.Entry(appointment).State = EntityState.Modified;
                    dbModel3.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels3 dbModel3 = new DbModels3())
            {
                return View(dbModel3.Appointments.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels3 dbModel3 = new DbModels3())
                {
                    Appointment appointment = dbModel3.Appointments.Where(x => x.Id == id).FirstOrDefault();
                    dbModel3.Appointments.Remove(appointment);
                    dbModel3.SaveChanges();
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
