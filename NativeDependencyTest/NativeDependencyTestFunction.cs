using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;

namespace NativeDependencyTest
{
	public static class NativeDependencyTestFunction
    {
        [FunctionName("NativeDependencyTestFunction")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

			try
			{
				string version = FreeImageAPI.FreeImageEngine.Version;
				return new OkObjectResult(version);
			}
			catch(Exception e)
			{
				return new OkObjectResult($"failed - {e.Message}");
			}
        }
    }
}
