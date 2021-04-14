using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;

namespace bp2.Admin
{
    public partial class LinkRecipes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                    rptSelectRecipe.DataSource = Recipe.AllRecipes();
                    rptSelectRecipe.DataBind();
                }
                else
                {
                    Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
                    lblTitle.Text += " to " + recipe.Name;
                    pnlSelectRecipe.Visible = false;
                    pnlLink.Visible = true;
                    cblRecipes.DataSource = Recipe.AllRecipes();
                    cblRecipes.DataTextField = "Name";
                    cblRecipes.DataValueField = "RecipeID";
                    cblRecipes.DataBind();
                }
            }

        }

        protected void SetLinks(object sender, EventArgs e)
        {
            foreach(ListItem item in cblRecipes.Items)
            {
                if (item.Selected)
                {
                    Recommend recommend = new Recommend
                    {
                        RecipeID1 = Request.QueryString["RecipeID"],
                        RecipeID2 = item.Value
                    };

                    string result = "";
                    result = recommend.AddRecommendToDatabase();
                    try
                    {
                        Convert.ToInt32(result);
                    }
                    catch
                    {
                        lblTitle.Text += "<br> " + result;
                    }
                }
            }
            Response.Redirect("../ViewRecipe.aspx?RecipeID=" + Request.QueryString["RecipeID"]);
        }
    }
}