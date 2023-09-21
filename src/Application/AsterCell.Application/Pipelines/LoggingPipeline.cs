using AsterCell.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using AsterCell.Common.Extensions;

namespace AsterCell.Application.Pipelines
{
    public class LoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApiResponse
    {
        private readonly ILogger<LoggingPipeline<TRequest, TResponse>> _logger;

        public LoggingPipeline(ILogger<LoggingPipeline<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestBody = await request.Serialize();

            _logger.LogInformation("Command name {0}, command start date {1}, command request body {2}",
                typeof(TRequest).Name,
                DateTime.Now,
                requestBody);

            var response =  await next();
            var responseBody = await response.Serialize();

            _logger.LogInformation("Command name {0}, command end date {1}, command response body {2}",
                typeof(TRequest).Name,
                DateTime.Now,
                responseBody);

            return response;
        }
    }
}
