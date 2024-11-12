// <auto-generated/>

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Amazon.Lambda.Core;

namespace TestServerlessApp
{
    public class SimpleCalculator_Subtract_Generated
    {
        private readonly ServiceProvider serviceProvider;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public SimpleCalculator_Subtract_Generated()
        {
            SetExecutionEnvironment();
            var services = new ServiceCollection();

            // By default, Lambda function class is added to the service container using the singleton lifetime
            // To use a different lifetime, specify the lifetime in Startup.ConfigureServices(IServiceCollection) method.
            services.AddSingleton<SimpleCalculator>();
            services.AddSingleton<Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer>();

            var startup = new TestServerlessApp.Startup();
            startup.ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            // Intentionally eagerly build SimpleCalculator and its dependencies.
            // This causes time spent in the Constructor to appear on INIT_REPORTs
            _ = serviceProvider.GetRequiredService<SimpleCalculator>();
        }

        /// <summary>
        /// The generated Lambda function handler for <see cref="Subtract(int, int, TestServerlessApp.Services.ISimpleCalculatorService)"/>
        /// </summary>
        /// <param name="__request__">The API Gateway request object that will be processed by the Lambda function handler.</param>
        /// <param name="__context__">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns>Result of the Lambda function execution</returns>
        public Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse Subtract(Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest __request__, Amazon.Lambda.Core.ILambdaContext __context__)
        {
            // Create a scope for every request,
            // this allows creating scoped dependencies without creating a scope manually.
            using var scope = serviceProvider.CreateScope();
            var simpleCalculator = scope.ServiceProvider.GetRequiredService<SimpleCalculator>();
            var serializer = scope.ServiceProvider.GetRequiredService<Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer>();

            var validationErrors = new List<string>();

            var x = default(int);
            if (__request__.Headers?.Any(x => string.Equals(x.Key, "x", StringComparison.OrdinalIgnoreCase)) == true)
            {
                try
                {
                    x = (int)Convert.ChangeType(__request__.Headers.First(x => string.Equals(x.Key, "x", StringComparison.OrdinalIgnoreCase)).Value, typeof(int));
                }
                catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException || e is ArgumentException)
                {
                    validationErrors.Add($"Value {__request__.Headers.First(x => string.Equals(x.Key, "x", StringComparison.OrdinalIgnoreCase)).Value} at 'x' failed to satisfy constraint: {e.Message}");
                }
            }

            var y = default(int);
            if (__request__.Headers?.Any(x => string.Equals(x.Key, "y", StringComparison.OrdinalIgnoreCase)) == true)
            {
                try
                {
                    y = (int)Convert.ChangeType(__request__.Headers.First(x => string.Equals(x.Key, "y", StringComparison.OrdinalIgnoreCase)).Value, typeof(int));
                }
                catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException || e is ArgumentException)
                {
                    validationErrors.Add($"Value {__request__.Headers.First(x => string.Equals(x.Key, "y", StringComparison.OrdinalIgnoreCase)).Value} at 'y' failed to satisfy constraint: {e.Message}");
                }
            }

            var simpleCalculatorService = scope.ServiceProvider.GetRequiredService<TestServerlessApp.Services.ISimpleCalculatorService>();
            // return 400 Bad Request if there exists a validation error
            if (validationErrors.Any())
            {
                var errorResult = new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse
                {
                    Body = @$"{{""message"": ""{validationErrors.Count} validation error(s) detected: {string.Join(",", validationErrors)}""}}",
                    Headers = new Dictionary<string, string>
                    {
                        {"Content-Type", "application/json"},
                        {"x-amzn-ErrorType", "ValidationException"}
                    },
                    StatusCode = 400
                };
                return errorResult;
            }

            var response = simpleCalculator.Subtract(x, y, simpleCalculatorService);
            return response;
        }

        private static void SetExecutionEnvironment()
        {
            const string envName = "AWS_EXECUTION_ENV";

            var envValue = new StringBuilder();

            // If there is an existing execution environment variable add the annotations package as a suffix.
            if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(envName)))
            {
                envValue.Append($"{Environment.GetEnvironmentVariable(envName)}_");
            }

            envValue.Append("lib/amazon-lambda-annotations#{ANNOTATIONS_ASSEMBLY_VERSION}");

            Environment.SetEnvironmentVariable(envName, envValue.ToString());
        }
    }
}