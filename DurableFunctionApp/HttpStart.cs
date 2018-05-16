using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace DurableFunctionApp
{
    public static class HttpStart
    {
        [FunctionName("HttpStart")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "orchestrators/{functionName}")]HttpRequestMessage req,
            [OrchestrationClient] DurableOrchestrationClientBase starter,
            string functionName,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

           

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<LSAMessage>();

            string instanceId = await starter.StartNewAsync(functionName, data);



            return req.CreateResponse(HttpStatusCode.OK, "Hello ");
        }
    }
}
