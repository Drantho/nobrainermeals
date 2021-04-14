using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;

namespace bp2
{
    public partial class ShoppingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Shopping List";
            try
            {
                Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
                int listNumber = Convert.ToInt32(Request.QueryString["ListNumber"]);                
                recipe.Yield = Convert.ToInt32(Request.QueryString["Yield"]);
                recipe.UpdateRecipeRequired();
                rptList.DataSource = recipe.RecipeIngredients[listNumber];
                rptList.DataBind();
                lblStore.Text = recipe.RecipeIngredients[listNumber][0].Ingredient.Source;
            }
            catch(Exception exc)
            {
                lblResult.Text = exc.Message;
                lblResult.Text += exc.Data.ToString();
                lblResult.Text += exc.ToString();
            }
        }
    }
}