using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tyrannosaurus.Core.Domain;
using Tyrannosaurus.UI.Models;

namespace Tyrannosaurus.UI.Helpers
{
    public class TyrannosaurusDbInitializer : DropCreateDatabaseAlways<TyrannosaurusEntities>
    {

        protected  override void Seed(TyrannosaurusEntities context)
        {
            context.Observees.Add(new Observee {Name = "Jad Goss" });
            context.Observees.Add(new Observee {Name = "Melinda Goss"});

            context.Observations.Add(new Observation
                {
                    Comment = "some comments",
                    Height = 50,
                    ObservationDate= DateTime.Parse("2010-09-20"),
                    Observee = new Observee{Name = "Corwin Goss"},
                    Tyrosine = 300,
                    Phenylalanine = 40,
                    Weight = 15

                });
        }

    }
}