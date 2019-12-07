using eateasyapi.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eateasyapi.Models
{
    public class Recipe : Entity
    {
        private IList<Ingredient> ingredients;

        public string Name {get; }

        public IEnumerable<Ingredient> Ingredients => ingredients;

        public Recipe() { }

        public Recipe(Recipe recipe)
        {
            Validate.NotNull(recipe?.Ingredients);
            Validate.NotEmpty(recipe.Name);

            Name = recipe.Name;
            ingredients = recipe.Ingredients.ToList();
        }
    }
}