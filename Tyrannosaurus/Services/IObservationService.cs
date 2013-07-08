using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tyrannosaurus.Core.Domain;

namespace Tyrannosaurus.UI.Services
{
    public interface IObservationService
    {
        IList<string> GetObserveeNames();

        IList<Observee> GetObservees(int max = 0);

        Observee GetObserveeByName(string name);

        Observation GetObservation(int id);

        IList<Observation> GetObservationsByObserveeId(int observeeId);

        void AddObservation(Observation observation);

        void EditObservation(Observation observation);

        void Dispose();
    }
}