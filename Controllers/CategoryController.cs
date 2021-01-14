using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using tienda_pamys_api.models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tienda_pamys_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        DB_PAMYSContext db = new DB_PAMYSContext();
        
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList();
        }

        // GET api/<CursosController>/5

        [HttpGet("{id}")]
        public ActionResult GetActionResult(int id)
        {
            Category obj = db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound(new ResponseStatus(404, $"No se ha encontrado el id: {id}", null));
            }
            return Ok(new ResponseStatus(200, "Se encontro con exito", obj));
        }
        // POST api/<CursosController>
        [HttpPost]
        public ActionResult Post([FromBody] Category value)
        {
            Category obj = db.Categories.Find(value.Id);
            if (obj != null)
            {
                return BadRequest(new ResponseStatus(404, $"El codigo {value.Id} ya existe", null));
            }
            db.Categories.Add(value);
            db.SaveChanges();

            return Ok(new ResponseStatus(201, "Se registro con exito", value));
        }

        // PUT api/<CursosController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Category value)
        {
            Category obj = db.Categories.Find(value.Id);
            // si no encuentra el curso que voy a  actualizar
            if (obj == null)
            {
                return BadRequest(new ResponseStatus(404, $"El codigo no {value.Id} existe", null));
            }

            obj.Active = value.Active;
            obj.Description = value.Description;
            obj.Name = value.Name;

            db.SaveChanges();

            return Ok(new ResponseStatus(200, "Se actualizo con exito", value));
        }

        // DELETE api/<CursosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Category obj = db.Categories.Find(id);
            // si no encuentra el curso que voy a  borrar
            if (obj == null)
            {
                return BadRequest(new ResponseStatus(404, $"El codigo no {id} existe", null));
            }
            // eliminacion fisica
            // db.Categories.Remove(obj);

            obj.Active = 0;
            db.SaveChanges();
            return Ok(new ResponseStatus(200, $"Se ha borrado con exito id: {id}", obj));
        }
    }
}
