using Microsoft.Extensions.Configuration;
using Paylocity.Common;
using System;
using System.IO;

namespace Paylocity.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Config.Configuration = builder.Build();

            //To be scheduled every other Fridays
            new AppProcess().Process();
        }
    }
}
