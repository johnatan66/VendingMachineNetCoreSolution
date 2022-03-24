using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VendingMachineApplication.Business;
using VendingMachineApplication.Data;
using VendingMachineApplication.Models;

namespace VendingMachineApplication.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IVendingMachineBusiness _vendingMachineBusiness;
        private readonly IVendingMachineHandler _vendingMachineHandler;

        public HomeController(ILogger<HomeController> logger, IVendingMachineBusiness vendingMachineBusiness, IVendingMachineHandler vendingMachineHandler)
        {
            _logger = logger;
            _vendingMachineBusiness = vendingMachineBusiness;
            _vendingMachineHandler = vendingMachineHandler;
        }

        [HttpGet]
        [Route("{id}")]
        public ObjectResult GetVendingMachine(int id)
        {
            var vm = _vendingMachineHandler.Get(id);
            if (vm == null)
                return NotFound("Vending Machine not found");

            return Ok(vm);
        }

        [HttpPost]
        [Route("{id}/add-credit")]
        public ObjectResult AddCredit(int id, [FromBody] JsonElement json)
        {
            JsonElement credit;

            if (!json.TryGetProperty("credit", out credit))
                return BadRequest("Credit is missing");

            _logger.LogInformation($"Received {credit} ");
            var vending = _vendingMachineBusiness.AddCredit(id, credit.GetDouble());

            return Ok(vending);
        }

        [HttpPost]
        [Route("{id}/buy/{productId}")]
        public ObjectResult BuyProduct(int id, int productId)
        {
            var product = _vendingMachineBusiness.BuyProduct(id, productId);

            if(product == null)
                return NotFound("Product not found");

            _logger.LogInformation($"Success: Bought a {product?.Name}");

            return Ok(product);
        }

        [HttpPost]
        [Route("{id}/refill-product/{productId}")]
        public ObjectResult RefillProducts(int id, int productId, [FromBody] JsonElement json)
        {
            JsonElement quantity;

            if (!json.TryGetProperty("quantity", out quantity))
                return BadRequest("quantity is missing");

            _logger.LogInformation($"Received {quantity} ");
            var vending = _vendingMachineBusiness.RefillProducts(id, productId, quantity.GetInt32());
            if(vending == null)
                return NotFound("Not found");

            return Ok(vending);
        }

        [HttpPost]
        [Route("add-vendingMachine")]
        public ObjectResult AddVm([FromBody] VendingMachine vendingMachine)
        {            
            var addVending = _vendingMachineBusiness.AddVm(vendingMachine);

            return Ok(addVending);
        }

    }
}
