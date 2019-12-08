using eateasyapi.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eateasyapi.Models
{
    public class Recipe : Entity
    {
        public string Name {get; set; }

        public IList<Ingredient> Ingredients { get; set; }

        public Recipe() { }

        public Recipe(Recipe recipe)
        {
            Validate.NotNull(recipe?.Ingredients);
            Validate.NotEmpty(recipe.Name);

            Name = recipe.Name;
            Ingredients = recipe.Ingredients.ToList();
        }
    }
}