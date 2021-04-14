using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class Comment
    {
        public string CommentID { get; set; }
        public string UserRef { get; set; }
        public string RecipeRef { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
        public bool Disabled { get; set; }

        public Comment() { }

        public Comment(string commentID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM Comment WHERE CommentID = @CommentID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentID", commentID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CommentID = commentID;
                            UserRef = reader["UserRef"].ToString();
                            RecipeRef = reader["RecipeRef"].ToString();
                            CommentDate = Convert.ToDateTime(reader["CommentDate"]);
                            CommentText = reader["CommentText"].ToString();
                            Disabled = Convert.ToBoolean(reader["Disabled"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddCommentToDatabase()
        {
            string result = "";
            if (string.IsNullOrEmpty(UserRef))
            {
                return "You must be logged in to comment.";
            }
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "INSERT INTO COMMENT(UserRef, RecipeRef, CommentDate, CommentText) VALUES(@UserRef, @RecipeRef, @CommentDate, @CommentText) SELECT SCOPE_IDENTITY()";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserRef", UserRef);
                    command.Parameters.AddWithValue("@RecipeRef", RecipeRef);
                    command.Parameters.AddWithValue("@CommentDate", DateTime.Now);
                    command.Parameters.AddWithValue("@CommentText", CommentText);
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

        public string DisableComment()
        {
            string result = "";
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "UPDATE COMMENT SET DISABLED = 1 WHERE CommentID = @CommentID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentID", CommentID);
                    try
                    {
                        command.ExecuteNonQuery();
                        result = CommentID;
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

        public string DeleteComment()
        {
            string result = "";
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "DELETE FROM Comment WHERE CommentID = @CommentID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentID", CommentID);
                    try
                    {
                        command.ExecuteNonQuery();
                        result = CommentID;
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

        public string UpdateComment()
        {
            string result = "";
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "UPDATE Comment SET CommentText = @CommentText WHERE CommentID = @CommentID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentID", CommentID);
                    command.Parameters.AddWithValue("@CommentText", CommentText);
                    try
                    {
                        command.ExecuteNonQuery();
                        result = CommentID;
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
    }
}