using System;
using Microsoft.Owin.Hosting;
using Script.TestFramework;

namespace Script.TestHost
{
    /// <summary>
    /// Main application class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main app loop
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            const string baseUrl = "http://localhost:5000/";

            using (WebApp.Start<Startup>(url:baseUrl))
            {
                Console.WriteLine("Listening on {0}", baseUrl);
                Console.ReadLine();
            }
        }
    }
}
