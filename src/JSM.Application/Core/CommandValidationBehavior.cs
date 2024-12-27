using JSM.Application.Core.Interfaces;
using MediatR;

namespace JSM.Application.Core
{
    public sealed class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : RequestBase<TResponse>
    {
        private readonly ICsvHelper _csvHelper;
        public CommandValidationBehavior(ICsvHelper csvHelper)
        {
            _csvHelper = csvHelper;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            bool requestIsValid = (request is ICsvRequest csvRequest) ? csvRequest.IsValid(_csvHelper) : request.IsValid();

            if (!requestIsValid)
                return default!;
                
            var response = await next();

            return response;
        }
    }
}
