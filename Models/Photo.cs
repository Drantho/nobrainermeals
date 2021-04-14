using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bp2.Models
{
    public class Photo
    {
        public string Thumb { get; set; }
        public string Full { get; set; }
        public string Type { get; set; }
        public string ID { get; set; }
        public int Number { get; set; }
        public Recipe Recipe { get; set; }

        public Photo(string type, string id, int number, Recipe recipe = null)
        {
            Type = type;
            ID = id;
            Number = number;
            Recipe = recipe;
            Thumb = "../images/" + type + "-" + id + "-" + number + "Thumb.jpg";
            Full = "../images/" + type + "-" + id + "-" + number + "Full.jpg";
        }
    }
}