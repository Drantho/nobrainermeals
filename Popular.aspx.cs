using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;

namespace bp2
{
    public partial class Popular : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Popular Recipes";
            rptRecipes.DataSource = Recipe.Popular(0);
            rptRecipes.DataBind();

            if (!IsPostBack)
            {
                hdnStartNumber.Value = "0";
                btnPrevious.Visible = false;
                btnNext.Visible = Recipe.Popular().Count >= Convert.ToInt32(hdnStartNumber.Value) + 6;
            }
        }

        protected void GetPrevious(object sender, EventArgs e)
        {
            GetRecipes(false);
        }

        protected void GetNext(object sender, EventArgs e)
        {
            GetRecipes(true);
        }

        protected void GetRecipes(bool next)
        {
            int startNumber = Convert.ToInt32(hdnStartNumber.Value);

            if (next)
            {
                startNumber += 6;
            }
            else
            {
                startNumber -= 6;
            }
            hdnStartNumber.Value = startNumber.ToString();

            btnPrevious.Visible = startNumber > 0;
            btnNext.Visible = Recipe.Popular().Count >= startNumber + 6;

            rptRecipes.DataSource = Recipe.Popular(startNumber);
            rptRecipes.DataBind();
        }
    }
}