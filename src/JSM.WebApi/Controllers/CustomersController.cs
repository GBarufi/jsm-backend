using JSM.Application.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JSM.WebApi.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private const string _routeBase = "v1/customers";
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route($"{_routeBase}")]
        public async Task<ActionResult> GetCustomersList([FromQuery] GetCustomersQuery getCustomersQuery)
        {
            var result = await _mediator.Send(getCustomersQuery);
            return Ok(result);
        }
    }
}
