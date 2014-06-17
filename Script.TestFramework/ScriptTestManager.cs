using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Script.TestFramework.Models.Jasmine;

namespace Script.TestFramework
{
    public static class ScriptTestManager
    {
        private static readonly IDictionary<Guid, InternalTestState> TestList = new Dictionary<Guid, InternalTestState>();
        private static int testCount = 0;
        private static int testsCompleted = 0;
        private static ManualResetEvent testsCompletedEvent = new ManualResetEvent(false);
        private static IDisposable owinHost;
        private static TestCompleteState testCompleteState;

        /// <summary>
        /// Registers a new test that is about to run
        /// </summary>
        /// <param name="state">The test state that contains details about the test.</param>
        /// <returns>Interface to track the test</returns>
        public static void RegisterTest(JasmineTestState state)
        {
            var newState = new InternalTestState(state);
            TestList.Add(state.TestId, newState);
        }

        /// <summary>
        /// Recoreds the result of a test case in a test.
        /// </summary>
        /// <param name="id">The identifier of the test.</param>
        /// <param name="result">The result of the test case.</param>
        public static void RecoredResult(Guid id, JasmineTestResult result)
        {
            var its = TestList[id];
            its.State.RecordResult(result);
        }

        /// <summary>
        /// Record the completion of a test.
        /// </summary>
        /// <param name="id">The ID of the test that has completed</param>
        public static void CompleteTest(Guid id)
        {
            if (TestList.ContainsKey(id))
            {
                if (++testsCompleted >= testCount)
                {
                    testsCompletedEvent.Set();
                    owinHost.Dispose();
                }
            }
        }

        public static IEnumerable<JasmineTestState> TestStates
        {
            get
            {
                return TestList.Select(kvp => (JasmineTestState) kvp.Value.State).ToList();
            }
        }

        public static TestCompleteState StartTest(string baseUrl, int testCount)
        {
            ScriptTestManager.testCount = testCount;
            
            // start the owinHost
            ScriptTestManager.owinHost = WebApp.Start<Startup>(baseUrl);

            // TODO: launch the browser

            testCompleteState = new TestCompleteState(testsCompletedEvent);
            return testCompleteState;
        }
    }
}
