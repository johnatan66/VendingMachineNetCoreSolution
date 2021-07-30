using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachineApplication.Data;
using VendingMachineApplication.Models;

namespace VendingMachineApplication.Business
{
    public class VendingMachineBusiness : IVendingMachineBusiness
    {
        private readonly IVendingMachineHandler _vendingMachineHandler;

        public VendingMachineBusiness(IVendingMachineHandler vendingMachineHandler)
        {
            _vendingMachineHandler = vendingMachineHandler;
        }

        public VendingMachine AddCredit(int id, double credits)
        {
            var vending = _vendingMachineHandler.Get(id);

            vending.Credits = vending.Credits + credits;

            return _vendingMachineHandler.Update(vending);
        }

        public Product BuyProduct(int id, int productId)
        {
            var vm = _vendingMachineHandler.Get(id);

            _vendingMachineHandler.Update(vm);

            return vm.Products.First(p => p.Id == productId);
        }
    }
}
