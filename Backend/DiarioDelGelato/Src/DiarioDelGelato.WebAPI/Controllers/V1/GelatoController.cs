using Asp.Versioning;
using DiarioDelGelato.Application.DTOs.Features.GelatoDTOs;
using DiarioDelGelato.Application.Exceptions;
using DiarioDelGelato.Application.Interfaces.Services.Features;
using DiarioDelGelato.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiarioDelGelato.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GelatoController : ControllerBase
    {
        private readonly IGelatoService _gelatoService;

        public GelatoController(IGelatoService gelatoService) => 
            _gelatoService = gelatoService;

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GelatoResponseDto>>> GetGelatosAsync() => 
            Ok(await _gelatoService.ReadGelatosAsync());

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<GelatoResponseDto>> GetGelatoAsync(int id)
        {
            try
            {
                var gelato = await _gelatoService.ReadGelatoAsync(id);
                return Ok(gelato);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<ActionResult<GelatoResponseDto>> PostGelatoAsync([FromBody] GelatoCreateRequestDto gelatoCreate)
        {
            try
            {
                var response = await _gelatoService.CreateGelatoAsync(gelatoCreate);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred when creating gelato {gelatoCreate.Name} on database: {ex.Message} - {ex.InnerException}");
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<ActionResult<GelatoResponseDto>> PutGelatoAsync(int id, [FromBody] GelatoUpdateRequestDto gelatoUpdate)
        {
            if (id != gelatoUpdate.Id)
                return BadRequest();

            try
            {
                await _gelatoService.UpdateGelatoAsync(gelatoUpdate);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred when updating gelato {gelatoUpdate.Name} on database: {ex.Message} - {ex.InnerException}");
            }

        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGelatoAsync(int id)
        {
            try
            {
                await _gelatoService.DeleteGelatoAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred when removing gelato {id} from database: {ex.Message} - {ex.InnerException}");
            }
        }
    }
}
