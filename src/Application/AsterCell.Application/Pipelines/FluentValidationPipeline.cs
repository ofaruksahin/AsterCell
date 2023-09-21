using AsterCell.Application.Common.Models;
using FluentValidation;
using MediatR;
using System.Net;

namespace AsterCell.Application.Pipelines
{
    public class FluentValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApiResponse
    {
        private IServiceProvider _serviceProvider;

        public FluentValidationPipeline(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = _serviceProvider.GetService(typeof(IValidator<TRequest>));
            if (validator != null && validator is IValidator<TRequest> requestValidator)
            {
                var validationResult = requestValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    var errorMessages = validationResult.Errors.Select(f => f.ErrorMessage).ToList();
                    return (TResponse)ApiResponse.Fail(new NoContent(), errorMessages, (int)HttpStatusCode.BadRequest);
                }
            }

            return await next();
        }
    }
}
