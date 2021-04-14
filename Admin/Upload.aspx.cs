using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;
using Microsoft.AspNet.Identity;

namespace bp2.Admin
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }
            if (string.IsNullOrEmpty(Request.QueryString["PhotoType"]) || string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                pnlRecipe.Visible = true;
                pnlSelect.Visible = false;

                rptRecipe.DataSource = Recipe.AllRecipes();
                rptRecipe.DataBind();
            }
            else
            {
                Recipe recipe = new Recipe(Request.QueryString["ID"]);
                rptPhotos.DataSource = recipe.Photos;
                rptPhotos.DataBind();
                lblName.Text = recipe.Name + " " + recipe.Photos.Count;
            }
        }

        protected void UploadFile(Object s, EventArgs e)
        {
            // First we check to see if the user has selected a file
            if (fileUpload.HasFile)
            {
                // Find the fileUpload control
                string filename = Request.QueryString["PhotoType"] + "-" + Request.QueryString["ID"] + "-" + NextPhotoNumber().ToString();

                // Check if the directory we want the image uploaded to actually exists or not


                // Specify the upload directory
                string directory = Server.MapPath(@"../images/");

                // Create a bitmap of the content of the fileUpload control in memory
                Bitmap originalBMP = new Bitmap(fileUpload.FileContent);

                // Calculate the new image dimensions
                decimal origWidth = originalBMP.Width;
                decimal origHeight = originalBMP.Height;
                decimal sngRatio = origWidth / origHeight;
                decimal newWidth = 240;
                decimal newHeight = newWidth / sngRatio;

                decimal largeWidth = 1200;
                decimal largeHeight = largeWidth / sngRatio;

                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, Convert.ToInt32(newWidth), Convert.ToInt32(newHeight));

                Bitmap largeBMP = new Bitmap(originalBMP, Convert.ToInt32(largeWidth), Convert.ToInt32(largeHeight));
                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);

                Graphics largeGraphics = Graphics.FromImage(largeBMP);

                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, Convert.ToInt32(newWidth), Convert.ToInt32(newHeight));

                largeGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                largeGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the new graphic based on the resized bitmap
                largeGraphics.DrawImage(largeBMP, 0, 0, Convert.ToInt32(largeWidth), Convert.ToInt32(largeHeight));

                // Save the new graphic file to the server
                newBMP.Save(directory + filename + "thumb.jpg");
                //originalBMP.Save(directory + filename + "full.jpg");
                largeBMP.Save(directory + filename + "full.jpg");

                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();

                // Write a message to inform the user all is OK
                lblResult.Text = "File Name: <b style='color: red;'>" + filename + "</b><br>";
                lblResult.Text += "Content Type: <b style='color: red;'>" + fileUpload.PostedFile.ContentType + "</b><br>";
                lblResult.Text += "File Size: <b style='color: red;'>" + fileUpload.PostedFile.ContentLength.ToString() + "</b>";
                // Display the image to the user
                imgResult.Visible = true;
                lblResult.Text += "newWidth: " + newWidth.ToString() + "<br>";
                lblResult.Text += "newHeight: " + newHeight.ToString() + "<br>";
                lblResult.Text += "originalWidth: " + origWidth.ToString() + "<br>";
                lblResult.Text += "originalHeight: " + origHeight.ToString() + "<br>";
                lblResult.Text += "newWidth: " + sngRatio.ToString() + "<br>";
                imgResult.ImageUrl = @"../images/" + filename + "thumb.jpg";
            }
            else
            {
                lblResult.Text = "No file uploaded!";
            }
        }

        private int NextPhotoNumber()
        {
            int number = 1;

            while (File.Exists(Server.MapPath(@"../images/" + Request.QueryString["PhotoType"] + "-" + Request.QueryString["ID"] + "-" + number + "thumb.jpg")))
            {
                number++;
            }

            return number;
        }
    }
}