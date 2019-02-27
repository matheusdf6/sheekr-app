using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheekr.Application.Publicadores.Query;
using Sheekr.Application.Publicadores.Command;


namespace Sheekr.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicadoresController : BaseController
    {
        // GET api/publicador
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllPublicadorQuery()));
        }

        // GET api/publicador/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetDetailPublicadorQuery { PublicadorId = id }));
        }

        // POST api/publicador
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CriarPublicadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/publicador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AtualizarPublicadorCommand command)
        {
            if (command == null || command.PublicadorId != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/publicador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await Mediator.Send(new DeletarPublicadorCommand { PublicadorId = id });

            return NoContent();
        }
    }
}
