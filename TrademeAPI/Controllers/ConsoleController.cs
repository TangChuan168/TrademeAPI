using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrademeAPI.Model;
using TrademeAPI.Services;

namespace TrademeAPI.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly timeSetupServices _timerServices;
        
        public ConsoleController(
         timeSetupServices timerServices
        )
        {
          _timerServices = timerServices;
        }
     
        [HttpPost("consoleRun")]
        public async void consoleRun(ProcessOption opt)
        {

            await _timerServices.StartAsync(opt);
            
        }
    }
}
