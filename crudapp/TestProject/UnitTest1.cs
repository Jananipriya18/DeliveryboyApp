using System;
using crudapp.Models;

namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
        public void Furniture_Id_ShouldBeSetCorrectly()
        {
            // Arrange
            var furniture = new Furniture();

            // Act
            furniture.id = 1;

            // Assert
            Assert.AreEqual(1, furniture.id);
        }

        [Test]
        public void Furniture_Product_ShouldNotBeNull()
        {
            // Arrange
            var furniture = new Furniture();

            // Act
            furniture.product = "Chair";

            // Assert
            Assert.IsNotNull(furniture.product);
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