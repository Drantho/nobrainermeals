using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;

namespace bp2
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Search";
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Search"]))
                {
                    ProcessSearch(Request.QueryString["Search"]);
                    lblTitle.Text = "Search Results for \"" + Request.QueryString["Search"] + "\"";
                }
            }            
        }
        
        private void ProcessSearch(string search)
        {
            List<string> list = search.Split(' ').ToList();

            rptRecipes.DataSource = Recipe.SearchRecipes(list);
            rptRecipes.DataBind();
        }
    }
}