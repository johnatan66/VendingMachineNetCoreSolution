using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachineApplication.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VendingMachineApplication.Data
{
    public class ProductHandler : IProductHandler
    {

        private readonly VendingMachineContext _context;

        public ProductHandler(VendingMachineContext context) 
        {
            _context = context;
        }


        public VendingMachine Get(int id) {

            return null;
        }

      
    }
}
