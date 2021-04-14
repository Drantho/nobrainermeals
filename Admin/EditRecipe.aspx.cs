using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;
using Microsoft.AspNet.Identity;

namespace bp2.Admin
{
    public partial class Edit_Recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }

            if (string.IsNullOrEmpty(Request.QueryString["RecipeID"]))
            {
                rptRecipeList.DataSource = Recipe.AllRecipes();
                rptRecipeList.DataBind();
            }
            else
            {
                if (!IsPostBack)
                {
                    Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
                    FillForm(recipe);
                }
            }
        }        

        private void FillForm(Recipe recipe)
        {
            pnlSelectRecipe.Visible = false;
            pnlForm.Visible = true;

            lblTitle.Text = recipe.Name;
            CookTime.Text = recipe.CookTime.ToString();
            Description.Text = recipe.Description;
            Name.Text = recipe.Name;
            PrepTime.Text = recipe.PrepTime.ToString();
            Tags.Text = String.Join(", ", recipe.Tags.ToArray());
            Yield.Text = recipe.Yield.ToString();

            int i = 1;
            foreach(string direction in recipe.Directions)
            {
                TextBox textBox = this.Master.FindControl("MainContent").FindControl("Step" + i) as TextBox;
                textBox.Text = direction;
                i++;
            }

            rptIngredients.DataSource = recipe.RecipeIngredients;
            rptIngredients.DataBind();
        }

        protected void UpdateRecipe(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe(Request.QueryString["RecipeID"])
            {
                CookTime = Convert.ToInt32(CookTime.Text),
                Description = Description.Text,
                Directions = new List<string>(), 
                Name = Name.Text,
                PrepTime = Convert.ToInt32(PrepTime.Text),
                Tags = Tags.Text.Split(',').ToList(),
                Yield = Convert.ToInt32(Yield.Text)
            };

            for (int i = 1; i <= 15; i++)
            {
                TextBox direction = this.Master.FindControl("MainContent").FindControl("Step" + i) as TextBox;
                if (!string.IsNullOrEmpty(direction.Text))
                {
                    recipe.Directions.Add(direction.Text);
                }
            }

            string result = recipe.EditRecipe();
            try
            {
                Convert.ToInt32(result);
                Response.Redirect("../ViewRecipe.aspx?RecipeID=" + result);
            }
            catch
            {
                lblResult.Text = result;
            }
            
        }

        protected void DeleteIngredient(object sender, CommandEventArgs e)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient
            {
                RecipeIngredientID = e.CommandArgument.ToString()
            };

            string result = "";


            try
            {
                result = recipeIngredient.DeleteRecipeIngredient();
                Convert.ToInt32(result);
                Response.Redirect("EditRecipe.aspx?RecipeID=" + Request.QueryString["RecipeID"]);
            }
            catch
            {
                lblResult.Text = result;
            }
            

        }
    }
}