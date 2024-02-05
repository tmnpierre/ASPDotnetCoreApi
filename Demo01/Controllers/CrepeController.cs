using Demo01.Data;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrepeController : ControllerBase
    {
        private readonly CrepeFakeDb _fakeDb;

        public CrepeController(CrepeFakeDb fakeDb) { _fakeDb = fakeDb; }

        [HttpGet]
        public IActionResult Get()
        {
            var crepes = _fakeDb.Crepes;

            if (crepes.Any())
                return Ok(crepes);
            //else
            //    return NotFound(); //404 implique que le fait de ne pas trouver de crepes est une erreur.
            else
                return NoContent(); // 204 implique que le fait de ne pas trouver de crepes n'est pas une erreur.
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var crepe = _fakeDb.Crepes.FirstOrDefault(c => c.Id == id);

            if (crepe == null)
                return NotFound(new { Message = "Crepe non trouvée !" });
            else
                return Ok(new { Message = "Crepe trouvée !", Crepe = crepe }) ;
        }
    }
}
