using System;
using crudapp.Models;
using NUnit.Framework;
using System.Reflection;


namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

        [Test]
        public void Furniture_ClassExists()
        {
            string assemblyName = "crudapp";
            string typeName = "crudapp.Models.Furniture";
            Assembly assembly = Assembly.Load(assemblyName);
            Type rideType = assembly.GetType(typeName);
            Assert.IsNotNull(rideType);
            var ride = Activator.CreateInstance(rideType);
            Assert.IsNotNull(ride);
        }

        [Test]
        public void FurnitureController_ClassExists()
        {
            string assemblyName = "crudapp";
            string typeName = "crudapp.Controllers.FurnitureController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            Assert.IsNotNull(controllerType);
            var controller = Activator.CreateInstance(controllerType);
            Assert.IsNotNull(controller);
        }


        [Test]
        public void Furniture_Description_ShouldNotBeEmpty()
        {
            // Arrange
            var furniture = new Furniture();

            // Act
            furniture.description = "A comfortable sofa";

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(furniture.description));
        }

        [Test]
        public void Furniture_Material_ShouldBeSetCorrectly()
        {
            // Arrange
            var furniture = new Furniture();

            // Act
            furniture.material = "Wood";

            // Assert
            Assert.AreEqual("Wood", furniture.material);
        }

        [Test]
        public void Furniture_Cost_ShouldBePositive()
        {
            // Arrange
            var furniture = new Furniture();

            // Act
            furniture.cost = 100;

            // Assert
            Assert.IsTrue(furniture.cost > 0);
        }
}