using System;
using System.Linq;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Script.TestFramework;
using Script.TestFramework.Models.Jasmine;

namespace Script.Test
{
    //todo: figure out mstest's deployment behavior
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\jasmineRunner.js", "tests")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\simpleSpec.js", "tests")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\boolSpec.js", "tests")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\SpecRunner.html","tests")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\SpecRunner.html", "tests")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\lib\jasmine-2.0.0\boot.js", @"tests\lib\jasmine-2.0.0")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\lib\jasmine-2.0.0\console.js", @"tests\lib\jasmine-2.0.0")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\lib\jasmine-2.0.0\jasmine-html.js", @"tests\lib\jasmine-2.0.0")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\lib\jasmine-2.0.0\jasmine.css", @"tests\lib\jasmine-2.0.0")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\lib\jasmine-2.0.0\jasmine.js", @"tests\lib\jasmine-2.0.0")]
    [DeploymentItem(@"C:\Users\mikedice\documents\visual studio 2013\Projects\Script\Script.TestHost\tests\lib\jasmine-2.0.0\jasmine_favicon.png", @"tests\lib\jasmine-2.0.0")]
    [DeploymentItem(@"c:\Users\mikedice\Documents\Visual Studio 2013\Projects\Script\packages\Microsoft.AspNet.WebApi.SelfHost.5.2.0-rc\lib\net45\System.Web.Http.SelfHost.dll")]
    [DeploymentItem(@"c:\Users\mikedice\Documents\Visual Studio 2013\Projects\Script\packages\Microsoft.Owin.Host.HttpListener.2.1.0\lib\net40\Microsoft.Owin.Host.HttpListener.dll")]
    [DeploymentItem(@"c:\Users\mikedice\Documents\Visual Studio 2013\Projects\Script\packages\Microsoft.Owin.Hosting.3.0.0-beta1\lib\net45\Microsoft.Owin.Hosting.dll")]
    [TestClass]
    public class SimpleTest
    {
        [TestMethod]
        public void Test1()
        {
            const string baseUrl = "http://localhost:5000/";
            int testCount = 1;
            
            // Start the test and wait 5 seconds for it to complete
            var testRunResult = ScriptTestManager.StartTest(baseUrl, testCount).Wait(50000);
            Assert.IsTrue(testRunResult, "Script test did not completed in alloted time.");

            var states = ScriptTestManager.TestStates;

            // The first jasmine test
            // check for test description
            var firstTest = states.Where(s =>
                s.Results.Any(r => r.FullName.Contains("This expects true to be true")));
            Assert.IsTrue(firstTest.Any());
            // inspect cases
            Assert.IsTrue(firstTest.First().Results.Any(r => r.Description.Equals("should always be true") &&
                                                             r.Passed));

            // The second jasmine tests
            // check for test description
            var secondTest = states.Where(s =>
                s.Results.Any(r => r.FullName.Contains("This is a simple test")));
            Assert.IsTrue(secondTest.Any());

            // inspect cases.
            Assert.IsTrue(secondTest.First().Results.Any(r => r.Description.Equals("the color to be red") &&
                                                             r.Passed));

            Assert.IsTrue(secondTest.First().Results.Any(r => r.Description.Equals("should double the value") &&
                                                             r.Passed));
        }
    }
}
