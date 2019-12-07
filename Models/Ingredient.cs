using System;
using eateasyapi.Core;

namespace eateasyapi.Models
{
    public enum FodmapSeverity
    {
        None = 0,
        Low = 1,

        Moderate = 2,

        High = 3
    }

    public class Ingredient : Entity
    {
        public string Name { get; set; }

        public FodmapSeverity Fodmap { get; set; }

        public Ingredient()
        {

        }

        public Ingredient(Ingredient ingredient)
        {
            Validate.NotNull(ingredient);
            Validate.NotEmpty(ingredient.Name);
            Validate.EnumIsDefined(typeof(FodmapSeverity), ingredient.Fodmap);

            Name = ingredient.Name;
            Fodmap = ingredient.Fodmap;
        }

    }
}