using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCOSMILE.Models;

namespace MCOSMILE.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            using (DbModels1 dbModel1 = new DbModels1())
            {
                return View(dbModel1.Inventories.ToList());
            }
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels1 dbModel1 = new DbModels1())
            {
                return View(dbModel1.Inventories.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(Inventory inventory)
        {
            try
            {
                using (DbModels1 dbModel1 = new DbModels1())
                {
                    dbModel1.Inventories.Add(inventory);
                    dbModel1.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels1 dbModel1 = new DbModels1())
            {
                return View(dbModel1.Inventories.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inventory inventory)
        {
            try
            {
                using (DbModels1 dbModel1 = new DbModels1())
                {
                    dbModel1.Entry(inventory).State = EntityState.Modified;
                    dbModel1.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels1 dbModel1 = new DbModels1())
            {
                return View(dbModel1.Inventories.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels1 dbModel1 = new DbModels1())
                {
                    Inventory inventory = dbModel1.Inventories.Where(x => x.Id == id).FirstOrDefault();
                    dbModel1.Inventories.Remove(inventory);
                    dbModel1.SaveChanges();
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
