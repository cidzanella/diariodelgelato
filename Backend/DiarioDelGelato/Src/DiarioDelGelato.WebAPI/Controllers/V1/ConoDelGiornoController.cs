using DiarioDelGelato.Application.DTOs.Features.ConoDelGiornoDTOs;
using DiarioDelGelato.Application.Extensions;
using DiarioDelGelato.Application.Interfaces.Services.Features;
using DiarioDelGelato.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiarioDelGelato.WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConoDelGiornoController : ControllerBase
    {
        private readonly IConoDelGiornoService _conoDelGiornoService;

        public ConoDelGiornoController(IConoDelGiornoService conoDelGiornoService) => _conoDelGiornoService = conoDelGiornoService;

        // POST api/<ConoDelGiornoController>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ConoDelGiornoResponseDto>> PostConoDelGiornoAsync([FromBody] ConoDelGiornoCreateRequestDto conoDelGiornoCreate)
        {
            try
            {
                // check if current time matches the scheduled break interval for the user to have the Cono Del Giorno
                // if (! await _conoDelGiornoService.ValidateConoDelGiornoBreakAsync(conoDelGiornoCreate.TeamMemberId) )
                // note: it should aways register a cone that is being weighed and later on the report on cono del giorno will show those out of the schedule break

                return Ok(await _conoDelGiornoService.RegisterConoDelGiornoAsync(conoDelGiornoCreate));
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred when registering Cono del Giorno: {ex.Message} - {ex.InnerException}");
            }

        }
    }
}
