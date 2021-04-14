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
    public partial class EditRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }
            //if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["RecipeID"]))
                {
                    rptRecipe.DataSource = Recipe.AllRecipes();
                    rptRecipe.DataBind();
                }
                else
                {
                    Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
                    pnlForm.Visible = true;
                    pnlSelect.Visible = false;

                    if (!IsPostBack)
                    {
                        for (int i = 1; i <= 15; i++)
                        {
                            DropDownList list = this.Master.FindControl("MainContent").FindControl("ddlIngredientUnit" + i) as DropDownList;
                            list.DataSource = bp2.Models.Unit.Units;
                            list.DataTextField = "Name";
                            list.DataValueField = "UnitID";
                            list.DataBind();

                            DropDownList list2 = this.Master.FindControl("MainContent").FindControl("ddlRecipeIngredientUnit" + i) as DropDownList;
                            list2.DataSource = bp2.Models.Unit.Units;
                            list2.DataTextField = "Name";
                            list2.DataValueField = "UnitID";
                            list2.DataBind();
                        }
                    }
                }
            }
        }

        protected void AddIngredients(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe(Request.QueryString["RecipeID"]);
            
            for (int i = 1; i <= 15; i++)
            {
                TextBox name = this.Master.FindControl("MainContent").FindControl("IngredientName" + i) as TextBox;
                TextBox description = this.Master.FindControl("MainContent").FindControl("IngredientDescription" + i) as TextBox;
                TextBox id = this.Master.FindControl("MainContent").FindControl("IngredientID" + i) as TextBox;
                TextBox source = this.Master.FindControl("MainContent").FindControl("IngredientSource" + i) as TextBox;
                TextBox price = this.Master.FindControl("MainContent").FindControl("IngredientPrice" + i) as TextBox;
                TextBox photo = this.Master.FindControl("MainContent").FindControl("IngredientPhoto" + i) as TextBox;
                TextBox info = this.Master.FindControl("MainContent").FindControl("IngredientInfoLink" + i) as TextBox;
                TextBox cart = this.Master.FindControl("MainContent").FindControl("IngredientCartLink" + i) as TextBox;
                TextBox ingredientAmount = this.Master.FindControl("MainContent").FindControl("IngredientQuantity" + i) as TextBox;
                DropDownList ingredientUnit = this.Master.FindControl("MainContent").FindControl("ddlIngredientUnit" + i) as DropDownList;

                TextBox recipeIngredientAmount = this.Master.FindControl("MainContent").FindControl("RecipeIngredientQuantity" + i) as TextBox;
                DropDownList recipeIngredientUnit = this.Master.FindControl("MainContent").FindControl("ddlRecipeIngredientUnit" + i) as DropDownList;
                
                if (!string.IsNullOrEmpty(name.Text))
                {

                    Ingredient ingredient = new Ingredient
                    {
                        Name = name.Text,
                        Description = description.Text,
                        ExternalID = id.Text,
                        Source = source.Text,
                        Price = Convert.ToDouble(price.Text),
                        PhotoUrl = photo.Text,
                        InfoLink = info.Text,
                        CartLink = cart.Text,
                        Quantity = Convert.ToDouble(ingredientAmount.Text),
                        QuantityUnit = bp2.Models.Unit.GetUnit(Convert.ToInt32(ingredientUnit.SelectedValue)),
                    };

                    ingredient.IngredientID = ingredient.AddIngredientToDatabase();

                    try
                    {

                        Convert.ToInt32(ingredient.IngredientID);
                    }
                    catch
                    {
                        Response.Write("<h1>" + ingredient.IngredientID + "</h1>");
                    }


                    RecipeIngredient recipeIngredient = new RecipeIngredient
                    {
                        IngredientRef = ingredient.IngredientID,
                        RecipeRef = recipe.RecipeID,
                        Quantity = Convert.ToDouble(recipeIngredientAmount.Text),
                        Unit = bp2.Models.Unit.GetUnit(Convert.ToInt32(recipeIngredientUnit.SelectedValue))
                    };

                    recipeIngredient.RecipeIngredientID = recipeIngredient.AddRecipeIngredientToDatabase();

                    try
                    {
                        Convert.ToInt32(recipeIngredient.RecipeIngredientID);
                    }
                    catch
                    {
                        Response.Write("<h1>" + recipeIngredient.RecipeIngredientID + "</h1>");
                    }
                }

                if(i < 6)
                {
                    TextBox equipmentName = this.Master.FindControl("MainContent").FindControl("EquipmentName" + i) as TextBox;
                    TextBox equipmentDescription = this.Master.FindControl("MainContent").FindControl("EquipmentDescription" + i) as TextBox;
                    TextBox equipmentExternalID = this.Master.FindControl("MainContent").FindControl("EquipmentExternalID" + i) as TextBox;
                    TextBox equipmentSource = this.Master.FindControl("MainContent").FindControl("EquipmentSource" + i) as TextBox;
                    TextBox equipmentInfoLink = this.Master.FindControl("MainContent").FindControl("EquipmentInfoLink" + i) as TextBox;
                    TextBox equipmentCartLink = this.Master.FindControl("MainContent").FindControl("EquipmentCartLink" + i) as TextBox;
                    TextBox equipmentPhotoLink = this.Master.FindControl("MainContent").FindControl("EquipmentPhotoLink" + i) as TextBox;
                    TextBox equipmentPrice = this.Master.FindControl("MainContent").FindControl("EquipmentPrice" + i) as TextBox;
                    TextBox equipmentNotes = this.Master.FindControl("MainContent").FindControl("EquipmentNotes" + i) as TextBox;

                    if (!string.IsNullOrEmpty(equipmentName.Text))
                    {
                        Equipment equipment = new Equipment
                        {
                            CartLink = equipmentCartLink.Text,
                            Description = equipmentDescription.Text,
                            ExternalID = equipmentExternalID.Text,
                            InfoLink = equipmentInfoLink.Text,
                            Name = equipmentName.Text,
                            PhotoLink = equipmentPhotoLink.Text,
                            Source = equipmentSource.Text,
                            Price = Convert.ToDouble(equipmentPrice.Text)
                        };
                        equipment.EquipmentID = equipment.AddEquipmentToDatabase();

                        RecipeEquipment recipeEquipment = new RecipeEquipment
                        {
                            EquipmentRef = equipment.EquipmentID,
                            Notes = equipmentNotes.Text,
                            RecipeRef = Request.QueryString["RecipeID"]
                        };
                        recipeEquipment.AddRecipeEquipmentToDatabase();
                    }
                }
                
            }

            Response.Redirect("../ViewRecipe.aspx?recipeID=" + recipe.RecipeID);
        }
    }
}