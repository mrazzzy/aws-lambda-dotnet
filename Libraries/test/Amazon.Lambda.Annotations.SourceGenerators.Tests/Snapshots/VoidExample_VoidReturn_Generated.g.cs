using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Amazon.Lambda.Core;

namespace TestServerlessApp
{
    public class VoidExample_VoidReturn_Generated
    {
        private readonly VoidExample voidExample;
        private readonly Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer serializer;

        public VoidExample_VoidReturn_Generated()
        {
            SetExecutionEnvironment();
            voidExample = new VoidExample();
            serializer = new Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer();
        }

        public void VoidReturn(string text, Amazon.Lambda.Core.ILambdaContext __context__)
        {
            voidExample.VoidReturn(text, __context__);
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

            envValue.Append("lib/amazon-lambda-annotations#1.3.1.0");

            Environment.SetEnvironmentVariable(envName, envValue.ToString());
        }
    }
}