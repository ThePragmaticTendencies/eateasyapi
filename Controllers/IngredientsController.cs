using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eateasyapi.Models;

namespace eateasyapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IRepositoryAsync<Ingredient> ingredientRepository;

        public IngredientsController(IRepositoryAsync<Ingredient> ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {          
            return await ingredientRepository.Get(1000, 0);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(Guid id)
        {
            var ingredient = await ingredientRepository.GetById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public ActionResult PutIngredient(Guid id, Ingredient ingredientTransfer)
        {
            if (id != ingredientTransfer.Id)
            {
                return BadRequest();
            }

            try
            {
                ingredientRepository.Update(ingredientTransfer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ingredientRepository.ExistsById(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Ingredient> PostIngredient(Ingredient ingredientTransfer)
        {
            var ingredient = new Ingredient(ingredientTransfer);

            ingredientRepository.Insert(ingredient);

            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public ActionResult<Ingredient> DeleteIngredient(Guid id)
        {
            var ingredient = ingredientRepository.GetById(id).Result;
            if (ingredient == null)
            {
                return NotFound();
            }

            ingredientRepository.Delete(ingredient);
            return ingredient;
        }
    }
}
