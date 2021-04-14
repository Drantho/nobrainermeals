using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;

namespace bp2
{
    public partial class CreatePlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Plan"] = new Plan();
            }
            else
            {
                Plan plan = Session["Plan"] as Plan;

                lblResult.Text = "Plan.Recipes.count: " + plan.Recipes.Count.ToString() + "<br>";
                lblResult.Text += "Plan.RecipeIngredients.Count: " + plan.RecipeIngredients.Count.ToString();

                foreach (RecipeIngredient recipeIngredient in plan.RecipeIngredients)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        ID = recipeIngredient.RecipeIngredientID,
                        Text = recipeIngredient.Ingredient.Description
                    };
                    plhIngredients.Controls.Add(checkBox);
                    plhIngredients.Controls.Add(new LiteralControl("<br>"));
                }
            }

            rptAllRecipes.DataSource = Recipe.AllRecipes();
            rptAllRecipes.DataBind();

            
            
        }

        protected void AddRecipe(object sender, CommandEventArgs e)
        {
            Plan plan = Session["Plan"] as Plan;

            Recipe recipe = new Recipe(e.CommandArgument.ToString());
            plan.AddRecipe(recipe);
            Session["Plan"] = plan;
        }
    }
}