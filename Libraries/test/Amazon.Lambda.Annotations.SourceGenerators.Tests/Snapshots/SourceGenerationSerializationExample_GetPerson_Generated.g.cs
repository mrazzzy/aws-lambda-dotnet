// <auto-generated/>

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations.APIGateway;

namespace TestExecutableServerlessApp
{
    public class SourceGenerationSerializationExample_GetPerson_Generated
    {
        private readonly SourceGenerationSerializationExample sourceGenerationSerializationExample;
        private readonly Amazon.Lambda.Serialization.SystemTextJson.SourceGeneratorLambdaJsonSerializer<TestExecutableServerlessApp.HttpApiJsonSerializerContext> serializer;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public SourceGenerationSerializationExample_GetPerson_Generated()
        {
            SetExecutionEnvironment();
            sourceGenerationSerializationExample = new SourceGenerationSerializationExample();
            serializer = new Amazon.Lambda.Serialization.SystemTextJson.SourceGeneratorLambdaJsonSerializer<TestExecutableServerlessApp.HttpApiJsonSerializerContext>();
        }

        /// <summary>
        /// The generated Lambda function handler for <see cref="GetPerson(Amazon.Lambda.Core.ILambdaContext)"/>
        /// </summary>
        /// <param name="__request__">The API Gateway request object that will be processed by the Lambda function handler.</param>
        /// <param name="__context__">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns>Result of the Lambda function execution</returns>
        public System.IO.Stream GetPerson(Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest __request__, Amazon.Lambda.Core.ILambdaContext __context__)
        {
            var httpResults = sourceGenerationSerializationExample.GetPerson(__context__);
            HttpResultSerializationOptions.ProtocolFormat serializationFormat = HttpResultSerializationOptions.ProtocolFormat.RestApi;
            HttpResultSerializationOptions.ProtocolVersion serializationVersion = HttpResultSerializationOptions.ProtocolVersion.V1;
            var serializationOptions = new HttpResultSerializationOptions { Format = serializationFormat, Version = serializationVersion, Serializer = serializer };
            var response = httpResults.Serialize(serializationOptions);
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

            envValue.Append("lib/amazon-lambda-annotations#1.4.0.0");

            Environment.SetEnvironmentVariable(envName, envValue.ToString());
        }
    }
}