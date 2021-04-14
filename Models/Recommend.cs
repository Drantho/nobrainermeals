using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class Recommend
    {
        public string RecommendID { get; set; }
        public string RecipeID1 { get; set; }
        public string RecipeID2 { get; set; }

        public Recommend() { }

        public Recommend(string recommendID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM Recommend WHERE RecommendID = @RecommendID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecommendID", recommendID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecommendID = recommendID;
                            RecipeID1 = reader["RecipeID1"].ToString();
                            RecipeID2 = reader["RecipeID2"].ToString();
                        }
                    }
                }
                connection.Close();
            }

        }

        public string AddRecommendToDatabase()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "INSERT INTO Recommend(RecipeID1, RecipeID2) VALUES(@RecipeID1, @RecipeID2) SELECT SCOPE_IDENTITY()";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeID1", RecipeID1);
                    command.Parameters.AddWithValue("@RecipeID2", RecipeID2);

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