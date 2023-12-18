// @model crudapp.Models.Furniture

using System;

namespace crudapp.Models
{
    public class Furniture
    {
        public int id { get; set; } 
        public string product { get; set; }
        public string description { get; set; }
        public string material { get; set; }
        public int cost { get; set; }
    }
}


