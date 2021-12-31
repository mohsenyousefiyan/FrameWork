using FrameWork.Core.Domain.ApplicationServices.Commands;
using FrameWork.EndPoints.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrameWork.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCommandAPIController : ControllerBase
    {
        protected readonly CommandDispatcher commandDispatcher;
        protected readonly CommandRequestHandler requestHandler;

        public BaseCommandAPIController(CommandDispatcher commandDispatcher, CommandRequestHandler requestHandler)
        {
            this.commandDispatcher = commandDispatcher;
            this.requestHandler = requestHandler;
        }
    }
}
