using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

namespace TestServerlessApp
{
    public class Greeter
    {
        [LambdaFunction(Name = "GreeterSayHello", MemorySize = 1024)]
        [HttpApi(HttpMethod.Get, HttpApiVersion.V1, "/Greeter/SayHello")]
        public void SayHello([FromQuery(Name = "names")]IEnumerable<string> firstNames, APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.Log($"Request {JsonSerializer.Serialize(request)}");

            if (firstNames == null)
            {
                return;
            }

            foreach (var firstName in firstNames)
            {
                Console.WriteLine($"Hello {firstName}");
            }
        }

        [LambdaFunction(Name = "GreeterSayHelloAsync", Timeout = 50)]
        [HttpApi(HttpMethod.Get, HttpApiVersion.V1, "/Greeter/SayHelloAsync")]
        public async Task SayHelloAsync([FromHeader(Name = "names")]IEnumerable<string> firstNames)
        {
            if (firstNames == null)
            {
                return;
            }

            foreach (var firstName in firstNames)
            {
                Console.WriteLine($"Hello {firstName}");
            }
            await Task.CompletedTask;
        }
    }
}