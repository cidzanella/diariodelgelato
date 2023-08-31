using DiarioDelGelato.Application.DTOs;
using DiarioDelGelato.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiarioDelGelato.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GelatoController : ControllerBase
    {
        private readonly IGelatoService _gelatoService;

        public GelatoController(IGelatoService gelatoService)
        {
            _gelatoService = gelatoService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GelatoResponse>>> GetGelatosAsync()
        {
            var gelatos = await _gelatoService.ReadGelatosAsync();
            return gelatos == null ? NotFound() : Ok(gelatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GelatoResponse>> GetGelatoAsync(int id)
        {
            var gelato = _gelatoService.ReadGelatoAsync(id);
            return gelato == null ? NotFound() : Ok(gelato);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GelatoResponse>> PostGelatoAsync([FromBody] GelatoCreateRequest gelatoCreate) 
        {
            var response = await _gelatoService.CreateGelatoAsync(gelatoCreate);
            return response == null ? BadRequest() : Ok(response);
        }

        [HttpPut("{id]")]
        [Authorize]
        public async Task<ActionResult<GelatoResponse>> PutGelatoAsync(int id, GelatoUpdateRequest gelatoUpdate)
        {
            if (id != gelatoUpdate.id)
        }

        [HttpDelete("{id]")]
        [Authorize]

    }
}
