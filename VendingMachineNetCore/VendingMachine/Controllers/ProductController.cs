using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachineApplication.Business;
using VendingMachineApplication.Models;

namespace VendingMachineApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
     
        private readonly ILogger<ProductController> _logger;
        private readonly IVendingMachineBusiness _vendingMachineBusiness;

        public ProductController(ILogger<ProductController> logger, IVendingMachineBusiness vendingMachineBusiness)
        {
            _logger = logger;
            _vendingMachineBusiness = vendingMachineBusiness;
        }

        [HttpPost]
        public ObjectResult AddProduct(Product product)
        {

            // Do Something
            _logger.LogInformation($"Received Product {product?.Name} ");

            return Ok(product);
        }

    }
}
