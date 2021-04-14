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
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }
        }

        protected void ProcessSubmit(object sender, EventArgs e)
        {
            NewsItem news = new NewsItem
            {
                Body = txtBody.Text,
                Title = txtTitle.Text,
                Posted = DateTime.Now
            };

            string result = "";
            result = news.AddNewsToDatabase();

            try
            {
                Convert.ToInt32(result);
                Response.Redirect("../News.aspx");
            }
            catch
            {
                lblResult.Text = result;
            }
        }
    }
}