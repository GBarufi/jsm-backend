using JSM.Application.Commands.Customers.CreateCustomer;
using MediatR;

namespace JSM.WebApi.HostedServices
{
    internal class RequestExternalData : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public RequestExternalData(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var requestUrl = _configuration.GetValue("StartupRequestUrl", string.Empty);

            if (string.IsNullOrEmpty(requestUrl))
                throw new ArgumentException(nameof(requestUrl));

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(requestUrl!, cancellationToken!);
            var command = new CreateCustomerFromCsvCommand { Content = await httpResponse.Content.ReadAsStringAsync(cancellationToken) };

            await _mediator.Send(command, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
