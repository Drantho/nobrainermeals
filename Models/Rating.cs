using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class Rating
    {
        public string RatingID { get; set; }
        public int RatingValue { get; set; }
        public string UserRef { get; set; }
        public DateTime RateDate { get; set; }
        public string RecipeRef { get; set; }

        public Rating() { }

        public Rating(string ratingID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM Rating WHERE RatingID = @RatingID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RatingID", ratingID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RatingID = ratingID;
                            RatingValue = Convert.ToInt32(reader["Rating"]);
                            UserRef = reader["UserRef"].ToString();
                            RateDate = Convert.ToDateTime(reader["RateDate"]);
                            RecipeRef = reader["RecipeRef"].ToString();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddRatingToDatabase()
        {
            if (string.IsNullOrEmpty(UserRef))
            {
                return "You must be logged in to rate recipes.";
            }
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "SELECT * FROM Rating WHERE UserRef = @UserRef AND RecipeRef = @RecipeRef";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserRef", UserRef);
                    command.Parameters.AddWithValue("@RecipeRef", RecipeRef);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return "You have already rated this recipe";
                        }
                    }
                }

                query = "INSERT INTO Rating(Rating, UserRef, RateDate, RecipeRef) VALUES(@RatingValue, @UserRef, @RateDate, @RecipeRef) SELECT SCOPE_IDENTITY()";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RatingValue", RatingValue);
                    command.Parameters.AddWithValue("@UserRef", UserRef);
                    command.Parameters.AddWithValue("@RateDate", RateDate);
                    command.Parameters.AddWithValue("@RecipeRef", RecipeRef);
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
        
        public static List<string> RatingStars(double rating) {

            List<string> ratingList = new List<string>();

            string filled = "<i class=\"fas fa-star\"></i>";
            string half = "<i class=\"fas fa-star-half-alt\"></i>";
            string empty = "<i class=\"far fa-star\"></i>";

            for(int i=0; i<=4; i++)
            {
                ratingList.Add(empty);
            }

            if (rating > 1)
            {
                if (rating == 1)
                {
                    ratingList[0] = filled;
                }
                else
                {
                    ratingList[0] = filled;
                    if (rating < 2)
                    {
                        ratingList[1] = half;
                    }
                    else
                    {
                        ratingList[0] = filled;
                        if (rating == 2)
                        {
                            ratingList[1] = filled;
                        }
                        else
                        {
                            ratingList[1] = filled;
                            if (rating < 3)
                            {
                                ratingList[2] = half;
                            }
                            else
                            {
                                ratingList[1] = filled;
                                if (rating == 3)
                                {
                                    ratingList[2] = filled;
                                }
                                else
                                {
                                    ratingList[2] = filled;
                                    if (rating < 4)
                                    {
                                        ratingList[3] = half;
                                    }
                                    else
                                    {
                                        if (rating == 4)
                                        {
                                            ratingList[3] = filled;
                                        }
                                        else
                                        {
                                            ratingList[3] = filled;
                                            if (rating < 5)
                                            {
                                                ratingList[4] = half;
                                            }
                                            else
                                            {
                                                if (rating == 5)
                                                {
                                                    ratingList[4] = filled;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ratingList;
        }
        
    }
}