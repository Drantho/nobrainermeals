using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace bp2.Models
{
    public class Equipment
    {
        public string EquipmentID { get; set; }
        public string ExternalID { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string InfoLink { get; set; }
        public string CartLink { get; set; }
        public string PhotoLink { get; set; }
        public double Price { get; set; }

        public Equipment() { }

        public Equipment(string equipmentID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM Equipment WHERE EquipmentID = @EquipmentID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EquipmentID", equipmentID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EquipmentID = equipmentID;
                            Name = reader["Name"].ToString();
                            Description = reader["Description"].ToString();
                            InfoLink = reader["InfoLink"].ToString();
                            CartLink = reader["CartLink"].ToString();
                            PhotoLink = reader["PhotoLink"].ToString();
                            Price = Convert.ToDouble(reader["Name"]);
                            ExternalID = reader["ExternalID"].ToString();
                            Source = reader["Spurce"].ToString();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddEquipmentToDatabase()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query1 = "SELECT * FROM Equipment WHERE ExternalID = @ExternalID";
                
                string query2 = "INSERT INTO Equipment(Name, Description, InfoLink, CartLink, PhotoLink, Price, Source, ExternalID) VALUES(@Name, @Description, @InfoLink, @CartLink, @PhotoLink, @Price, @Source, @ExternalID) SELECT SCOPE_IDENTITY()";

                connection.Open();
                using(SqlCommand command1 = new SqlCommand(query1, connection))
                {
                    command1.Parameters.AddWithValue("@ExternalID", ExternalID);
                    using(SqlDataReader reader = command1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return reader["EquipmentID"].ToString();
                        }
                    }
                }

                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@InfoLink", InfoLink);
                    command.Parameters.AddWithValue("@CartLink", CartLink);
                    command.Parameters.AddWithValue("@PhotoLink", PhotoLink);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@Source", Source);
                    command.Parameters.AddWithValue("@ExternalID", ExternalID);

                    foreach (SqlParameter parameter in command.Parameters)
                    {
                        if(parameter.Value == null)
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