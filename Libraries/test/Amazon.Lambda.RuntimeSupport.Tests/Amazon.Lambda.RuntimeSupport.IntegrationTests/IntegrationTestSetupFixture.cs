using System.Threading.Tasks;
using Amazon.Lambda.RuntimeSupport.IntegrationTests.Helpers;
using NUnit.Framework;

namespace Amazon.Lambda.RuntimeSupport.IntegrationTests;

[SetUpFixture]
public class IntegrationTestSetupFixture
{
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        string testAppPath = null;
        string toolPath = null;
        try
        {
            TestContext.Progress.WriteLine("1");
            testAppPath = LambdaToolsHelper.GetTempTestAppDirectory(
                "../../../../../../..",
                "Libraries/test/Amazon.Lambda.RuntimeSupport.Tests/CustomRuntimeFunctionTest");
            TestContext.Progress.WriteLine("2");
            toolPath = LambdaToolsHelper.InstallLambdaTools();
            TestContext.Progress.WriteLine("3");
            LambdaToolsHelper.DotnetRestore(testAppPath);
            TestContext.Progress.WriteLine("4");
            LambdaToolsHelper.LambdaPackage(toolPath, "net6.0", testAppPath);
            TestContext.Progress.WriteLine("5");
            LambdaToolsHelper.LambdaPackage(toolPath, "net8.0", testAppPath);
            TestContext.Progress.WriteLine("6");
        }
        finally
        {
            LambdaToolsHelper.CleanUp(testAppPath);
            LambdaToolsHelper.CleanUp(toolPath);
        }
        
        try
        {
            TestContext.Progress.WriteLine("7");
            testAppPath = LambdaToolsHelper.GetTempTestAppDirectory(
                "../../../../../../..",
                "Libraries/test/Amazon.Lambda.RuntimeSupport.Tests/CustomRuntimeAspNetCoreMinimalApiTest");
            TestContext.Progress.WriteLine("8");
            toolPath = LambdaToolsHelper.InstallLambdaTools();
            TestContext.Progress.WriteLine("9");
            LambdaToolsHelper.DotnetRestore(testAppPath);
            TestContext.Progress.WriteLine("10");
            LambdaToolsHelper.LambdaPackage(toolPath, "net6.0", testAppPath);
            TestContext.Progress.WriteLine("11");
        }
        finally
        {
            LambdaToolsHelper.CleanUp(testAppPath);
            LambdaToolsHelper.CleanUp(toolPath);
        }
        
        try
        {
            TestContext.Progress.WriteLine("12");
            testAppPath = LambdaToolsHelper.GetTempTestAppDirectory(
                "../../../../../../..",
                "Libraries/test/Amazon.Lambda.RuntimeSupport.Tests/CustomRuntimeAspNetCoreMinimalApiCustomSerializerTest");
            TestContext.Progress.WriteLine("13");
            toolPath = LambdaToolsHelper.InstallLambdaTools();
            TestContext.Progress.WriteLine("14");
            LambdaToolsHelper.DotnetRestore(testAppPath);
            TestContext.Progress.WriteLine("15");
            LambdaToolsHelper.LambdaPackage(toolPath, "net6.0", testAppPath);
            TestContext.Progress.WriteLine("16");
        }
        finally
        {
            LambdaToolsHelper.CleanUp(testAppPath);
            LambdaToolsHelper.CleanUp(toolPath);
        }
    }
}