using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheekr.Application;
using Sheekr.Application.Escola.Licoes.Command;
using Sheekr.Application.Escola.Licoes.Query;
using Sheekr.Domain.Entities;

namespace Sheekr.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicoesController : BaseController
    {
        // GET api/licoes   
        [HttpGet]
        [ProducesResponseType(typeof(RequestInfo<LicaoListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllLicoesQuery()));
        }

        // GET api/licoes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestInfo<Licao>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetDetailLicaoQuery { Id = id }));
        }

        // POST api/licoes
        [HttpPost]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync([FromBody] CriarLicaoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/licoes/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AtualizarLicaoCommand command)
        {
            if (command == null || command.Id != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/licoes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeletarLicaoCommand { Id = id }));
        }
    }
}
