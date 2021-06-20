using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Transfers;
using TemplateNetCore.Domain.Interfaces.Transfers;
using TemplateNetCore.Domain.Interfaces.Users;

namespace TemplateNetCore.Api.Controllers.Transfers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private readonly ITransferService _transferService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public TransfersController(ITransferService transferService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _transferService = transferService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromBody] PostTransferDto postTransfer)
        {
            var userId = _userService.GetLoggedUserId(_httpContextAccessor.HttpContext.User);
            await _transferService.Save(userId, postTransfer);

            return Ok();
        }
    }
}
