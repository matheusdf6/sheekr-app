using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheekr.Application.Escola;
using Sheekr.Application.Escola.Alunos.Command;
using Sheekr.Application.Escola.Alunos.Query;

namespace Sheekr.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : BaseController
    {
        // GET api/alunos
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllAlunosQuery()));
        }

        // GET api/alunos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await Mediator.Send(new GetAlunoDetailsQuery { AlunoId = id }));
        }

        // POST api/alunos
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CriarAlunoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AtualizarAlunoCommand command)
        {
            if(command == null || command.AlunoId != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await Mediator.Send(new DeletarAlunoCommand { AlunoId = id });

            return NoContent();
        }
    }
}
