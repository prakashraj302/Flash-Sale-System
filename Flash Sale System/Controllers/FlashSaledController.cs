using Flash_Sale_System.Model;
using Flash_Sale_System.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Flash_Sale_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSaledController : ControllerBase
    {
        private readonly Iinventoryservice _inventory;
        public FlashSaledController(Iinventoryservice iinventoryservice) { _inventory = iinventoryservice; }
        [HttpPost("intilize")]
        public async Task<IActionResult> intizle(InventoryReuqest reservationRequest)
        {
            var result = await _inventory.Initialize(reservationRequest.Toalinventory);
            return Ok(new { result = result, Status = 200 });
        }

        [HttpPost("reserve")]
        public IActionResult Reserve(ReservationRequest reservationRequest) {
            var result = _inventory.Reserve(reservationRequest.UserId);
            return Ok(new { result = result, Status= 201 });
        }
        [HttpGet("status")]
        public IActionResult statusCode()
        {
            var result = _inventory.Status();
            return Ok(new
            {
                result = result,
                Status = 200

            });
        }
        [HttpGet("reserve/{reservationid}/confirm")]
        public IActionResult confirm(string reservationid) {
            var (code, body) = _inventory.confirm(reservationid);
            return StatusCode(code, body);
        }
    }
}
