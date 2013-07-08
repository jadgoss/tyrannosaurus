using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Tyrannosaurus.UI.Services;
using Tyrannosaurus.UI.Controllers;

namespace Tyrannosaurus.UI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IObservationService, ObservationService>();
            container.RegisterType<IController, ObservationsController>("Observation");

            return container;
        }

    }
}