using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachineApplication.Models;

namespace VendingMachineApplication.Data
{
    public interface IProductHandler
    {
        VendingMachine Get(int id);

    }
}
