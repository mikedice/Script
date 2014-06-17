using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script.TestFramework
{
    public interface ITestState
    {
        Guid TestId { get; }

        void RecordResult<T>(T testResult);
        
        IEnumerable Results { get; }
    }
}
