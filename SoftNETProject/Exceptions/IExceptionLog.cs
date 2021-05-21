using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftNETProject.Exceptions
{
    public interface IExceptionLog
    {
        void LogException(Exception exception, string controllerName, ILogger logger);
    }
}
