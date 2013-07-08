using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tyrannosaurus.Core.Domain;
using Tyrannosaurus.UI.Controllers;
using Tyrannosaurus.UI.Services;
using Tyrannosaurus.UI.Models;
using Unity.Mvc3;

namespace Tyrannosaurus.Tests.Controllers
{
    [TestClass]
    public class ObservationsControllerTest
    {

        private ObservationsController _controller;
        private Mock<IObservationService> _serviceMock;

        [TestInitialize]
        public void SetupContext()
        {
            // Arrange
            _serviceMock = new Mock<IObservationService>();

        }

        [TestMethod]
        public void ReturnsANewObservation()
        {
            //Arrange
            _controller = new ObservationsController(_serviceMock.Object);

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreatesANewObservation()
        {
            //Arrange
            _controller = new ObservationsController(_serviceMock.Object);

            var observation = new Observation()
                {
                    ObservationDate = DateTime.Now
                };

            // Act
            var result = _controller.Create(observation) as ViewResult;

            // Assert
            _serviceMock.Verify(x => x.AddObservation(observation), Times.Once());
        }

        [TestMethod]
        public void ShouldRetrieveObservationById()
        {
            // Arrange
            var expectedObservation = new Observation { ObservationId = 123 };

            // Act
            _serviceMock.Setup(x => x.GetObservation(expectedObservation.ObservationId)).Returns(expectedObservation);
            _controller = new ObservationsController(_serviceMock.Object);
            dynamic result = _controller.Details(expectedObservation.ObservationId);

            // Assert
            Assert.AreSame(expectedObservation, result.Model);
        }

        [TestMethod]
        public void ReturnsNewObservationList_ToListView()
        {
            //Arrange
            _controller = new ObservationsController(_serviceMock.Object);

            //Act
            var result = _controller.GetObservations("") as PartialViewResult;
            var model = result.Model as List<ObservationsList>;

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(model, typeof(Observation));
        }
    }


}
