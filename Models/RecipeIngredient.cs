using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class RecipeIngredient
    {
        public string RecipeIngredientID { get; set; }
        public string IngredientRef { get; set; }
        public double Quantity { get; set; }
        public double UpdatedQuantity { get; set; }
        public Unit Unit { get; set; }
        public string Notes { get; set; }
        public string RecipeRef { get; set; }
        public bool Optional { get; set; }
        public string Source { get; set; }
        public int RecipeRequired { get; set; }
        public double RecipeIngredientPrice
        {
            get
            {
                return RecipeRequired * Ingredient.Price;
            }
        }
        public string IngredientName
        {
            get
            {
                return Ingredient.Name;
            }
        }      
        public string Plural
        {
            get
            {
                if(Unit.Name != "")
                {
                    if(Quantity > 1)
                    {
                        return "s";
                    }
                }
                return string.Empty;
            }
        }
        public bool Selected { get; set; } = false;

        public string DisplayQuantity
        {
            get
            {
                return Quantity.ToString();
            }
        }

        public string FractionQuantity
        {
            get
            {
                string result = UpdatedQuantity.ToString();

                for(int i=2; i<=8; i++)
                {
                    if(UpdatedQuantity == Math.Floor(UpdatedQuantity))
                    {
                        return UpdatedQuantity.ToString();
                    }
                    else
                    {
                        if(Math.Abs((UpdatedQuantity * i) - Math.Round(UpdatedQuantity * i)) < 0.1)
                        {
                            if(UpdatedQuantity >= 0.9)
                            {
                                double whole = UpdatedQuantity;

                                if(Math.Abs(UpdatedQuantity - Math.Round(UpdatedQuantity)) < 0.1)
                                {
                                    whole = Math.Round(whole);
                                }
                                else
                                {
                                    whole = Math.Floor(whole);
                                }

                                double numerator = Math.Round((UpdatedQuantity - whole) * i);

                                if (numerator != 0)
                                {
                                    result = whole + " " + numerator + "/" + i;
                                }
                                else
                                {
                                    result = whole.ToString();
                                }
                                

                                return result; 

                                
                            }
                            else
                            {
                                return Math.Round(UpdatedQuantity * i) + "/" + i;
                            }                            
                        }
                    }
                }

                return result;
            }
        }
        
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(string recipeIngredientID) {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "SELECT * FROM RecipeIngredientView WHERE RecipeIngredientID = @RecipeIngredientID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeIngredientID", recipeIngredientID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecipeIngredientID = recipeIngredientID;
                            IngredientRef = reader["IngredientRef"].ToString();
                            Quantity = Convert.ToDouble(reader["Quantity"]);
                            UpdatedQuantity = Quantity;
                            Unit = Unit.GetUnit(Convert.ToInt32(reader["Unit"]));
                            Notes = reader["Notes"].ToString();
                            RecipeRef = reader["RecipeRef"].ToString();
                            Optional = Convert.ToBoolean(reader["Optional"]);
                            Source = reader["Source"].ToString();

                            Ingredient = new Ingredient {
                                IngredientID = reader["IngredientID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                ExternalID = reader["ExternalID"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                Quantity = Convert.ToDouble(reader["IngredientQuantity"]),
                                QuantityUnit = Unit.GetUnit(Convert.ToInt32(reader["QuantityUnit"])),
                                Source = reader["Source"].ToString(),
                                CartLink = reader["CartLink"].ToString(),
                                PhotoUrl = reader["PhotoURL"].ToString(),
                                InfoLink = reader["InfoLink"].ToString()
                            };

                            RecipeRequired = GetRecipeRequired();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddRecipeIngredientToDatabase()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "INSERT INTO RecipeIngredient(IngredientRef, Quantity, Unit, Notes, RecipeRef, Optional, Source) VALUES(@IngredientRef, @Quantity, @Unit, @Notes, @RecipeRef, @Optional, @Source) SELECT SCOPE_IDENTITY()";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IngredientRef", IngredientRef);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Unit", Unit.UnitID);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@RecipeRef", RecipeRef);
                    command.Parameters.AddWithValue("@Optional", Optional);
                    command.Parameters.AddWithValue("@Source", Source);

                    foreach (SqlParameter parameter in command.Parameters)
                    {
                        if (parameter.Value is null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }

                    //try
                    {
                        result = command.ExecuteScalar().ToString();
                    }
                    //catch(Exception exc)
                    {
                        //result = exc.Message;
                    }
                }
                connection.Close();
            }
            return result;
        }

        public string UpdateRecipeIngredient()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "UPDATE RecipeIngredient SET Quantity = @Quantity, Unit = @Unit, Notes = @Notes WHERE RecipeIngredientID = @RecipeIngredientID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Unit", Unit.UnitID);
                    command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@RecipeIngredientID", RecipeIngredientID);

                    try
                    {
                        command.ExecuteNonQuery();
                        result = RecipeIngredientID;
                    }
                    catch(Exception exc)
                    {
                        result = exc.Message;
                    }
                }
                connection.Close();
            }

            return result;
        }

        public string DeleteRecipeIngredient()
        {
            string result = "";

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "DELETE FROM RecipeIngredient WHERE RecipeIngredientID = @RecipeIngredientID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeIngredientID", RecipeIngredientID);

                    try
                    {
                        command.ExecuteNonQuery();
                        result = RecipeIngredientID;
                    }
                    catch (Exception exc)
                    {
                        result = exc.Message;
                    }
                }
                connection.Close();
            }

            return result;
        }

        public int GetRecipeRequired()
        {
            //try
            //{
                return Convert.ToInt32(Math.Ceiling(Quantity / Equivalency.GetEquivalency(Ingredient.Quantity, Ingredient.QuantityUnit.UnitID, Unit.UnitID)));
            //}
            //catch { }
            //return 0;
            
        }
        
    }
}