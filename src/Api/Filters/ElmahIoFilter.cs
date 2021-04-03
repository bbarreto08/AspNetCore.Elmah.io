using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Filters
{
    public class ElmahIoFilter : IActionFilter
    {
        protected readonly ILogger _logger;
        public ElmahIoFilter()
        {
            var factory = new LoggerFactory();
            factory.AddElmahIo("b7b67f8dbab144cfb306a11006ceaf5e", new Guid("2e059935-b9b1-4f29-9df9-01e2dfd496be"));

            _logger = new LoggerFactory().CreateLogger("elmah.io");
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            _logger.LogInformation("Request", context);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            _logger.LogInformation("Response", context);
        }
    }
}
