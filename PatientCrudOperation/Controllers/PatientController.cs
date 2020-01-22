using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientCrudOperation.Models;

namespace PatientCrudOperation.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            using (DbModels db = new DbModels())
            {
                return View(db.Patients.ToList());
            }
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels db = new DbModels())
            {
                return View(db.Patients.Where(x => x.PatientId == id).FirstOrDefault());
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
                using (DbModels db = new DbModels())
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                }

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
            using (DbModels db = new DbModels())
            {
                return View(db.Patients.Where(x => x.PatientId == id).FirstOrDefault());
            }
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient patient)
        {
            try
            {
                using (DbModels db = new DbModels())
                {

                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                }

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
            using (DbModels db = new DbModels())
            {
                return View(db.Patients.Where(x => x.PatientId == id).FirstOrDefault());
            }
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Patient patient)
        {
            try
            {
                using (DbModels db = new DbModels())
                {
                    patient = db.Patients.Where(x => x.PatientId == id).FirstOrDefault();
                    db.Patients.Remove(patient);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
