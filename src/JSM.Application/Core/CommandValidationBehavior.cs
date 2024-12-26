using MediatR;

namespace JSM.Application.Core
{
    public sealed class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : RequestBase<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return default!;
            }

            var response = await next();

            return response;
        }
    }
}
