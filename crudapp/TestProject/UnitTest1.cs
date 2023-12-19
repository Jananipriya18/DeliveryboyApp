using System;
using crudapp.Models;
using NUnit.Framework;
using System.Reflection;

namespace TestProject


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