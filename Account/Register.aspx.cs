using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using bp2.Models;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace bp2.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            bool userUnique = true;
            using(SqlConnection connection = MyConnection.CurrentConnection)
            {
                string query = "Select top 1 UserName FROM aspnetusers WHERE UserName = @UserName";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName.Text);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        userUnique = !reader.HasRows;
                    }
                }
                connection.Close();
            }

            if (userUnique)
            {
                var user = new ApplicationUser() { UserName = UserName.Text, Email = Email.Text };
                IdentityResult result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    string code = manager.GenerateEmailConfirmationToken(user.Id);
                    string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking " + callbackUrl);


                    if (user.EmailConfirmed)
                    {
                        signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                    else
                    {
                        ErrorMessage.Text = "An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
                    }
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            else
            {
                ErrorMessage.Text = "User Name unavailable.";
            }
            
            
        }
    }
}