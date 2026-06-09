using APBD_TEST2.DTOs;
using APBD_TEST2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TEST2.Controllers
{
    [ApiController]
    [Route("api/screenings")]
    public class ScreeningsController : ControllerBase
    {
        private readonly IScreeningService _screeningService;

        public ScreeningsController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        [HttpGet]
        public async Task<IActionResult> GetScreenings([FromQuery] DateOnly? date)
        {
            var result = await _screeningService.GetScreeningsAsync(date);
            return Ok(result);
        }
        [HttpPost("{id}/tickets")]
        public async Task<IActionResult> PurchaseTicket(int id, [FromBody] PurchaseTicketRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _screeningService.PurchaseTicketAsync(id, dto);
                return Created("", null);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
