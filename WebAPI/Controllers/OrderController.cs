using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private Service.IOrdreService orderService;
        public OrderController(Service.IOrdreService ordreService)
        {
            this.orderService = ordreService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, string token, string PayerID)
        {
            try
            {

                var ordre = await orderService.Get(id);
                ordre.Paid = true;
                await orderService.Update(ordre);



            }
            catch (Exception ex)
            {

            }
            return Redirect("http://webshop.nillertron.com/order/succes/");
        }

        // POST: api/Order
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
