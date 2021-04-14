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
    public partial class AddRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Context.User.Identity.GetUserName() != "NoBrainerMeals")
            {
                Response.Redirect("NotAuthorized.aspx");
            }

            if (!IsPostBack)
            {
                for(int i=1; i<=15; i++)
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

        protected void ProcessSubmit(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe
            {
                Name = Name.Text,
                Description = Description.Text,
                CookTime = Convert.ToDouble(CookTime.Text),
                PrepTime = Convert.ToDouble(PrepTime.Text),
                Posted = DateTime.Now,
                InitialYield = Convert.ToInt32(Yield.Text),
                Yield = Convert.ToInt32(Yield.Text), 
                Tags = Tags.Text.Split(',').ToList(),
                Directions = new List<string>()
            };

            for(int i=1; i<=15; i++)
            {
                TextBox direction = this.Master.FindControl("MainContent").FindControl("Step" + i) as TextBox;
                if (!string.IsNullOrEmpty(direction.Text))
                {
                    recipe.Directions.Add(direction.Text);
                }                
            }

            recipe.RecipeID = recipe.AddRecipeToDatabase();

            for(int j=1; j<=15; j++)
            {
                TextBox name = this.Master.FindControl("MainContent").FindControl("IngredientName" + j) as TextBox;
                TextBox description = this.Master.FindControl("MainContent").FindControl("IngredientDescription" + j) as TextBox;
                TextBox id = this.Master.FindControl("MainContent").FindControl("IngredientID" + j) as TextBox;
                TextBox source = this.Master.FindControl("MainContent").FindControl("IngredientSource" + j) as TextBox;
                TextBox price = this.Master.FindControl("MainContent").FindControl("IngredientPrice" + j) as TextBox;
                TextBox photo = this.Master.FindControl("MainContent").FindControl("IngredientPhoto" + j) as TextBox;
                TextBox info = this.Master.FindControl("MainContent").FindControl("IngredientInfoLink" + j) as TextBox;
                TextBox cart = this.Master.FindControl("MainContent").FindControl("IngredientCartLink" + j) as TextBox;
                TextBox ingredientAmount = this.Master.FindControl("MainContent").FindControl("IngredientQuantity" + j) as TextBox;
                DropDownList ingredientUnit = this.Master.FindControl("MainContent").FindControl("ddlIngredientUnit" + j) as DropDownList;

                TextBox recipeIngredientAmount = this.Master.FindControl("MainContent").FindControl("RecipeIngredientQuantity" + j) as TextBox;
                DropDownList recipeIngredientUnit = this.Master.FindControl("MainContent").FindControl("ddlRecipeIngredientUnit" + j) as DropDownList;

                if(j < 6)
                {
                    TextBox equipmentName = this.Master.FindControl("MainContent").FindControl("EquipmentName" + j) as TextBox;
                    TextBox equipmentSource = this.Master.FindControl("MainContent").FindControl("EquipmentSource" + j) as TextBox;
                    TextBox equipmentExternalID = this.Master.FindControl("MainContent").FindControl("EquipmentExternalID" + j) as TextBox;
                    TextBox equipmentInfoLink = this.Master.FindControl("MainContent").FindControl("EquipmentInfoLink" + j) as TextBox;
                    TextBox equipmentCartLink = this.Master.FindControl("MainContent").FindControl("EquipmentCartLink" + j) as TextBox;
                    TextBox equipmentPhotoLink = this.Master.FindControl("MainContent").FindControl("EquipmentPhotoLink" + j) as TextBox;
                    TextBox equipmentPrice = this.Master.FindControl("MainContent").FindControl("EquipmentPrice" + j) as TextBox;
                    TextBox equipmentDescription = this.Master.FindControl("MainContent").FindControl("EquipmentDescription" + j) as TextBox;
                    TextBox equipmentNotes = this.Master.FindControl("MainContent").FindControl("EquipmentNotes" + j) as TextBox;

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
                            Price = Convert.ToDouble(equipmentPrice.Text),
                            Source = equipmentSource.Text
                        };

                        //try
                        //{
                            equipment.EquipmentID = equipment.AddEquipmentToDatabase();
                            //Convert.ToInt32(equipment.EquipmentID);
                        //}
                        //catch
                        { }

                        RecipeEquipment recipeEquipment = new RecipeEquipment
                        {
                            EquipmentRef = equipment.EquipmentID,
                            RecipeRef = recipe.RecipeID,
                            Notes = equipmentNotes.Text
                        };

                        try
                        {
                            recipeEquipment.RecipeEquipmentID = recipeEquipment.AddRecipeEquipmentToDatabase();
                            Convert.ToInt32(recipeEquipment.RecipeEquipmentID);
                        }
                        catch { }
                    }
                }
                

                if (!string.IsNullOrEmpty(name.Text))
                {
                    //Response.Write("<h1>Ingredient Name " + j + ": " + name.Text + ".</h1>");

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
                        QuantityUnit = bp2.Models.Unit.GetUnit(Convert.ToInt32( ingredientUnit.SelectedValue)),                        
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
                //else
                {
                    //break;
                }
            }

            Response.Redirect("../default.aspx?recipeID=" + recipe.RecipeID);
        }
    }
}