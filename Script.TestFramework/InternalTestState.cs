using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script.TestFramework
{
    public class InternalTestState
    {
        public InternalTestState(JasmineTestState state)
        {
            this.State = state;
        }

        public JasmineTestState State { get; set; }

        public Guid TestId
        {
            get
            {
                return State.TestId;
            }
        }
    }
}
