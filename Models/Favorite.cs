using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class Favorite
    {
        public string FavoriteID { get; set; }
        public string RecipeRef { get; set; }
        public string UserRef { get; set; }
        public DateTime DateAdded { get; set; }
        public string Notes { get; set; }

        public Favorite() { }

        public Favorite(string favoriteID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM Favorite WHERE FavoriteID = @FavoriteID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FavoriteID", favoriteID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FavoriteID = favoriteID;
                            RecipeRef = reader["RecipeRef"].ToString();
                            UserRef = reader["UserRef"].ToString();
                            DateAdded = Convert.ToDateTime(reader["DateAdded"]);
                            Notes = reader["Notes"].ToString();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddFavoriteToDatabase()
        {
            string result = "";

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "INSERT INTO Favorite(RecipeRef, UserRef, DateAdded, Notes) VALUES(@RecipeRef, @UserRef, @DateAdded, @Notes) SELECT SCOPE_IDENTITY()";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeRef", RecipeRef);
                    command.Parameters.AddWithValue("@UserRef", UserRef);
                    command.Parameters.AddWithValue("@DateAdded", DateAdded);
                    command.Parameters.AddWithValue("@Notes", Notes);

                    foreach(SqlParameter parameter in command.Parameters)
                    {
                        if(parameter.Value is null)
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