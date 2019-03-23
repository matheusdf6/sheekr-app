using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sheekr.Application.Escola.Desigacoes.Command;
using Sheekr.Application.Escola.PdfGenerator;
using Sheekr.Application.Escola.Desigacoes.Query;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Sheekr.Application;

namespace Sheekr.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DesignacoesController : BaseController
    {
        // GET api/designacoes
        [HttpGet]
        [ProducesResponseType(typeof(RequestInfo<DesignacaoListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int qtde)
        {
            return Ok(await Mediator.Send(new GetAllDesignacoesQuery()));
        }

        // GET api/designacoes/gerarpdf
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(File), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GerarPdf([FromBody] PdfGenerateCommand command)
        {
            var sucess = await Mediator.Send(command);
            if (sucess == true)
            {
                var stream = new FileStream(@"C:\Users\mathe\source\repos\Sheekr\Sheekr.Application\Resources\GeneratedFiles\" + command.NomeArquivo, FileMode.Open);
                return File(stream, "application/pdf", command.NomeArquivo);
            }
            else
                return BadRequest();
        }

        // GET api/designacoes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RequestInfo<DesignacaoDetailModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetDetailDesignacaoQuery { Id = id }));
        }

        // POST api/designacoes
        [HttpPost]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync([FromBody]DesignarCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/designacoes/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AtualizarDesignacaoCommand command)
        {
            if (command == null || command.DesignacaoId != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/designacoes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new CancelarDesignacaoCommand { Id = id }));
        }
    }
}
