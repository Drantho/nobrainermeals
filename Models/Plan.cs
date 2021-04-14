using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bp2.Models;

namespace bp2.Models
{
    [Serializable]
    public class Plan
    {
        public string PlanID { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public bool Public { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

        public Double CartPrice
        {
            get
            {
                double cartPrice = 0;

                foreach(RecipeIngredient recipeIngredient in RecipeIngredients)
                {
                    cartPrice += recipeIngredient.Ingredient.Price * recipeIngredient.RecipeRequired;
                }

                return cartPrice;
            }
        }

        public void CombineIngredients()
        {
            foreach(Recipe recipe1 in Recipes)
            {
                foreach(List<RecipeIngredient> recipeIngredientsList1 in recipe1.RecipeIngredients)
                {
                    foreach(RecipeIngredient recipeIngredient1 in recipeIngredientsList1)
                    {
                        //if (recipeIngredient1.Selected)
                        {
                            recipeIngredient1.RecipeRequired = recipeIngredient1.GetRecipeRequired();



                            //search RecipeIngredients for item
                            bool found = false;
                            foreach(RecipeIngredient recipeIngredient in RecipeIngredients)
                            {
                                if(recipeIngredient.Ingredient.ExternalID == recipeIngredient1.Ingredient.ExternalID || recipeIngredient.Ingredient.Description == recipeIngredient1.Ingredient.Description)
                                {
                                    found = true;
                                    
                                    recipeIngredient.RecipeRequired += recipeIngredient1.RecipeRequired;
                                }
                            }
                            if (!found)
                            {
                                RecipeIngredients.Add(recipeIngredient1);
                            }

                            
                        }
                    }
                }
            }
            
        }        

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
            CombineIngredients();
        }
    }
}