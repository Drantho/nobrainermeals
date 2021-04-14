using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

namespace bp2.Models
{
    public class Recipe
    {
        public string RecipeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public double PrepTime { get; set; }
        public double CookTime { get; set; }
        public int Yield { get; set; }
        public int InitialYield { get; set; }
        public List<double> Price {
            get
            {
                List<double> prices = new List<double>();
                
                foreach(List<RecipeIngredient> recipeIngredientList in RecipeIngredients)
                {
                    double price = 0;
                    foreach(RecipeIngredient recipeIngredient in recipeIngredientList)
                    {
                        //price += recipeIngredient.RecipeIngredientPrice;
                        //price +=  (Math.Ceiling(((Yield / InitialYield) * recipeIngredient.Quantity) / Equivalency.GetEquivalency(recipeIngredient.Ingredient.Quantity, recipeIngredient.Ingredient.QuantityUnit.UnitID, recipeIngredient.Unit.UnitID)) * recipeIngredient.Ingredient.Price);
                        recipeIngredient.RecipeRequired = Convert.ToInt32(Math.Ceiling((recipeIngredient.Quantity * Yield / InitialYield) / Equivalency.GetEquivalency(recipeIngredient.Ingredient.Quantity, recipeIngredient.Ingredient.QuantityUnit.UnitID, recipeIngredient.Unit.UnitID)));
                        price += recipeIngredient.RecipeRequired * recipeIngredient.Ingredient.Price;
                    }
                    prices.Add(price);
                }
                return prices;
            }
        }
        public List<double> PricePerServing {
            get
            {
                List<double> pps = new List<double>();

                foreach (List<RecipeIngredient> recipeIngredientList in RecipeIngredients)
                {
                    double price = 0;
                    foreach(RecipeIngredient recipeIngredient in recipeIngredientList)
                    {
                        price += (
                            recipeIngredient.RecipeRequired * recipeIngredient.Ingredient.Price 
                            *
                            (
                            (recipeIngredient.Quantity *  (Yield / InitialYield)) 
                            /
                            (
                            Equivalency.GetEquivalency( recipeIngredient.RecipeRequired * recipeIngredient.Ingredient.Quantity, recipeIngredient.Ingredient.QuantityUnit.UnitID, recipeIngredient.Unit.UnitID )
                            )
                            )
                            )
                            / Yield;
                    }
                    pps.Add(price);
                }
                return pps;
            }
        }
        public DateTime Posted { get; set; }
        public bool IsFavorite(string userID)
        {
            bool favorite = false;
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "Select * FROM FavoriteView WHERE UserRef = @UserRef AND RecipeID = @RecipeID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserRef", userID);
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        favorite = reader.HasRows;
                    }                    
                }
                connection.Close();
            }
            return favorite;
        }
        public int FavoriteCount
        {
            get
            {
                int count = 0;

                using(SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "SELECT COUNT(RecipeID) FROM FavoriteView WHERE RecipeID = @RecipeID";
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeID", RecipeID);
                        try
                        {
                            count = Convert.ToInt32(command.ExecuteScalar());
                        }
                        catch
                        {
                            count = 0;
                        }
                    }
                    connection.Close();
                }

                return count;
            }
        }
        public string DescriptionSummary
        {
            get
            {
                return Description.Substring(0, Math.Min(Description.Length-1, 150)) + "...";
            }
        }        

        private static int ItemsPerPage
        {
            get
            {
                return 8;
            }
        }

        public List<List<RecipeIngredient>> RecipeIngredients { get; set; }
        public List<string> Directions { get; set; }

        public List<RecipeEquipment> RecipeEquipment
        {
            get
            {
                List<RecipeEquipment> recipeEquipmentList = new List<RecipeEquipment>();

                using(SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "SELECT * FROM RecipeEquipmentView WHERE RecipeID = @RecipeID";
                    connection.Open();

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeID", RecipeID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RecipeEquipment recipeEquipment = new RecipeEquipment
                                {
                                    EquipmentRef = reader["EquipmentID"].ToString(),
                                    Notes = reader["Notes"].ToString(),
                                    RecipeEquipmentID = reader["RecipeEquipmentID"].ToString(),
                                    RecipeRef = reader["RecipeID"].ToString(),
                                    Equipment = new Equipment
                                    {
                                        CartLink = reader["CartLink"].ToString(),
                                        Description = reader["EquipmentDescription"].ToString(),
                                        EquipmentID = reader["EquipmentID"].ToString(),
                                        ExternalID = reader["ExternalID"].ToString(),
                                        InfoLink = reader["InfoLink"].ToString(),
                                        Name = reader["EquipmentName"].ToString(),
                                        PhotoLink = reader["PhotoLink"].ToString(),
                                        Source = reader["Source"].ToString(),
                                        Price = Convert.ToDouble(reader["Price"])
                                    }
                                };
                                recipeEquipmentList.Add(recipeEquipment);
                            }
                            reader.Close();
                        }
                    }

                    connection.Close();
                }

                return recipeEquipmentList;
            }
        }

        public List<Photo> Photos
        {
            get
            {
                List<Photo> photos = new List<Photo>();

                int number = 1;
                string photoType = "Recipe";
                string id = RecipeID;
                string location = HttpContext.Current.Server.MapPath("/");

                while (File.Exists(location + "images/" + photoType + "-" + id + "-" + number + "thumb.jpg"))
                {
                    Photo photo = new Photo("Recipe", RecipeID, number, this);
                    photos.Add(photo);
                    number++;
                }
                if(number == 1)
                {
                    Photo photo = new Photo("Recipe", RecipeID, number, this);
                    photos.Add(photo);
                }

                return photos;
            }
        }

        public List<Rating> Ratings
        {
            get
            {
                List<Rating> ratings = new List<Rating>();

                using(SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "SELECT * FROM Rating WHERE RecipeRef = @RecipeRef ORDER BY RecipeRef";
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeRef", RecipeID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Rating rating = new Rating
                                {
                                    RatingID = reader["RatingID"].ToString(),
                                    RatingValue = Convert.ToInt32(reader["Rating"]),
                                    UserRef = reader["UserRef"].ToString(),
                                    RateDate = Convert.ToDateTime(reader["RateDate"]),
                                    RecipeRef = RecipeID
                                };
                                ratings.Add(rating);
                            }
                        }
                    }
                    connection.Close();
                }

                return ratings;
            }
        }
        public double AvgRating { get; set; }

        public List<Comment> Comments
        {
            get
            {
                List<Comment> comments = new List<Comment>();

                using(SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "SELECT * FROM Comment WHERE RecipeRef = @RecipeRef AND Disabled =0 ORDER BY CommentID DESC";
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RecipeRef", RecipeID);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Comment comment = new Comment
                                {
                                    CommentDate = Convert.ToDateTime(reader["CommentDate"]),
                                    CommentID = reader["CommentID"].ToString(),
                                    CommentText = reader["CommentText"].ToString(),
                                    RecipeRef = RecipeID,
                                    Disabled = Convert.ToBoolean(reader["Disabled"]),
                                    UserRef = reader["UserRef"].ToString()
                                };

                                comments.Add(comment);
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                }

                return comments;
            }
        }

        public Recipe() { }

        public Recipe(string recipeID)
        {
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "SELECT * FROM RecipeRatingsView WHERE RecipeID = @RecipeID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeID", recipeID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecipeID = recipeID;
                            Name = reader["Name"].ToString();
                            Description = reader["Description"].ToString();
                            PrepTime = Convert.ToDouble(reader["PrepTime"]);
                            CookTime = Convert.ToDouble(reader["CookTime"]);
                            Yield = Convert.ToInt32(reader["Yield"]);
                            InitialYield = Convert.ToInt32(reader["Yield"]);
                            Posted = Convert.ToDateTime(reader["Posted"]);
                            Directions = reader["Directions"].ToString().Split('~').ToList<string>();
                            Tags = reader["Tags"].ToString().Split('~').ToList<string>();
                            AvgRating = Convert.ToDouble(reader["AvgRating"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();

                RecipeIngredients = GetRecipeIngredients();
                UpdateRecipeRequired();
            }
        }

        public string AddRecipeToDatabase()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                string query = "INSERT INTO Recipe(Name, Description, Tags, PrepTime, CookTime, Yield, Posted, Directions) VALUES(@Name, @Description, @Tags, @PrepTime, @CookTime, @Yield, @Posted, @Directions) SELECT SCOPE_IDENTITY()";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Tags", String.Join("~", Tags));
                    command.Parameters.AddWithValue("@PrepTime", PrepTime);
                    command.Parameters.AddWithValue("@CookTime", CookTime);
                    command.Parameters.AddWithValue("@Yield", Yield);
                    command.Parameters.AddWithValue("@Posted", Posted);
                    command.Parameters.AddWithValue("@Directions", String.Join("~", Directions));                    

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

        public string EditRecipe()
        {
            string result = "";

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "UPDATE RECIPE SET Name = @Name, Description = @Description, Tags = @Tags, Preptime = @Preptime, CookTime = @CookTime, Yield = @Yield, Directions = @Directions, Posted = @Posted WHERE RecipeID = @RecipeID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Tags", string.Join("~", Tags));
                    command.Parameters.AddWithValue("@PrepTime", PrepTime);
                    command.Parameters.AddWithValue("@CookTime", CookTime);
                    command.Parameters.AddWithValue("@Yield", Yield);
                    command.Parameters.AddWithValue("@Directions", string.Join("~", Directions));
                    command.Parameters.AddWithValue("@Posted", Posted);
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);

                    try
                    {
                        command.ExecuteNonQuery();
                        result = RecipeID;
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
        
        private List<List<RecipeIngredient>> GetRecipeIngredients()
        {
            List<List<RecipeIngredient>> recipeIngredientsList = new List<List<RecipeIngredient>>();

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM RecipeIngredientView WHERE RecipeRef = @RecipeRef ORDER BY Source";
                connection.Open();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeRef", RecipeID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        string oldSource = "";
                        string newSource = "";
                        
                        List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
                        int i = 1;

                        while (reader.Read())
                        {
                            newSource = reader["Source"].ToString();

                            if(oldSource != newSource)
                            {                                
                                if(i > 1)
                                {
                                    recipeIngredientsList.Add(recipeIngredients);
                                }
                                List<RecipeIngredient> blank = new List<RecipeIngredient>();
                                recipeIngredients = blank;
                            }

                            RecipeIngredient recipeIngredient = new RecipeIngredient
                            {
                                RecipeIngredientID = reader["RecipeIngredientID"].ToString(),
                                IngredientRef = reader["IngredientRef"].ToString(),
                                Notes = reader["Notes"].ToString(),
                                Optional = Convert.ToBoolean(reader["Optional"]),
                                Quantity = Convert.ToDouble(reader["Quantity"]),
                                RecipeRef = reader["RecipeRef"].ToString(),
                                Unit = Unit.GetUnit(Convert.ToInt32(reader["Unit"])),
                                Source = reader["Source"].ToString(),
                                Ingredient = new Ingredient
                                {
                                    Name = reader["Name"].ToString(),
                                    CartLink = reader["CartLink"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ExternalID = reader["ExternalID"].ToString(),
                                    InfoLink = reader["InfoLink"].ToString(),
                                    IngredientID = reader["IngredientID"].ToString(),
                                    PhotoUrl = reader["PhotoUrl"].ToString(),
                                    Price = Convert.ToDouble(reader["Price"]),
                                    Quantity = Convert.ToDouble(reader["IngredientQuantity"]),
                                    QuantityUnit = Unit.GetUnit(Convert.ToInt32(reader["QuantityUnit"])),
                                    Source = reader["Source"].ToString()
                                }
                            };
                            recipeIngredients.Add(recipeIngredient);
                            i++;
                            oldSource = newSource;
                        }
                        reader.Close();
                        recipeIngredientsList.Add(recipeIngredients);
                    }
                }

                connection.Close();
            }

            return recipeIngredientsList;
        }

        public List<Recipe> RecommendedRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            List<string> ids = new List<string>();

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "Select * FROM RecommendedView WHERE SubjectID = @RecipeID ORDER BY Name, RecipeID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RecipeID", RecipeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeID = reader["RecipeID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> SearchRecipes(List<string> searchParameters)
        {
            List<Recipe> recipes = new List<Recipe>();

            string query = "SELECT DISTINCT RecipeID, RecipeName, RecipeDescription, Tags, PrepTime, CookTime, Yield, Directions, Posted, AvgRating, FavoriteCount FROM RecipeView WHERE ";
            int i = 1;
            foreach(string searchParameter in searchParameters)
            {
                if(i > 1)
                {
                    query += " OR";
                }

                query += " RecipeName LIKE @RecipeName" + i + " OR Tags LIKE @Tags" + i + " OR RecipeDescription = @RecipeDescription" + i + " OR IngredientName LIKE @IngredientName" + i + " OR IngredientDescription = @IngredientDescription" + i;
                i++;
            }

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    int j = 1;
                    foreach (string searchParameter in searchParameters)
                    {
                        command.Parameters.AddWithValue("@RecipeName" + j, "%" + searchParameter + "%");
                        command.Parameters.AddWithValue("@RecipeDescription" + j, "%" + searchParameter + "%");
                        command.Parameters.AddWithValue("@Tags" + j, "%" + searchParameter + "%");
                        command.Parameters.AddWithValue("@IngredientName" + j, "%" + searchParameter + "%");
                        command.Parameters.AddWithValue("@IngredientDescription" + j, "%" + searchParameter + "%");
                        j++;
                    }
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeID = reader["RecipeID"].ToString(),
                                Name = reader["RecipeName"].ToString(),
                                Description = reader["RecipeDescription"].ToString(),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> SearchRecipes(List<string> searchParameters, int startNumber)
        {
            List<Recipe> recipes = new List<Recipe>();

            string query = "SELECT DISTINCT RecipeID, RecipeName, RecipeDescription, Tags, PrepTime, CookTime, Yield, Directions, Posted, AvgRating, FavoriteCount FROM RecipeView WHERE ";
            int i = 1;
            foreach (string searchParameter in searchParameters)
            {
                if (i > 1)
                {
                    query += " OR";
                }

                query += " RecipeName LIKE @RecipeName" + i + " OR Tags LIKE @Tags" + i + " OR RecipeDescription = @RecipeDescription" + i + " OR IngredientName LIKE @IngredientName" + i + " OR IngredientDescription = @IngredientDescription" + i;
                i++;
            }
            query += " ORDER BY RecipeID OFFSET " + startNumber + " ROWS FETCH NEXT " + ItemsPerPage.ToString() + " ROWS ONLY";

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int j = 1;
                    foreach (string searchParameter in searchParameters)
                    {
                        command.Parameters.AddWithValue("@RecipeName" + j, "%" + searchParameter.Trim() + "%");
                        command.Parameters.AddWithValue("@RecipeDescription" + j, "%" + searchParameter.Trim() + "%");
                        command.Parameters.AddWithValue("@Tags" + j, "%" + searchParameter.Trim() + "%");
                        command.Parameters.AddWithValue("@IngredientName" + j, "%" + searchParameter.Trim() + "%");
                        command.Parameters.AddWithValue("@IngredientDescription" + j, "%" + searchParameter.Trim() + "%");
                        j++;
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeID = reader["RecipeID"].ToString(),
                                Name = reader["RecipeName"].ToString(),
                                Description = reader["RecipeDescription"].ToString(),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> AllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "Select * FROM RecipeRatingsView ORDER BY Name, RecipeID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeID = reader["RecipeID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> AllRecipes(int startNumber)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "Select * FROM RecipeRatingsView ORDER BY Name, RecipeID OFFSET " + startNumber + " ROWS FETCH NEXT " + ItemsPerPage.ToString() + " ROWS ONLY";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeID = reader["RecipeID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<string> AllTags
        {
            get
            {
                List<string> tags = new List<string>();

                string query = "SELECT DISTINCT Tags FROM Recipe";

                using(SqlConnection connection = MyConnection.CurrentConnection)
                {
                    connection.Open();

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<string> list = reader["Tags"].ToString().Split('~').ToList<string>();

                                foreach(string item in list)
                                {
                                    bool found = false;
                                    foreach(string tagItem in tags)
                                    {
                                        if(item.Trim().ToLower() == tagItem.Trim().ToLower())
                                        {
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (!found)
                                    {
                                        tags.Add(item.Trim().ToLower());
                                    }
                                }                            }
                        }
                    }

                    connection.Close();
                }
                tags.Sort();
                return tags;
            }
        }

        public static Recipe RecentRecipe
        {
            get
            {
                Recipe recipe = new Recipe();
                using (SqlConnection connection = MyConnection.CurrentConnection)
                {
                    connection.Open();
                    string query = "SELECT TOP 1 * FROM RecipeRatingsView ORDER BY RecipeID DESC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recipe.RecipeID = reader["RecipeID"].ToString();
                                recipe.Name = reader["Name"].ToString();
                                recipe.Description = reader["Description"].ToString();
                                recipe.PrepTime = Convert.ToDouble(reader["PrepTime"]);
                                recipe.CookTime = Convert.ToDouble(reader["CookTime"]);
                                recipe.Yield = Convert.ToInt32(reader["Yield"]);
                                recipe.InitialYield = Convert.ToInt32(reader["Yield"]);
                                recipe.Posted = Convert.ToDateTime(reader["Posted"]);
                                recipe.Directions = reader["Directions"].ToString().Split('~').ToList<string>();
                                recipe.Tags = reader["Tags"].ToString().Split('~').ToList<string>();
                                recipe.AvgRating = Convert.ToDouble(reader["AvgRating"]);
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                }
                recipe.RecipeIngredients = recipe.GetRecipeIngredients();
                return recipe;            
            }
        }

        public static List<Recipe> RecentRecipes
        {
            get
            {
                List<Recipe> recipes = new List<Recipe>();
                using (SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "Select TOP 4 * FROM RecipeRatingsView ORDER BY Posted DESC, RecipeID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Recipe recipe = new Recipe
                                {
                                    RecipeID = reader["RecipeID"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                    CookTime = Convert.ToDouble(reader["CookTime"]),
                                    Yield = Convert.ToInt32(reader["Yield"]),
                                    InitialYield = Convert.ToInt32(reader["Yield"]),
                                    Posted = Convert.ToDateTime(reader["Posted"]),
                                    Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                    AvgRating = Convert.ToDouble(reader["AvgRating"])
                                };
                                recipes.Add(recipe);
                            }
                        }
                    }
                    connection.Close();
                }

                return recipes;
            }
        }

        public void UpdateRecipeRequired()
        {

            List<List<RecipeIngredient>> list = GetRecipeIngredients();

            foreach (List<RecipeIngredient> recipeIngredientList in list)
            {
                foreach (RecipeIngredient recipeIngredient in recipeIngredientList)
                {
                    try
                    {
                        recipeIngredient.UpdatedQuantity = recipeIngredient.Quantity * Yield / InitialYield;
                        recipeIngredient.RecipeRequired = Convert.ToInt32(Math.Ceiling(recipeIngredient.Quantity / Equivalency.GetEquivalency(recipeIngredient.Ingredient.Quantity, recipeIngredient.Ingredient.QuantityUnit.UnitID, recipeIngredient.Unit.UnitID)));
                        
                    }
                    catch { }
                }
            }

            RecipeIngredients = list;
        }

        public static List<Recipe> Favorites(string userRef)
        {
            List<Recipe> recipes = new List<Recipe>();

            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM FavoriteView WHERE UserRef = @UserRef ORDER BY Name, RecipeID";
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserRef", userRef);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Description = reader["Description"].ToString(),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Name = reader["Name"].ToString(),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                RecipeID = reader["RecipeID"].ToString(),
                                Tags = reader["Tags"].ToString().Split('~').ToList<string>(),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> Favorites(string userRef, int startNumber)
        {
            List<Recipe> recipes = new List<Recipe>();

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM FavoriteView WHERE UserRef = @UserRef ORDER BY Name, RecipeID  OFFSET " + startNumber + " ROWS FETCH NEXT " + ItemsPerPage.ToString() + " ROWS ONLY";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserRef", userRef);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Description = reader["Description"].ToString(),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Name = reader["Name"].ToString(),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                RecipeID = reader["RecipeID"].ToString(),
                                Tags = reader["Tags"].ToString().Split('~').ToList<string>(),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> RecipeRatings()
        {
                List<Recipe> recipes = new List<Recipe>();
                using(SqlConnection connection = MyConnection.CurrentConnection)
                {
                    string query = "SELECT * FROM RecipeRatingsView ORDER BY AvgRating DESC";
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Recipe recipe = new Recipe
                                {
                                    RecipeID = reader["RecipeID"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                    CookTime = Convert.ToDouble(reader["CookTime"]),
                                    Yield = Convert.ToInt32(reader["Yield"]),
                                    InitialYield = Convert.ToInt32(reader["Yield"]),
                                    Posted = Convert.ToDateTime(reader["Posted"]),
                                    Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                    AvgRating = Convert.ToDouble(reader["AvgRating"])
                                };
                                recipes.Add(recipe);
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                }

                return recipes;
        }

        public static List<Recipe> RecipeRatings(int startNumber)
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM RecipeRatingsView  ORDER BY AvgRating DESC, Name, RecipeID OFFSET " + startNumber + " ROWS FETCH NEXT " + ItemsPerPage.ToString() + " ROWS ONLY";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                RecipeID = reader["RecipeID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> Popular()
        {
            List<Recipe> recipes = new List<Recipe>();

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM RecipeRatingsView ORDER BY FavoriteCount DESC, Name, RecipeID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Description = reader["Description"].ToString(),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Name = reader["Name"].ToString(),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                RecipeID = reader["RecipeID"].ToString(),
                                Tags = reader["Tags"].ToString().Split('~').ToList<string>(),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }

        public static List<Recipe> Popular(int startNumber)
        {
            List<Recipe> recipes = new List<Recipe>();

            using (SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "SELECT * FROM RecipeRatingsView ORDER BY FavoriteCount DESC, Name, RecipeID OFFSET " + startNumber + " ROWS FETCH NEXT " + ItemsPerPage.ToString() + " ROWS ONLY";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Recipe recipe = new Recipe
                            {
                                CookTime = Convert.ToDouble(reader["CookTime"]),
                                Description = reader["Description"].ToString(),
                                Directions = reader["Directions"].ToString().Split('~').ToList<string>(),
                                InitialYield = Convert.ToInt32(reader["Yield"]),
                                Name = reader["Name"].ToString(),
                                Posted = Convert.ToDateTime(reader["Posted"]),
                                PrepTime = Convert.ToDouble(reader["PrepTime"]),
                                RecipeID = reader["RecipeID"].ToString(),
                                Tags = reader["Tags"].ToString().Split('~').ToList<string>(),
                                Yield = Convert.ToInt32(reader["Yield"]),
                                AvgRating = Convert.ToDouble(reader["AvgRating"])
                            };
                            recipes.Add(recipe);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return recipes;
        }
    }
}