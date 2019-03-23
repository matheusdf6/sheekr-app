using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheekr.Application.Publicadores.Query;
using Sheekr.Application.Publicadores.Command;
using Sheekr.Application;
using System.Net;

namespace Sheekr.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicadoresController : BaseController
    {
        // GET api/publicador
        [HttpGet]
        [ProducesResponseType(typeof(RequestInfo<PublicadorListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllPublicadorQuery()));
        }

        // GET api/publicador/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestInfo<PublicadorDetailModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetDetailPublicadorQuery { PublicadorId = id }));
        }

        // POST api/publicador
        [HttpPost]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync([FromBody]CriarPublicadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/publicador/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AtualizarPublicadorCommand command)
        {
            if (command == null || command.PublicadorId != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteManyAsync([FromBody] DeletarVariosPublicadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/publicador/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeletarPublicadorCommand { PublicadorId = id }));
        }
    }
}
