using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sheekr.Application.Security;
using Sheekr.Application.Security.Query;
using Microsoft.AspNetCore.Authorization;

namespace Sheekr.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : BaseController
    {       
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllUsuariosQuery()));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Criar ([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
