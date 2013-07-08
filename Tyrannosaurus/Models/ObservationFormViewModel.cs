using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tyrannosaurus.Core.Domain;

namespace Tyrannosaurus.UI.Models
{
    public class ObservationFormViewModel
    {
        private TyrannosaurusEntities db = new TyrannosaurusEntities();

        public Observation Observation { get; private set; }
        public SelectList Observees { get; private set; }

        public ObservationFormViewModel(Observation observation)
        {
            Observation = observation;
            Observees = new SelectList(db.Observees, "ObserveeId", "Name");

        }
    }
} 