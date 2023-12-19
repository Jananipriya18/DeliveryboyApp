// @model bookapp.Models.Furniture

using System;

namespace crudapp.Models
{
    public class Furniture
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int language { get; set; }
    }
}


