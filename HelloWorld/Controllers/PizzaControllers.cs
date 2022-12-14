using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaControllers : ControllerBase
    {
        public PizzaControllers() { }


        
        [AcceptVerbs("Get")]
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();



        [AcceptVerbs("Get")]
        [HttpGet("{id}")]
        [Route("Get")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();
            return pizza;
        }



        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.ID }, pizza);
        }



        [AcceptVerbs("Put")]
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.ID)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }



        [AcceptVerbs("Delete")]
        [HttpDelete("{id}")]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}