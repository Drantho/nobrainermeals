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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Home";
            rptRecent.DataSource = Recipe.RecentRecipes;
            rptRecent.DataBind();
        }


    }
}