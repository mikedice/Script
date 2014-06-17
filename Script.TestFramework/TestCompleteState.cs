using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Script.TestFramework
{
    public class TestCompleteState
    {
        private ManualResetEvent doneEvent;

        public TestCompleteState(ManualResetEvent doneEvent)
        {
            this.doneEvent = doneEvent;
        }

        public bool Wait(int timeoutInMilliseconds)
        {
            return this.doneEvent.WaitOne(timeoutInMilliseconds);
        }
    }
}
