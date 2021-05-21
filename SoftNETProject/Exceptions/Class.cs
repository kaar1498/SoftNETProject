using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftNETProject.Exceptions
{
    public class ExceptionLogger : IExceptionLog
    {
        public void LogException(Exception exception, string controllerName, ILogger logger)
        {
            string message = $"Following exception was thrown in {controllerName}: {exception.Message}";
            logger.LogError(message, exception);
        }
    }
}
