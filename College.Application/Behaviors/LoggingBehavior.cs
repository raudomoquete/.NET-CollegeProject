using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace College.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now}: Handling {typeof(TRequest).Name}");
            IList<PropertyInfo> props = new List<PropertyInfo>(request.GetType().GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
            }

            var response = await next();

            _logger.LogInformation($"{DateTime.Now}: Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
