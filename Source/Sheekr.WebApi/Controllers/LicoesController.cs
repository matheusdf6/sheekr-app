using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheekr.Application.Escola.Licoes.Command;
using Sheekr.Application.Escola.Licoes.Query;

namespace Sheekr.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicoesController : BaseController
    {
        // GET api/licoes   
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllLicoesQuery()));
        }

        // GET api/licoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await Mediator.Send(new GetDetailLicaoQuery { Id = id }));
        }

        // POST api/licoes
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CriarLicaoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/licoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AtualizarLicaoCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/licoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await Mediator.Send(new DeletarLicaoCommand { Id = id });

            return NoContent();
        }
    }
}
