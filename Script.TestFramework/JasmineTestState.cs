using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Script.TestFramework.Models.Jasmine;

namespace Script.TestFramework
{
    public class JasmineTestState
    {
        public JasmineTestState()
        {
            this.TestId = Guid.NewGuid();
            Results = new List<JasmineTestResult>();
        }
        
        public Guid TestId { get; private set; }

        public void RecordResult(JasmineTestResult testResult)
        {
            ((List<JasmineTestResult>) Results).Add(testResult);
        }
        
        public IEnumerable<JasmineTestResult> Results { get; private set; }
    }
}
