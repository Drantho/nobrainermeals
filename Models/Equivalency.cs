using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bp2.Models
{
    public class Equivalency
    {
        public double Amount1 { get
            {
                return 1;
            }
        }
        public double Amount2 { get; set; }

        public Unit Unit1 { get; set; }
        public Unit Unit2 { get; set; }

        public Equivalency() { }

        public static List<Equivalency> Equivalencies
        {
            get
            {
                List<Equivalency> equivalencies = new List<Equivalency>
                {
                    new Equivalency
                    {
                        Unit1 = Unit.Teaspoon ,
                        Amount2 = 1,
                        Unit2 = Unit.Teaspoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Teaspoon,
                        Amount2 = 0.33333,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Teaspoon,
                        Amount2 = 4.92892,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon,
                        Amount2 = 3,
                        Unit2 = Unit.Teaspoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon,
                        Amount2 = 1,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon,
                        Amount2 = 0.0625,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon,
                        Amount2 = 0.5,
                        Unit2 = Unit.FluidOunce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon,
                        Amount2 = 14.7868,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 1,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 16,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 0.5,
                        Unit2 = Unit.Pint
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 0.25,
                        Unit2 = Unit.Quart
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 0.125,
                        Unit2 = Unit.Gallon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 8,
                        Unit2 = Unit.FluidOunce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 240,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Cup,
                        Amount2 = 0.24,
                        Unit2 = Unit.Liter
                    },

                    new Equivalency
                    {
                        Unit1 = Unit.FluidOunce,
                        Amount2 = 1,
                        Unit2 = Unit.FluidOunce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.FluidOunce,
                        Amount2 = 2,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.FluidOunce,
                        Amount2 = 0.125,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.FluidOunce,
                        Amount2 = 29.5735,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.FluidOunce,
                        Amount2 = 0.0295735,
                        Unit2 = Unit.Liter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pint,
                        Amount2 = 1,
                        Unit2 = Unit.Pint
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pint,
                        Amount2 = 2,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pint,
                        Amount2 = 0.5,
                        Unit2 = Unit.Quart
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pint,
                        Amount2 = 473.176,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pint,
                        Amount2 = 0.473176,
                        Unit2 = Unit.Liter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Quart,
                        Amount2 = 1,
                        Unit2 = Unit.Quart
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Quart,
                        Amount2 = 4,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Quart,
                        Amount2 = 2,
                        Unit2 = Unit.Pint
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Quart,
                        Amount2 = 0.25,
                        Unit2 = Unit.Gallon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Quart,
                        Amount2 = 0.946353,
                        Unit2 = Unit.Liter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Quart,
                        Amount2 = 946.353,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gallon,
                        Amount2 = 1,
                        Unit2 = Unit.Gallon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gallon,
                        Amount2 = 16,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gallon,
                        Amount2 = 8,
                        Unit2 = Unit.Pint
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gallon,
                        Amount2 = 4,
                        Unit2 = Unit.Quart
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gallon,
                        Amount2 = 3.78541,
                        Unit2 = Unit.Liter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gallon,
                        Amount2 = 3785.41,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Ounce,
                        Amount2 = 1,
                        Unit2 = Unit.Ounce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Ounce,
                        Amount2 = 0.0625,
                        Unit2 = Unit.Pound
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Ounce,
                        Amount2 = 28.3495,
                        Unit2 = Unit.Gram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Ounce,
                        Amount2 = 0.02835,
                        Unit2 = Unit.Kilogram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pound,
                        Amount2 = 1,
                        Unit2 = Unit.Pound
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pound,
                        Amount2 = 16,
                        Unit2 = Unit.Ounce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pound,
                        Amount2 = 453.592,
                        Unit2 = Unit.Gram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pound,
                        Amount2 = 0.4535,
                        Unit2 = Unit.Kilogram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gram,
                        Amount2 = 1,
                        Unit2 = Unit.Gram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gram,
                        Amount2 = 0.035274,
                        Unit2 = Unit.Ounce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gram,
                        Amount2 = 0.0022,
                        Unit2 = Unit.Pound
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gram,
                        Amount2 = .001,
                        Unit2 = Unit.Kilogram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Kilogram,
                        Amount2 = 1,
                        Unit2 = Unit.Kilogram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Kilogram,
                        Amount2 = 35.274,
                        Unit2 = Unit.Ounce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Kilogram,
                        Amount2 = 2.204,
                        Unit2 = Unit.Pound
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Kilogram,
                        Amount2 = 1000,
                        Unit2 = Unit.Gram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter,
                        Amount2 = 1,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter,
                        Amount2 = 0.2028,
                        Unit2 = Unit.Teaspoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter,
                        Amount2 = 0.001,
                        Unit2 = Unit.Liter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter,
                        Amount2 = 0.067628,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter ,
                        Amount2 = 0.033814,
                        Unit2 = Unit.FluidOunce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter ,
                        Amount2 = 0.00422675,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter ,
                        Amount2 = 0.00211338,
                        Unit2 = Unit.Pint
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter ,
                        Amount2 = 0.00105669,
                        Unit2 = Unit.Quart
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Milliliter ,
                        Amount2 = 0.000264172,
                        Unit2 = Unit.Gallon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter,
                        Amount2 = 1,
                        Unit2 = Unit.Liter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 1000,
                        Unit2 = Unit.Milliliter
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 67.628,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 33.814,
                        Unit2 = Unit.FluidOunce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 4.1666,
                        Unit2 = Unit.Cup
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 2.11338,
                        Unit2 = Unit.Pint
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 1.05669,
                        Unit2 = Unit.Quart
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Liter ,
                        Amount2 = 0.264172,
                        Unit2 = Unit.Gallon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Teaspoon ,
                        Amount2 = 8,
                        Unit2 = Unit.Pinch
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Teaspoon ,
                        Amount2 = 8,
                        Unit2 = Unit.Dash
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Teaspoon ,
                        Amount2 = 8,
                        Unit2 = Unit.Sprinkle
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon ,
                        Amount2 = 24,
                        Unit2 = Unit.Pinch
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon ,
                        Amount2 = 24,
                        Unit2 = Unit.Dash
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Tablespoon ,
                        Amount2 = 24,
                        Unit2 = Unit.Sprinkle
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Sprinkle,
                        Amount2 = 1,
                        Unit2 = Unit.Sprinkle
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Sprinkle ,
                        Amount2 = 0.125,
                        Unit2 = Unit.Teaspoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Sprinkle ,
                        Amount2 = 0.0417,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Dash,
                        Amount2 = 1,
                        Unit2 = Unit.Dash
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Dash ,
                        Amount2 = 0.125,
                        Unit2 = Unit.Teaspoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Dash ,
                        Amount2 = 0.0417,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pinch,
                        Amount2 = 1,
                        Unit2 = Unit.Pinch
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pinch ,
                        Amount2 = 0.125,
                        Unit2 = Unit.Teaspoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Pinch ,
                        Amount2 = 0.0417,
                        Unit2 = Unit.Tablespoon
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Blank,
                        Amount2 = 1,
                        Unit2 = Unit.Blank
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Sprig,
                        Amount2 = 0.083,
                        Unit2 = Unit.Ounce
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Ounce,
                        Amount2 = 12,
                        Unit2 = Unit.Sprig
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Sprig,
                        Amount2 = 2.35,
                        Unit2 = Unit.Gram
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Gram,
                        Amount2 = 0.43,
                        Unit2 = Unit.Sprig
                    },
                    new Equivalency
                    {
                        Unit1 = Unit.Sprig,
                        Amount2 = 1,
                        Unit2 = Unit.Sprig
                    }

                };

                return equivalencies;
            }
        }

        public static double GetEquivalency(double amount1, string unitID1, string unitID2)
        {

            return GetEquivalency(unitID1, unitID2).Amount2 * amount1;
            
        }

        public static Equivalency GetEquivalency(string unitID1, string unitID2)
        {
            foreach(Equivalency equivalency in Equivalencies)
            {
                if(equivalency.Unit1.UnitID == unitID1 && equivalency.Unit2.UnitID == unitID2)
                {
                    return equivalency;
                }
            }

            return new Equivalency();
        }
    }
}