using System;
using Microsoft.Owin.Hosting;
using Jinhe;

namespace WebSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = $"http://localhost:{Config.GetAppSettings("Port")}/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"WebApiHost started on {baseAddress}");
                Console.WriteLine($"Press Ctrl + C to Exit");

                //调用系统默认的浏览器   
                System.Diagnostics.Process.Start($"{baseAddress}{Config.GetAppSettings("StartPage")}");

                Console.ReadLine();
            }
        }
    }
}
