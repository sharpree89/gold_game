using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System;


namespace Gold
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
                
        }
    }
}
