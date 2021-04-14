using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq; 

namespace bp2.Models
{
    public class Ingredient
    {
        public string IngredientID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExternalID { get; set; }
        public string Source { get; set; }
        public double Price { get; set; }
        public int AmountRequired { get; set; }
        public string PhotoUrl { get; set; }
        public string InfoLink { get; set; }
        public string CartLink { get; set; }

        public string LiveInfo { get
            {
                switch (Source){
                    case "Walmart":
                        return "";//GetLive("http://api.walmartlabs.com/v1/items/" + ExternalID + "?format=json&apiKey=dj86j5h4hwzmcv56stcyz2by");
                    default:
                        return "";
                }
                
            }
        }
        
        public double Density { get; set; }
        public Unit DensityUnit { get; set; }

        public double Quantity { get; set; }
        public Unit QuantityUnit { get; set; }

        public Ingredient() { }

        public Ingredient(string ingredientID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "SELECT * FROM Ingredient WHERE IngredientID = @IngredientID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IngredientID", ingredientID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IngredientID = ingredientID;
                            Name = reader["Name"].ToString();
                            Description = reader["Description"].ToString();
                            ExternalID = reader["ExternalID"].ToString();
                            Source = reader["Source"].ToString();
                            Price = Convert.ToDouble(reader["Price"]);
                            QuantityUnit = Unit.GetUnit(Convert.ToInt32(reader["QuantityUnit"]));
                            Quantity = Convert.ToDouble(reader["Quantity"]);
                            PhotoUrl = reader["PhotoLink"].ToString();
                            InfoLink = reader["InfoLink"].ToString();
                            CartLink = reader["CartLink"].ToString();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public Ingredient(string externalID, string source)
        {
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "SELECT * FROM Ingredient WHERE ExternalID = @ExternalID AND Source = @Source";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ExternalID", externalID);
                    command.Parameters.AddWithValue("@Source", source);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IngredientID = reader["IngredientID"].ToString();
                            Name = reader["Name"].ToString();
                            Description = reader["Description"].ToString();
                            ExternalID = reader["ExternalID"].ToString();
                            Source = reader["Source"].ToString();
                            Price = Convert.ToDouble(reader["Price"]);
                            QuantityUnit = Unit.GetUnit(Convert.ToInt32(reader["QuantityUnit"]));
                            Quantity = Convert.ToDouble(reader["Quantity"]);
                            PhotoUrl = reader["PhotoLink"].ToString();
                            InfoLink = reader["InfoLink"].ToString();
                            CartLink = reader["CartLink"].ToString();
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public string AddIngredientToDatabase()
        {
            string result = "";
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                
                string query = "INSERT INTO Ingredient(Name, Description, ExternalID, Source, Price, Quantity, QuantityUnit, PhotoUrl, InfoLink, CartLink)VALUES(@Name, @Description, @ExternalID, @Source, @Price, @Quantity, @QuantityUnit, @PhotoUrl, @InfoLink, @CartLink) SELECT Scope_IDENTITY()";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@ExternalID", ExternalID);
                    command.Parameters.AddWithValue("@Source", Source);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@QuantityUnit", QuantityUnit.UnitID);
                    command.Parameters.AddWithValue("@PhotoUrl", PhotoUrl);
                    command.Parameters.AddWithValue("@InfoLink", InfoLink);
                    command.Parameters.AddWithValue("@CartLink", CartLink);

                    foreach(SqlParameter parameter in command.Parameters)
                    {
                        if(parameter.Value is null)
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
        
        public string UpdateIngredient()
        {
            string result = "";

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "UPDATE Ingredient SET Name = @Name, Description = @Description, ExternalID = @ExternalID, Source = @Source, Price = @Price, Quantity = @Quantity, QuantityUnit = @QuantityUnit, PhotoURL = @PhotoURL, InfoLink = @InfoLink, CartLink = @CartLink WHERE IngredientID = @IngredientID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@ExternalID", ExternalID);
                    command.Parameters.AddWithValue("@Source", Source);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@QuantityUnit", QuantityUnit.UnitID);
                    command.Parameters.AddWithValue("@PhotoUrl", PhotoUrl);
                    command.Parameters.AddWithValue("@InfoLink", InfoLink);
                    command.Parameters.AddWithValue("@CartLink", CartLink);
                    command.Parameters.AddWithValue("@IngredientID", IngredientID);
                    try
                    {
                        command.ExecuteNonQuery();
                        result = IngredientID;
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
        
        public string GetLive(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = HttpContext.Current.Request.UserAgent;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var content = string.Empty;

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();

                            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                            content += "<br><br>PRICE: " + result["msrp"];
                            content += "<br>SALE PRICE: " + result["salePrice"];
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                content = exc.Message + "<br>" + url;
            }

            content += "<br>HELLO???";

            return content;
        }
    }
}