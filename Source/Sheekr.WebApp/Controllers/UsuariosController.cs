using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sheekr.Application.Security;
using Sheekr.Application.Security.Query;
using Microsoft.AspNetCore.Authorization;
using Sheekr.Application;
using System.Net;
using Sheekr.Domain.Entities;

namespace Sheekr.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(RequestInfo<UsuarioListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllUsuariosQuery()));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(RequestInfo<UsuarioDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(RequestInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Criar([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
