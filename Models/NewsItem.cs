using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class NewsItem
    {
        public string NewsID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Posted { get; set; }

        public NewsItem() { }

        public NewsItem(string newsID)
        {
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM News WHERE NewsID = @NewsID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewsID", newsID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NewsID = newsID;
                            Title = reader["Title"].ToString();
                            Body = reader["Body"].ToString();
                            Posted = Convert.ToDateTime(reader["Posted"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddNewsToDatabase()
        {
            string result = "";

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "INSERT INTO News(Title, Body, Posted) VALUES(@Title, @Body, @Posted) SELECT Scope_Identity()";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Body", Body);
                    command.Parameters.AddWithValue("@Posted", Posted);

                    try
                    {
                        result = command.ExecuteScalar().ToString();
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

        public string UpdateNews()
        {
            string result = "";

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "UPDATE News SET Title = @Title, Body = @Body, Posted = @Posted WHERE NewsID = @NewsID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Body", Body);
                    command.Parameters.AddWithValue("@Posted", Posted);
                    command.Parameters.AddWithValue("@NewsID", NewsID);

                    try
                    {
                        command.ExecuteScalar().ToString();
                        result = NewsID;
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

        public static List<NewsItem> AllNews
        {
            get
            {
                List<NewsItem> newsList = new List<NewsItem>();
                using (SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "SELECT * FROM News ORDER BY NewsID DESC";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NewsItem newsItem = new NewsItem
                                {
                                    NewsID = reader["NewsID"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Body = reader["Body"].ToString(),
                                    Posted = Convert.ToDateTime(reader["Posted"])
                                };
                                newsList.Add(newsItem);
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                }
                return newsList;
            }
        }
    }
}