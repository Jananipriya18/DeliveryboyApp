using System;
using crudapp.Models;
using NUnit.Framework;
using System.Reflection;

namespace TestProject{


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

        private Type GetFurnitureType()
        {
            string assemblyName = "crudapp";
            string typeName = "crudapp.Models.Furniture";
            Assembly assembly = Assembly.Load(assemblyName);
            return assembly.GetType(typeName);
        }

        [Test]
        public void IdShouldBeInteger()
        {
            Type furnitureType = GetFurnitureType();
            PropertyInfo idProperty = furnitureType.GetProperty("id");
            Assert.IsNotNull(idProperty, "Id property not found");
            Assert.AreEqual(typeof(int), idProperty.PropertyType, "Id should be of type int");
        }

        [Test]
        public void ProductShouldBeString()
        {
            Type furnitureType = GetFurnitureType();
            PropertyInfo productProperty = furnitureType.GetProperty("product");
            Assert.IsNotNull(productProperty, "Product property not found");
            Assert.AreEqual(typeof(string), productProperty.PropertyType, "Product should be of type string");
        }

        [Test]
        public void DescriptionShouldBeString()
        {
            Type furnitureType = GetFurnitureType();
            PropertyInfo descriptionProperty = furnitureType.GetProperty("description");
            Assert.IsNotNull(descriptionProperty, "Description property not found");
            Assert.AreEqual(typeof(string), descriptionProperty.PropertyType, "Description should be of type string");
        }

        [Test]
        public void MaterialShouldBeString()
        {
            Type furnitureType = GetFurnitureType();
            PropertyInfo materialProperty = furnitureType.GetProperty("material");
            Assert.IsNotNull(materialProperty, "Material property not found");
            Assert.AreEqual(typeof(string), materialProperty.PropertyType, "Material should be of type string");
        }

        [Test]
        public void CostShouldBeInteger()
        {
            Type furnitureType = GetFurnitureType();
            PropertyInfo costProperty = furnitureType.GetProperty("cost");
            Assert.IsNotNull(costProperty, "Cost property not found");
            Assert.AreEqual(typeof(int), costProperty.PropertyType, "Cost should be of type int");
        }
}
}

https://github.com/Jananipriya18/ADO.NET---crudapp.git