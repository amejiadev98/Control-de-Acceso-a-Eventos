using Crudderegistrodeevento.Data;
using Crudderegistrodeevento.DTOs;
using Crudderegistrodeevento.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudderegistrodeevento.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext _db;

        public EventoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<EventoDto> CreateEvento(EventoDto dto)
        {
            ValidateDto(dto);

            var entity = new Evento
            {
                Nombre = dto.Nombre,
                Fecha = dto.Fecha
            };

            _db.Eventos.Add(entity);
            await _db.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<IEnumerable<EventoDto>> GetEventos()
        {
            return await _db.Eventos
                .AsNoTracking()
                .OrderBy(e => e.Fecha)
                .Select(e => new EventoDto { Id = e.Id, Nombre = e.Nombre, Fecha = e.Fecha })
                .ToListAsync();
        }

        public async Task<EventoDto?> UpdateEvento(int id, EventoDto dto)
        {
            ValidateDto(dto);

            var entity = await _db.Eventos.FindAsync(id);
            if (entity == null) return null;

            entity.Nombre = dto.Nombre;
            entity.Fecha = dto.Fecha;

            await _db.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> DeleteEvento(int id)
        {
            var entity = await _db.Eventos.FindAsync(id);
            if (entity == null) return false;

            _db.Eventos.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        private void ValidateDto(EventoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new ArgumentException("Nombre es obligatorio");

            var today = DateTime.Today;
            if (dto.Fecha.Date < today)
                throw new ArgumentException("Fecha no puede ser pasada");
        }
    }
}
