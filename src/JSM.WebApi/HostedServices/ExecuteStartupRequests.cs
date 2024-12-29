using JSM.Application.Commands.Customers.CreateCustomer;
using MediatR;
using Newtonsoft.Json;

namespace JSM.WebApi.HostedServices
{
    internal class ExecuteStartupRequests : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public ExecuteStartupRequests(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();

            await ExecuteCsvRequest(httpClient, cancellationToken);
            await ExecuteJsonRequest(httpClient, cancellationToken);
        }

        private async Task ExecuteCsvRequest(HttpClient client, CancellationToken cancellationToken)
        {
            var requestUrl = _configuration.GetValue("StartupCsvRequestUrl", string.Empty);

            if (string.IsNullOrEmpty(requestUrl))
                throw new ArgumentException(nameof(requestUrl));

            var httpResponse = await client.GetAsync(requestUrl!, cancellationToken!);
            httpResponse.EnsureSuccessStatusCode();

            var command = new CreateCustomerFromCsvCommand { Content = await httpResponse.Content.ReadAsByteArrayAsync(cancellationToken) };

            await _mediator.Send(command, cancellationToken);
        }

        private async Task ExecuteJsonRequest(HttpClient client, CancellationToken cancellationToken)
        {
            var requestUrl = _configuration.GetValue("StartupJsonRequestUrl", string.Empty);

            if (string.IsNullOrEmpty(requestUrl))
                throw new ArgumentException(nameof(requestUrl));

            var httpResponse = await client.GetAsync(requestUrl!, cancellationToken!);
            httpResponse.EnsureSuccessStatusCode();

            var jsonString = httpResponse.Content.ReadAsStringAsync(cancellationToken).Result;
            var command = JsonConvert.DeserializeObject<CreateCustomersFromJsonCommand>(jsonString);

            if (command is null)
                throw new ArgumentException(nameof(CreateCustomersFromJsonCommand));

            await _mediator.Send(command, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
