using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class RecipeEquipment
    {
        public string RecipeEquipmentID { get; set; }
        public string RecipeRef { get; set; }
        public string EquipmentRef { get; set; }
        public string Notes { get; set; }

        public Recipe Recipe { get; set; }
        public Equipment Equipment { get;set; }

        public RecipeEquipment() { }

        public RecipeEquipment(string recipeEquipmentID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM RecipeEquipment WHERE RecipeEquipmentID = @RecipeEquipmentID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeEquipmentID", recipeEquipmentID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecipeEquipmentID = recipeEquipmentID;
                            RecipeRef = reader["RecipeRef"].ToString();
                            EquipmentRef = reader["EquipmentRef"].ToString();
                            Notes = reader["Notes"].ToString();
                            Recipe = new Recipe(reader["RecipeID"].ToString());
                            Equipment = new Equipment(reader["EquipmentID"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
        }

        public string AddRecipeEquipmentToDatabase()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "INSERT INTO RecipeEquipment(RecipeRef, EquipmentRef, Notes) VALUES(@RecipeRef, @EquipmentRef, @Notes) SELECT SCOPE_IDENTITY()";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeRef", RecipeRef);
                    command.Parameters.AddWithValue("@EquipmentRef", EquipmentRef);
                    command.Parameters.AddWithValue("@Notes", Notes);

                    foreach (SqlParameter parameter in command.Parameters)
                    {
                        if (parameter.Value == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                    }

                    try
                    {
                        result = command.ExecuteScalar().ToString();
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
    }
}