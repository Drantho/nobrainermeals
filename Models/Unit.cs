using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bp2.Models
{
    public class Unit
    {
        public string UnitID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Type { get; set; }
        
        public Unit() { }

        public static Unit GetUnit(int id)
        {
            return Units[id -1];
        }

        public static List<Unit> Units
        {
            get
            {
                List<Unit> units = new List<Unit>
                {
                    Unit.Teaspoon,
                    Unit.Tablespoon,
                    Unit.Cup,
                    Unit.FluidOunce,
                    Unit.Pint,
                    Unit.Quart,
                    Unit.Gallon,
                    Unit.Ounce,
                    Unit.Pound,
                    Unit.Gram,
                    Unit.Kilogram,
                    Unit.Milliliter,
                    Unit.Liter,
                    Unit.Blank,
                    Unit.Sprinkle,
                    Unit.Dash,
                    Unit.Pinch,
                    Unit.Sprig
                };
                return units;
            }
        }

        public static Unit Teaspoon
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "1",
                    Name = "Teaspoon",
                    Abbreviation = "t",
                    Type = "Volume"
                };
                return unit;
            }
        }

        public static Unit Tablespoon
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "2",
                    Name = "Tablespoon",
                    Abbreviation = "T",
                    Type = "Volume"
                };
                return unit;
            }
        }

        public static Unit Cup
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "3",
                    Name = "Cup",
                    Abbreviation = "C",
                    Type = "Volume"
                };

                return unit;
            }
        }

        public static Unit FluidOunce
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "4",
                    Name = "Fluid Ounce",
                    Abbreviation = "fl oz",
                    Type = "Volume"
                };

                return unit;
            }
        }

        public static Unit Pint
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "5",
                    Name = "Pint",
                    Abbreviation = "pt",
                    Type = "Volume"
                };

                return unit;
            }
        }

        public static Unit Quart
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "6",
                    Name = "Quart",
                    Abbreviation = "qt",
                    Type = "Volume"
                };

                return unit;
            }
        }

        public static Unit Gallon
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "7",
                    Name = "Gallon",
                    Abbreviation = "gal",
                    Type = "Volume"
                };

                return unit;
            }
        }
        
        public static Unit Ounce
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "8",
                    Name = "Ounce",
                    Abbreviation = "oz.",
                    Type = "Mass/Weight"
                };

                return unit;
            }
        }

        public static Unit Pound
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "9",
                    Name = "Pound",
                    Abbreviation = "lb",
                    Type = "Mass/Weight"
                };

                return unit;
            }
        }

        public static Unit Gram
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "10",
                    Name = "Gram",
                    Abbreviation = "g",
                    Type = "Mass/Weight"
                };

                return unit;
            }
        }

        public static Unit Kilogram
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "11",
                    Name = "Kilogram",
                    Abbreviation = "kg",
                    Type = "Mass/Weight"
                };

                return unit;
            }
        }

        public static Unit Milliliter
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "12",
                    Name = "Milliliter",
                    Abbreviation = "mL",
                    Type = "Volume"
                };

                return unit;
            }
        }

        public static Unit Liter
        {
            get
            {
                Unit unit = new Unit
                {
                    UnitID = "13",
                    Name = "Liter",
                    Abbreviation = "L",
                    Type = "Volume"
                };

                return unit;
            }
        }        

        public static Unit Blank
        {
            get
            {
                return new Unit
                {
                    UnitID = "14",
                    Name = "",
                    Abbreviation = "",
                    Type = "Count",
                };
            }
        }

        public static Unit Sprinkle
        {
            get
            {
                return new Unit
                {
                    UnitID = "15",
                    Name = "Sprinkle",
                    Abbreviation = "Sprinkle",
                    Type = "Volume",                    
                };
            }
        }

        public static Unit Dash
        {
            get
            {
                return new Unit
                {
                    UnitID = "16",
                    Name = "Dash",
                    Abbreviation = "Dash",
                    Type = "Volume",
                };
            }
        }

        public static Unit Pinch
        {
            get
            {
                return new Unit
                {
                    UnitID = "17",
                    Name = "Pinch",
                    Abbreviation = "Pinch",
                    Type = "Volume",
                };
            }
        }

        public static Unit Sprig
        {
            get
            {
                return new Unit
                {
                    UnitID = "18",
                    Name = "Sprig",
                    Abbreviation = "Sprig",
                    Type = "Mass",
                };
            }
        }

    }
}