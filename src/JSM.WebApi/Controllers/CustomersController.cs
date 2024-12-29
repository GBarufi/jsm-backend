using JSM.Application.Commands.Customers.CreateCustomer;
using JSM.Application.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JSM.WebApi.Controllers
{
    public class CustomersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomersList([FromQuery] GetCustomersQuery getCustomersQuery)
        {
            var result = await _mediator.Send(getCustomersQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomers(CreateCustomersFromJsonCommand createCustomersCommand)
        {
            var result = await _mediator.Send(createCustomersCommand);
            return Ok(result);
        }
    }
}
