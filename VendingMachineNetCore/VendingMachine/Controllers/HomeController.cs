using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VendingMachineApplication.Business;
using VendingMachineApplication.Models;

namespace VendingMachineApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IVendingMachineBusiness _vendingMachineBusiness;

        public HomeController(ILogger<HomeController> logger, IVendingMachineBusiness vendingMachineBusiness)
        {
            _logger = logger;
            _vendingMachineBusiness = vendingMachineBusiness;
        }


        [HttpPost]
        [Route("{id}")]
        public ObjectResult AddCredit(int id, [FromBody] JsonElement json)
        {

            JsonElement credit;

            if (!json.TryGetProperty("credit", out credit))
                return BadRequest("Credit is missing");

            _logger.LogInformation($"Received {credit} ");
            var vending = _vendingMachineBusiness.AddCredit(id, credit.GetDouble());

            return Ok(vending);
        }

        [HttpGet]
        [Route("{id}/products")]
        public ObjectResult GetProducts(int id)
        {
            return Ok(_vendingMachineBusiness.GetProducts(id));
        }


        [HttpPost]
        [Route("{id}/product/{productId}")]
        public ObjectResult BuyProduct(int id, int productId)
        {
            // Do Something
            return null;
        }

    }
}
