using Crudderegistrodeevento.DTOs;
using Crudderegistrodeevento.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crudderegistrodeevento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _repo;

        public EventoController(IEventoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento([FromBody] EventoDto dto)
        {
            try
            {
                var created = await _repo.CreateEvento(dto);
                return CreatedAtAction(nameof(GetEventos), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEventos()
        {
            var items = await _repo.GetEventos();
            return Ok(items);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(int id, [FromBody] EventoDto dto)
        {
            try
            {
                var updated = await _repo.UpdateEvento(id, dto);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var ok = await _repo.DeleteEvento(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
