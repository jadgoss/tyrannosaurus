using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tyrannosaurus.Core.Domain;
using Tyrannosaurus.UI.Services;
using Tyrannosaurus.UI.Models;

namespace Tyrannosaurus.UI.Services
{
    public class ObservationService : IObservationService   
    {
        private TyrannosaurusEntities db = new TyrannosaurusEntities();

        public IList<string> GetObserveeNames()
        {
            var observees = from observee in this.db.Observees 
                            select observee.Name;
 
            return observees.ToList();
        }

        public IList<Observee> GetObservees(int max)
        {
            return max > 0 ? this.db.Observees.Take(max).ToList() : this.db.Observees.ToList();
        }

        public Observee GetObserveeByName(string name)
        {
            var observee = this.db.Observees.Include("Observations").Single(o => o.Name == name);
 
            return observee;
        }

        public Observation GetObservation(int id)
        {
            var observation = this.db.Observations.Single(o => o.ObservationId == id);

            return observation;
        }

        // TODO: Add in max parameter
        public IList<Observation> GetObservationsByObserveeId(int observeeId)
        {
            var observations =  this.db.Observations.Where(o => o.ObserveeId == observeeId);

            return observations.ToList();
        }

        // TODO: Add in error handling
        public void AddObservation(Observation observation)
        {
            db.Observations.Add(observation);
            db.SaveChanges();
        }

        // TODO: Add in error handling
        public void EditObservation(Observation observation)
        {
            db.Entry(observation).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}