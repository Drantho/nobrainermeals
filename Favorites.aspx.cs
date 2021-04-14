using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using bp2.Models;
using Microsoft.AspNet.Identity;

namespace bp2
{
    public partial class Favorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Context.User.Identity.GetUserName()))
            {
                Response.Redirect("/Account/Login");
            }

            int page = Convert.ToInt32(Request.QueryString["Page"]);

            if (page < 1)
            {
                page = 1;
            }

            rptRecipes.DataSource = Recipe.Favorites(Context.User.Identity.GetUserName(), (page - 1) * 8);
            rptRecipes.DataBind();

            //SET PAGE # LINKS

            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(Recipe.Favorites(Context.User.Identity.GetUserName()).Count) / 8));
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
                        HRef = "Favorites.aspx?Page=" + i,
                        InnerText = "Page " + i,
                    };
                    plhPages.Controls.Add(htmlAnchor);
                }

                if (i != totalPages)
                {
                    plhPages.Controls.Add(new LiteralControl(" | "));
                }

                //SET ARROW BUTTONS

                if (page == 1)
                {
                    btnPrevious.Visible = false;
                }
                else
                {
                    btnPrevious.NavigateUrl = "Favorites.aspx?Page=" + (page - 1).ToString();
                }

                if (page == totalPages)
                {
                    btnNext.Visible = false;
                }
                else
                {
                    btnNext.NavigateUrl = "Favorites.aspx?Page=" + (page + 1).ToString();
                }

            }
        }

        protected void SkipToPage(object sender, CommandEventArgs e)
        {
            Response.Redirect("Favorites.aspx?Page=" + e.CommandArgument.ToString());
        }
    }
}