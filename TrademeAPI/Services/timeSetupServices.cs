using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrademeAPI.Contracts;
using TrademeAPI.Model;

namespace TrademeAPI.Services
{
    public class timeSetupServices //: IHostedService
    {
        private readonly IProcess _processJob;

        public timeSetupServices(ProcessTask processJob)
        {
            _processJob = processJob;
        }
        public Task StartAsync(ProcessOption opt)
        {

            var Url = opt.nodeUrl;
            var timeProp = opt.Timer;

            TimeSpan interval = TimeSpan.FromDays(24);
            var nextRunTime = DateTime.Today.AddDays(1).AddHours(1);
            var CurTime = DateTime.Now;
            var firstInterval = nextRunTime.Subtract(CurTime);


            Action action = () =>
            {
                var t1 = Task.Delay(firstInterval);
                t1.Wait();
               _processJob.getProducts(opt);
                var _timer = new Timer(
                    workhelper, null,
                    TimeSpan.Zero,
                    interval
                );
            };

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void workhelper(Object state)
        {
            _processJob.getProducts();
        }
    }
}
