using JSM.Application.Commands.Users.CreateUser;
using JSM.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JSM.WebApi.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsersList([FromQuery] GetUsersQuery getUsersQuery)
        {
            var result = await _mediator.Send(getUsersQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddUsers(CreateUsersFromJsonCommand createUsersCommand)
        {
            var result = await _mediator.Send(createUsersCommand);
            return Ok(result);
        }
    }
}
