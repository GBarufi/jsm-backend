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
            if (typeof(TRequest).IsSubclassOf(typeof(CsvRequestBase<TResponse>)))
            {
                var csvRequest = (request as CsvRequestBase<TResponse>)!;
                if (!csvRequest.IsValid(_csvHelper))
                    return default!;
            } 
            else
            {
                if (!request.IsValid())
                    return default!;
            }
            
            var response = await next();

            return response;
        }
    }
}
