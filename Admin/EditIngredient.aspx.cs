using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bp2.Models;
using Microsoft.AspNet.Identity;

namespace bp2.Admin
{
    public partial class EditIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Response.Redirect("EditRecipe.aspx");
                }
                else
                {
                    ddlIngredientUnit.DataSource = bp2.Models.Unit.Units;
                    ddlIngredientUnit.DataTextField = "Name";
                    ddlIngredientUnit.DataValueField = "UnitID";
                    ddlIngredientUnit.DataBind();

                    ddlRecipeIngredientUnit.DataSource = bp2.Models.Unit.Units;
                    ddlRecipeIngredientUnit.DataTextField = "Name";
                    ddlRecipeIngredientUnit.DataValueField = "UnitID";
                    ddlRecipeIngredientUnit.DataBind();

                    RecipeIngredient recipeIngredient = new RecipeIngredient(Request.QueryString["ID"]);
                    Recipe recipe = new Recipe(recipeIngredient.RecipeRef);
                    lblRecipe.Text = recipe.Name;
                    IngredientName.Text = recipeIngredient.Ingredient.Name;
                    IngredientDescription.Text = recipeIngredient.Ingredient.Description;
                    IngredientID.Text = recipeIngredient.Ingredient.IngredientID;
                    IngredientSource.Text = recipeIngredient.Ingredient.Source;
                    IngredientPrice.Text = recipeIngredient.Ingredient.Price.ToString();
                    IngredientPhoto.Text = recipeIngredient.Ingredient.PhotoUrl;
                    IngredientInfoLink.Text = recipeIngredient.Ingredient.InfoLink;
                    IngredientCartLink.Text = recipeIngredient.Ingredient.CartLink;
                    IngredientQuantity.Text = recipeIngredient.Ingredient.Quantity.ToString();
                    try
                    {
                        ddlIngredientUnit.Items.FindByValue(recipeIngredient.Ingredient.QuantityUnit.UnitID).Selected = true;
                    }
                    catch { }
                    RecipeIngredientQuantity.Text = recipeIngredient.Quantity.ToString();
                    try
                    {
                        ddlRecipeIngredientUnit.Items.FindByValue(recipeIngredient.Unit.UnitID).Selected = true;
                    }
                    catch { }
                    
                }
            }
        }

        protected void UpdateIngredient(object sender, EventArgs e)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient(Request.QueryString["ID"])
            {
                Quantity = Convert.ToDouble(RecipeIngredientQuantity.Text),
                Unit = Models.Unit.GetUnit(Convert.ToInt32(ddlRecipeIngredientUnit.SelectedValue)),                                
            };
            recipeIngredient.Ingredient.CartLink = IngredientCartLink.Text;            
            recipeIngredient.Ingredient.Description = IngredientDescription.Text;
            recipeIngredient.Ingredient.ExternalID = IngredientID.Text;
            recipeIngredient.Ingredient.Name = IngredientName.Text;
            recipeIngredient.Ingredient.PhotoUrl = IngredientPhoto.Text;
            recipeIngredient.Ingredient.Price = Convert.ToDouble(IngredientPrice.Text);
            recipeIngredient.Ingredient.Quantity = Convert.ToDouble(IngredientQuantity.Text);
            recipeIngredient.Ingredient.QuantityUnit = Models.Unit.GetUnit(Convert.ToInt32(ddlIngredientUnit.SelectedValue));
            recipeIngredient.Ingredient.Source = IngredientSource.Text;

            string ingredientResult = "";
            string recipeIngredientResult = "";
            try
            {
                recipeIngredientResult = recipeIngredient.UpdateRecipeIngredient();
                Convert.ToInt32(recipeIngredientResult);
                try
                {
                    ingredientResult = recipeIngredient.Ingredient.UpdateIngredient();
                    Convert.ToInt32(ingredientResult);

                    Response.Redirect("../ViewRecipe.aspx?RecipeID=" + recipeIngredient.RecipeRef);
                }
                catch
                {
                    lblResult.Text += ingredientResult;
                }
            }
            catch
            {
                lblResult.Text = recipeIngredientResult;
            }
            
        }
    }
}