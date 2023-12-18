// tableCreation

using System;
 public class Furniture
 {
     public int id { get; set; } // Unique identifier for each flight
     public string product { get; set; }
     public string description { get; set; }
     public string material { get; set; }
     public int cost { get; set; }
 }

 INSERT INTO Flights (id, product, description, material, cost)
VALUES 
    (5, 'Chair', 'Comfortable chair for home or office use', 'Wood', 80),
    (6, 'Sofa', 'Large sofa for living room', 'Fabric', 300),
    (7, 'Table', 'Modern coffee table', 'Glass', 150),
    (8, 'Bookshelf', 'Wooden bookshelf with multiple shelves', 'Wood', 200);