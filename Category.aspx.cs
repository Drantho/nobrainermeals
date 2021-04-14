using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;

namespace bp2
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> query = new List<string>
            {
                Request.QueryString["Category"]
            };
            rptRecipes.DataSource = Recipe.SearchRecipes(query);
            rptRecipes.DataBind();
            lblTitle.Text = query[0] + " Recipes";

            Page.Title = Request.QueryString["Category"] + " Recipes";
        }
    }
}