using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyrannosaurus.Core.Domain;
using Tyrannosaurus.UI.Models;
using AutoMapper;
using Tyrannosaurus.UI.Services;

namespace Tyrannosaurus.UI.Controllers
{
    public class ObservationsController : Controller
    {

        //         private TyrannosaurusEntities db = new TyrannosaurusEntities();

        private IObservationService service;

        public ObservationsController(IObservationService service)
        {
            this.service = service;
        }

        //
        // GET: /Observations/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Observations/GetObservations/

        public PartialViewResult GetObservations(string mode = "charts")
        {

            // var observations = db.Observations.Include(o => o.Observee);

            // FIXME: Hard coded ID value
            var observations = this.service.GetObservationsByObserveeId(1);

            Mapper.CreateMap<Observation, ObservationsList>();

            var observationList = Mapper.Map<IList<Observation>, IList<ObservationsList>>(observations);

            return PartialView(mode == "grid" ? "_ObservationGrid" : "_ObservationChart", observationList);
        }

        //
        // GET: /Observations/Create

        public ViewResult Create()
        {
            var observation = new Observation()
                {   
                    ObservationDate = DateTime.Now
                };

            return View(new ObservationFormViewModel(observation));
        }

        //
        // POST: /Observations/Create

        [HttpPost]
        public ActionResult Create(Observation observation)
        {
            if (ModelState.IsValid)
            {
                this.service.AddObservation(observation);

                return RedirectToAction("Details", new { id = observation.ObservationId });
            }

            return View(new ObservationFormViewModel(observation));
        }

        //
        // GET: /Observations/Detail

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            var observation = this.service.GetObservation(id);

            // Observation observation = db.Observations.Find(id);

            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(observation);   
        }
    
        //
        // GET: /Observations/Edit

        public ActionResult Edit(int id = 0)
        {
            // Observation observation = db.Observations.Find(id);

            var observation = this.service.GetObservation(id);

            if (observation == null)
            {
                return HttpNotFound();
            }
            return View(new ObservationFormViewModel(observation));
        }

        //
        // POST: /Observations/Edit

        [HttpPost]
        public ActionResult Edit(Observation observation)
        {
            if (ModelState.IsValid)
            {
                this.service.EditObservation(observation);

                return RedirectToAction("Details",new {id = observation.ObservationId});
            }

            return View(new ObservationFormViewModel(observation));
        }

        protected override void Dispose(bool disposing)
        {
            this.service.Dispose();
            base.Dispose(disposing);
        }
    }
}
