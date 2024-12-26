using JSM.Application.Commands.Customers.CreateCustomer;
using MediatR;

namespace JSM.WebApi.HostedServices
{
    internal class RequestExternalData : IHostedService
    {
        private readonly IMediator _mediator;

        public RequestExternalData(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var requestUrl = "https://storage.googleapis.com/juntossomosmais-code-challenge/input-backend.csv";

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(requestUrl, cancellationToken);
            var command = new CreateCustomerFromCsvCommand { Content = await httpResponse.Content.ReadAsStringAsync(cancellationToken) };

            await _mediator.Send(command, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
