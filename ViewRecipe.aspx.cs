using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;
using Microsoft.AspNet.Identity;

namespace bp2
{
    public partial class ViewRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                    Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
                    FillPage(recipe);
                }
                else
                {
                    Response.Redirect("RecipeList.aspx");
                }

                if (string.IsNullOrEmpty(Context.User.Identity.GetUserName()))
                {
                    btnFavorite.Visible = false;
                    heart.Visible = false;
                    favorite.Visible = true;
                }
            }
            catch
            {
                //Response.Write("<h1>Oops! Something went wrong!</h1>");
            }            

        }

        protected void ProcessSubmit(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
            recipe.UpdateRecipeRequired();

            recipe.Yield = Convert.ToInt32(txtYield.Text);

            txtYield.Text = "";

            FillPage(recipe);
            
        }

        private void FillPage(Recipe recipe)
        {
            imgTitle.ImageUrl = recipe.Photos[0].Full;

            SetRating(recipe.AvgRating);

            plhShoppingList.Controls.Clear();
            plhSupplierList.Controls.Clear();

            recipe.UpdateRecipeRequired();

            lblName.Text = recipe.Name;
            lblCookTime.Text = recipe.CookTime.ToString();
            lblPrepTime.Text = recipe.PrepTime.ToString();
            lblDescription.Text = recipe.Description.ToString();
            lblYield.Text = recipe.Yield.ToString();

            rptPhotos.DataSource = recipe.Photos;
            rptPhotos.DataBind();

            rptTags.DataSource = recipe.Tags;
            rptTags.DataBind();

            rptDirections.DataSource = recipe.Directions;
            rptDirections.DataBind();
            
            int i = 0;

            rptIngredients.DataSource = recipe.RecipeIngredients[0];
            rptIngredients.DataBind();            

            foreach (List<RecipeIngredient> recipeIngredientsList in recipe.RecipeIngredients)
            {

                plhSupplierList.Controls.Add(new LiteralControl("<a onclick=\"showSupplier('" + recipeIngredientsList[0].Source + "')\">"));
                plhSupplierList.Controls.Add(new LiteralControl("<div class='list-logo'>"));
                plhSupplierList.Controls.Add(new LiteralControl("<img src='images/" + recipeIngredientsList[0].Source + ".png'>"));
                plhSupplierList.Controls.Add(new LiteralControl("<br>"));
                plhSupplierList.Controls.Add(new LiteralControl("<strong>Price Per Serving : </strong>" + recipe.PricePerServing[i].ToString("C") + "<br>"));
                plhSupplierList.Controls.Add(new LiteralControl("view list"));
                plhSupplierList.Controls.Add(new LiteralControl("</div>"));
                plhSupplierList.Controls.Add(new LiteralControl("</a>"));


                if (i == 0)
                {
                    plhShoppingList.Controls.Add(new LiteralControl("<div class='supplier' id='" + recipeIngredientsList[0].Source + "' style='display: initial !important;'>"));
                }
                else
                {
                    plhShoppingList.Controls.Add(new LiteralControl("<div class='supplier' id='" + recipeIngredientsList[0].Source + "'>"));
                }
                


                plhShoppingList.Controls.Add(new LiteralControl("<h3 class='title'>" + recipeIngredientsList[0].Source + "</h3>"));
                plhShoppingList.Controls.Add(new LiteralControl("<h5 class='notice'>Prices vary by location and over time.</h5>"));

                plhShoppingList.Controls.Add(new LiteralControl("<div class='mdl-grid'>"));

                plhShoppingList.Controls.Add(new LiteralControl("<div class=\"mdl-cell mdl-cell--4-col time-box\">"));
                plhShoppingList.Controls.Add(new LiteralControl("<i class=\"fas fa-shopping-cart fa-7x\"></i><br>"));
                plhShoppingList.Controls.Add(new LiteralControl("<h5>Cart Price : " + recipe.Price[i].ToString("C") + "</h5>"));
                plhShoppingList.Controls.Add(new LiteralControl("</div>"));

                plhShoppingList.Controls.Add(new LiteralControl("<div class=\"mdl-cell mdl-cell--4-col time-box\">"));
                plhShoppingList.Controls.Add(new LiteralControl("<i class=\"fas fa-user fa-7x\"></i><br>"));
                plhShoppingList.Controls.Add(new LiteralControl("<h5>Price Per Serving : </strong>" + recipe.PricePerServing[i].ToString("C") + "</h5>"));
                plhShoppingList.Controls.Add(new LiteralControl("</div>"));

                plhShoppingList.Controls.Add(new LiteralControl("<div class=\"mdl-cell mdl-cell--4-col time-box\">"));
                plhShoppingList.Controls.Add(new LiteralControl("<a href='ShoppingList.aspx?RecipeID=" + recipe.RecipeID + "&ListNumber=" + i + "&Yield=" + recipe.Yield + "'>"));
                plhShoppingList.Controls.Add(new LiteralControl("<i class=\"fas fa-print fa-7x\"></i><br>"));
                plhShoppingList.Controls.Add(new LiteralControl("<h5>printable list</h5></a>"));
                plhShoppingList.Controls.Add(new LiteralControl("</div>"));

                plhShoppingList.Controls.Add(new LiteralControl("</div>"));


                plhShoppingList.Controls.Add(new LiteralControl("<ul class='two-columns'>"));
                foreach (RecipeIngredient recipeIngredient in recipeIngredientsList)
                {
                    plhShoppingList.Controls.Add(new LiteralControl("<li>"));

                    if(recipeIngredient.Ingredient.Name != "Water" && recipeIngredient.Ingredient.Name != "water")
                    {
                        plhShoppingList.Controls.Add(new LiteralControl("<a href='" + recipeIngredient.Ingredient.InfoLink + "' target='_blank'><div class='list-text'>" + recipeIngredient.Ingredient.Description + "</div><div class='list-action'>buy " + recipeIngredient.RecipeRequired + " @ " + recipeIngredient.Ingredient.Price.ToString("C") + " ea</div></a>"));
                    }                    
                    //plhShoppingList.Controls.Add(new LiteralControl("<a href='" + recipeIngredient.Ingredient.InfoLink + "' target='_blank'>(" + recipeIngredient.RecipeRequired + ") @ " + recipeIngredient.Ingredient.Price.ToString("C") + " ea - " + recipeIngredient.Ingredient.Name + "</a>"));
                    //plhShoppingList.Controls.Add(new LiteralControl("<br>" + recipeIngredient.Ingredient.LiveInfo));

                    plhShoppingList.Controls.Add(new LiteralControl("</li>"));
                }
                plhShoppingList.Controls.Add(new LiteralControl("</ul>"));
                
                i++;

                plhShoppingList.Controls.Add(new LiteralControl("</div>"));
            }
            
            rptEquipment.DataSource = recipe.RecipeEquipment;
            rptEquipment.DataBind();

            rptRecommends.DataSource = recipe.RecommendedRecipes();
            rptRecommends.DataBind();

            btnFavorite.Visible = !recipe.IsFavorite(Context.User.Identity.GetUserName());
            heart.Visible = recipe.IsFavorite(Context.User.Identity.GetUserName());

            lblFavoriteCount.Text = recipe.FavoriteCount.ToString();

            FillComments();

        }

        private void SetRating(double rating)
        {
            lbnSetRating1.Text = Rating.RatingStars(rating)[0];
            lbnSetRating2.Text = Rating.RatingStars(rating)[1];
            lbnSetRating3.Text = Rating.RatingStars(rating)[2];
            lbnSetRating4.Text = Rating.RatingStars(rating)[3];
            lbnSetRating5.Text = Rating.RatingStars(rating)[4];
        }

        protected void RateRecipe(object sender, CommandEventArgs e)
        {
            Rating rating = new Rating
            {
                RateDate = DateTime.Now,
                RatingValue = Convert.ToInt32(e.CommandArgument),
                RecipeRef = Request.QueryString["RecipeID"],
                UserRef = Context.User.Identity.GetUserName()
            };
            string result = rating.AddRatingToDatabase();
            try
            {
                Convert.ToInt32(result);
                lblRatingResult.Text = "Thank you for your feedback!";
                Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
                //lblRating.Text = recipe.AvgRating.ToString("0.#");
                SetRating(recipe.AvgRating);
            }
            catch
            {
                lblRatingResult.Text = result;
            }
        }

        protected void AddComment(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtComment.Text))
            {
                string result = "";
                Comment comment = new Comment
                {
                    CommentText = txtComment.Text,
                    RecipeRef = Request.QueryString["RecipeID"],
                    UserRef = Context.User.Identity.GetUserName()
                };
                result = comment.AddCommentToDatabase();
                try
                {
                    Convert.ToInt32(result);
                    lblCommentResult.Text = "Thank you for your comment!";
                    txtComment.Text = ""; ;
                    FillComments();
                }
                catch
                {
                    lblCommentResult.Text = result;
                }
            }
        }

        private void FillComments()
        {
            Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
            plhComments.Controls.Clear();
            int i = 0;
            foreach (Comment comment in recipe.Comments)
            {
                plhComments.Controls.Add(new LiteralControl("<li>"));

                plhComments.Controls.Add(new LiteralControl(comment.CommentText + "<br><br>"));
                plhComments.Controls.Add(new LiteralControl("<strong>" +comment.UserRef + " - " + comment.CommentDate.ToShortDateString() + "</strong><br>"));
                plhComments.Controls.Add(new LiteralControl("<hr>"));
                if (Context.User.Identity.GetUserName() == "NoBrainerMeals")
                {
                    LinkButton button = new LinkButton
                    {
                        Text = "Remove comment",
                        CommandArgument = comment.CommentID,
                        ID = "lbnDisable" + i,
                        CommandName = "DisableComment"
                    };

                    plhComments.Controls.Add(button);
                    button.Command += new CommandEventHandler(DisableComment);

                    AsyncPostBackTrigger asyncPostBackTrigger = new AsyncPostBackTrigger
                    {
                        ControlID = "lbnDisable" + i,
                        EventName = "Command"
                    };
                    UpdatePanel.Triggers.Add(asyncPostBackTrigger);

                }
                plhComments.Controls.Add(new LiteralControl("</li>"));
                i++;
            }
        }

        protected void DisableComment(object sender, CommandEventArgs e)
        {
            Comment comment = new Comment(e.CommandArgument.ToString());
            comment.DisableComment();

            FillComments();
        }

        protected void AddFavorite(object sender, EventArgs e)
        {
            Favorite favorite = new Favorite
            {
                DateAdded = DateTime.Now,
                RecipeRef = Request.QueryString["RecipeID"],
                UserRef = Context.User.Identity.GetUserName()
            };

            favorite.AddFavoriteToDatabase();

            btnFavorite.Visible = false;
            int count = Convert.ToInt32(lblFavoriteCount.Text);
            count++;
            lblFavoriteCount.Text = count.ToString();
            heart.Visible = true;
        }
    }
}