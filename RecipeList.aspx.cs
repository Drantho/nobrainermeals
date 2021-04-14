using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;
using System.Web.UI.HtmlControls;

namespace bp2
{
    public partial class RecipeList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(Request.QueryString["Page"]);
            string sort = Request.QueryString["sort"];

            if(page < 1)
            {
                page = 1;
            }

            switch (sort)
            {
                //case "Recent":
                //rptRecipes.DataSource = Recipe.RecentRecipes((page-1) * 8);
                //break;
                case "Rating":
                    rptRecipes.DataSource = Recipe.RecipeRatings((page-1) * 8);
                    hlkRating.Enabled = false;
                    hlkRating.CssClass = "bolder";
                    break;
                case "Popular":
                    rptRecipes.DataSource = Recipe.Popular((page - 1) * 8);
                    hlkPopular.Enabled = false;
                    hlkPopular.CssClass = "bolder";
                    break;
                default:
                    rptRecipes.DataSource = Recipe.AllRecipes((page - 1) * 8);
                    hlkName.Enabled = false;
                    hlkName.CssClass = "bolder";
                    break;
            }
            rptRecipes.DataBind();

            //SET PAGE # LINKS

            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(Recipe.AllRecipes().Count) / 8));
            for (var i = 1; i <= totalPages; i++)
            {
                if (i == page)
                {
                    plhPages.Controls.Add(new LiteralControl("<strong>Page " + i + "</strong>"));
                }
                else
                {
                    HtmlAnchor htmlAnchor = new HtmlAnchor
                    {
                        HRef = "RecipeList.aspx?Sort=" + Request.QueryString["Sort"] + "&Page=" + i,
                        InnerText = "Page " + i,
                    };
                    plhPages.Controls.Add(htmlAnchor);
                }
                
                if(i != totalPages)
                {
                    plhPages.Controls.Add(new LiteralControl(" | "));
                }

                //SET ARROW BUTTONS

                if(page == 1)
                {
                    btnPrevious.Visible = false;
                }
                else
                {
                    btnPrevious.NavigateUrl = "RecipeList.aspx?Sort=" + Request.QueryString["Sort"] + "&Page=" + (page-1).ToString();
                }

                if(page == totalPages)
                {
                    btnNext.Visible = false;
                }
                else
                {
                    btnNext.NavigateUrl = "RecipeList.aspx?Sort=" + Request.QueryString["Sort"] + "&Page=" + (page + 1).ToString();
                }
                
            }
        }

        protected void SkipToPage(object sender, CommandEventArgs e)
        {
            Response.Redirect("RecipeList.aspx?Sort=" + Request.QueryString["Sort"] + "&Page=" + e.CommandArgument.ToString());
        }
    }
}