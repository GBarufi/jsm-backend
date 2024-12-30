using JSM.Application.Core.Interfaces;
using MediatR;

namespace JSM.Application.Core
{
    public sealed class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : RequestBase<TResponse>
    {
        private readonly IPublisher _publisher;
        private readonly ICsvHelper _csvHelper;

        public CommandValidationBehavior(IPublisher publisher, ICsvHelper csvHelper)
        {
            _publisher = publisher;
            _csvHelper = csvHelper;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            bool requestIsValid = (request is ICsvRequest csvRequest) ? csvRequest.IsValid(_csvHelper) : request.IsValid();

            if (!requestIsValid)
            {
                await NotifyValidationErrors(request);
                return default!;
            }

            var response = await next();

            return response;
        }

        private async Task NotifyValidationErrors(RequestBase<TResponse> request)
        {
            if (request.ValidationResult != null)
            {
                foreach (var error in request.ValidationResult.Errors)
                    await _publisher.Publish(new Notification(NotificationKey.Request, error.ErrorMessage));
            }
        }
    }
}
