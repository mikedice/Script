using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Script.TestFramework.Models.Jasmine;

namespace Script.TestFramework
{
    /// <summary>
    /// Tests controller API
    /// </summary>
    public class TestsController : ApiController
    {
        /// <summary>
        /// A test case has finished and posted its results back here
        /// POST Tests/{id}/result
        /// </summary>
        /// <param name="result">A test result from Jasmine.</param>
        [HttpPost]
        public void Result(string id, JasmineTestResult result)
        {
            if (result != null)
            {
                Console.WriteLine("[{0}] {1}: {2}", result.Status, result.FullName, result.Description);
                ScriptTestManager.RecoredResult(Guid.Parse(id), result);
            }
            else
            {
                Console.WriteLine("Invalid result from test javascript");
            }
        }

        // POST Tests/NewTest
        [HttpPost]
        public HttpResponseMessage NewTest()
        {
            var state = new JasmineTestState();
            ScriptTestManager.RegisterTest(state);
            Console.WriteLine("starting new test with id {0}", state.TestId);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(state.TestId.ToString());
            return response;
        }

        // POST Tests/{id}/complete
        [HttpPost]
        public void Complete(string id)
        {
            Console.WriteLine("completed test with id {0}", id);
            ScriptTestManager.CompleteTest(Guid.Parse(id));
        }
    }
}
