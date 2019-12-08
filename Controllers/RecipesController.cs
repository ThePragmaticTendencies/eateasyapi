using System;
using eateasyapi.Core;
using eateasyapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eateasyapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRepositoryAsync<Recipe> recipeRepository;

        public RecipesController(IRepositoryAsync<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await recipeRepository.Get(1000, 0);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
        {
            var recipe = await recipeRepository.GetById(id);

            if(recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpPost]
        public ActionResult<Recipe> PostRecipe(Recipe recipeTransfer)
        {
            var recipe = new Recipe(recipeTransfer);

            recipeRepository.Insert(recipe);

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }
    }
}