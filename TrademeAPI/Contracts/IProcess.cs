using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrademeAPI.Model;

namespace TrademeAPI.Contracts
{
    interface IProcess
    {
        public void getCategories();
        public void getProducts(ProcessOption opt);

    }
}
