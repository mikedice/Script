
using System;

namespace Script.TestFramework.Models.Jasmine
{
    /// <summary>
    /// Represents the result of running a Jasmine test case
    /// </summary>
    public class JasmineTestResult
    {
        /// <summary>
        /// Gets or sets the full name of the test. Comes from the call to Jasmine.describe
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the description of a test case. Comes from teh call to Jasmine.it
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the status of the test case (Pass or Fail).
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }

        public bool Passed
        {
            get { return !string.IsNullOrEmpty(Status) && Status.Equals("passed", StringComparison.OrdinalIgnoreCase); }
        }
    }
}
