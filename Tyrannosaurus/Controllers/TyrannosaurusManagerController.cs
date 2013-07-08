using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyrannosaurus.Core.Domain;
using Tyrannosaurus.UI.Models;

namespace Tyrannosaurus.UI.Controllers
{
    public class TyrannosaurusManagerController : Controller
    {
        private TyrannosaurusEntities db = new TyrannosaurusEntities();

        //
        // GET: /TyrannosaurusManager/

        public ActionResult Index()
        {
            var observations = db.Observations.Include(o => o.Observee);
            return View(observations.ToList());
        }

        //
        // GET: /TyrannosaurusManager/Details/5

        public ActionResult Details(int id = 0)
        {
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);
        }

        //
        // GET: /TyrannosaurusManager/Create

        public ActionResult Create()
        {
            ViewBag.ObserveeId = new SelectList(db.Observees, "ObserveeId", "Name");
            return View();
        }

        //
        // POST: /TyrannosaurusManager/Create

        [HttpPost]
        public ActionResult Create(Observation observation)
        {
            if (ModelState.IsValid)
            {
                db.Observations.Add(observation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObserveeId = new SelectList(db.Observees, "ObserveeId", "Name", observation.ObserveeId);
            return View(observation);
        }

        //
        // GET: /TyrannosaurusManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObserveeId = new SelectList(db.Observees, "ObserveeId", "Name", observation.ObserveeId);
            return View(observation);
        }

        //
        // POST: /TyrannosaurusManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Observation observation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(observation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObserveeId = new SelectList(db.Observees, "ObserveeId", "Name", observation.ObserveeId);
            return View(observation);
        }

        //
        // GET: /TyrannosaurusManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);
        }

        //
        // POST: /TyrannosaurusManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Observation observation = db.Observations.Find(id);
            db.Observations.Remove(observation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}