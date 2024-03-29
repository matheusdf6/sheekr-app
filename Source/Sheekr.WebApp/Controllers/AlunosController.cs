﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheekr.Application.Escola;
using Sheekr.Application.Escola.Alunos.Command;
using Sheekr.Application.Escola.Alunos.Query;
using Sheekr.Application;
namespace Sheekr.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : BaseController
    {
        // GET api/alunos
        /// <summary>
        /// Listar todos os alunos
        /// </summary>
        /// <returns>Retorna os alunos do cadastro</returns>
        /// <reponse code="200">Foi retornado todos os alunos corretamente</reponse>
        [HttpGet]
        [ProducesResponseType(typeof(RequestInfo<AlunoListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllAlunosQuery()));
        }

        // GET api/alunos/5
        /// <summary>
        /// Informações de um aluno
        /// </summary>
        /// <param name="id">A chave primária do aluno</param>
        /// <response code="200">Aluno encontrado</response>
        /// <returns>Retorna os detalhes do aluno</returns>
        [ProducesResponseType(typeof(RequestInfo<AlunoDetailsModel>), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetAlunoDetailsQuery { AlunoId = id }));
        }

        // POST api/alunos
        [HttpPost]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync([FromBody]CriarAlunoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/alunos/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AtualizarAlunoCommand command)
        {
            if (command == null || command.AlunoId != id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/alunos/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeletarAlunoCommand { AlunoId = id }));
        }
    }
}
