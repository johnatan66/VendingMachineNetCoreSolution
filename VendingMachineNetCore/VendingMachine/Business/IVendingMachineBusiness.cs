using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachineApplication.Models;

namespace VendingMachineApplication.Business
{
    public interface IVendingMachineBusiness
    {
        public VendingMachine AddCredit(int id, double credits);

        Product BuyProduct(int id, int productId);

        Product RefillProducts(int id, int productId, int quantity);

        public VendingMachine AddVm(VendingMachine vm);
    }
}
