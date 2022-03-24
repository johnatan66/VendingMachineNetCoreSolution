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
            if(vending == null)
                return null;

            vending.Credits = vending.Credits + credits;

            return _vendingMachineHandler.Update(vending);
        }

        public Product BuyProduct(int id, int productId)
        {
            var vm = _vendingMachineHandler.Get(id);
            if(vm == null)
                return null;

            var product = vm.Products.FirstOrDefault
            (p => p.Id == productId);
            if (product == null)
                return null;

            if(vm.Credits < product.Value)
                return null;

            if(product.Quantity > 0){
                product.Quantity -= 1;
                vm.Credits -= product.Value;
            }

            _vendingMachineHandler.Update(vm);

            return product;
        }

        public Product RefillProducts(int id, int productId, int quantity)
        {
            var vm = _vendingMachineHandler.Get(id);
            if(vm == null)
                return null;

            var product = vm.Products.FirstOrDefault(p => p.Id == productId);
            if(product == null)
                return null;
                
            product.Quantity += quantity;

            _vendingMachineHandler.Update(vm);

            return product;
        }

        public VendingMachine AddVm(VendingMachine vm)
        {
            _vendingMachineHandler.Create(vm);
                
            return vm;
        }
    } 
}
