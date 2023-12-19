using System;
using crudapp.Models;
using NUnit.Framework;
using System.Reflection;
using Xunit;
using Microsoft.EntityFrameworkCore;
using crudapp.Controllers;
using crudapp.Models;
using System.Linq;




namespace TestProject

{
    public class FurnitureControllerTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public FurnitureControllerTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CRUDOperations")
                .Options;
        }

        [Fact]
        public void Setup_DatabaseIsInitialized()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Assert
                Assert.NotNull(context);
                Assert.True(context.Database.EnsureCreated());
            }
        }

        [Theory]
        [InlineData("Test Product", "Test Description", "Test Material", 100)]
        public void Create_InsertsValuesIntoDatabase(string product, string description, string material, int cost)
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new FurnitureController(context);
                var newFurniture = new Furniture
                {
                    product = product,
                    description = description,
                    material = material,
                    cost = cost
                };

                // Act
                controller.Create(newFurniture);

                // Assert
                var insertedFurniture = context.Furniture.FirstOrDefault();
                Assert.NotNull(insertedFurniture);
                Assert.Equal(product, insertedFurniture.product);
                Assert.Equal(description, insertedFurniture.description);
                Assert.Equal(material, insertedFurniture.material);
                Assert.Equal(cost, insertedFurniture.cost);
            }
        }
    }
}

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
            public void FurnitureController_CreateMethodExists()
            {
                string assemblyName = "crudapp";
                string typeName = "crudapp.Controllers.FurnitureController";
                Assembly assembly = Assembly.Load(assemblyName);
                Type controllerType = assembly.GetType(typeName);

                // Specify the parameter types for the Create method
                Type[] parameterTypes = new Type[] { typeof(Furniture) };

                MethodInfo createMethod = controllerType.GetMethod("Create", parameterTypes);
                Assert.IsNotNull(createMethod);
            }

            [Test]
            public void FurnitureController_UpdateMethodExists()
            {
                string assemblyName = "crudapp";
                string typeName = "crudapp.Controllers.FurnitureController";
                Assembly assembly = Assembly.Load(assemblyName);
                Type controllerType = assembly.GetType(typeName);

                // Specify the parameter types for the Update method
                Type[] parameterTypes = new Type[] { typeof(Furniture) };

                MethodInfo updateMethod = controllerType.GetMethod("Update", parameterTypes);
                Assert.IsNotNull(updateMethod);
            }


        [Test]
        public void FurnitureController_ReadMethodExists()
        {
            string assemblyName = "crudapp";
            string typeName = "crudapp.Controllers.FurnitureController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            
            MethodInfo readMethod = controllerType.GetMethod("Index");
            Assert.IsNotNull(readMethod);
        }

        // [Test]
        // public void FurnitureController_UpdateMethodExists()
        // {
        //     string assemblyName = "crudapp";
        //     string typeName = "crudapp.Controllers.FurnitureController";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type controllerType = assembly.GetType(typeName);
            
        //     MethodInfo updateMethod = controllerType.GetMethod("Update");
        //     Assert.IsNotNull(updateMethod);
        // }

        [Test]
        public void FurnitureController_DeleteMethodExists()
        {
            string assemblyName = "crudapp";
            string typeName = "crudapp.Controllers.FurnitureController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            
            MethodInfo deleteMethod = controllerType.GetMethod("Delete");
            Assert.IsNotNull(deleteMethod);
        }

}