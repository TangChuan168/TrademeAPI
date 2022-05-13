using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrademeAPI.Contracts;
using TrademeAPI.Model;

namespace TrademeAPI.Services
{
    public class ProcessTask : IProcess
    {
        private readonly IConfiguration _configuration;
        public ProcessTask(
            IConfiguration config
         )
        {
            _configuration = config;
        }
        public void getCategories()
        {
            throw new NotImplementedException();
        }

        public void getProducts(ProcessOption opt)
        {
            Console.WriteLine("Process is running!");
            var text = opt.ToString();
            Process p = new Process();
            p.StartInfo.FileName = _configuration.GetSection("ConsoleInfo:AppName").Value;
            p.StartInfo.Arguments = "text";
            //p.StartInfo.Arguments = opt.Timer.ToString();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
            p.WaitForExit();
        }
    }
}
