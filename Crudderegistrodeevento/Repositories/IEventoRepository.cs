using Crudderegistrodeevento.DTOs;

namespace Crudderegistrodeevento.Repositories
{
    public interface IEventoRepository
    {
        Task<EventoDto> CreateEvento(EventoDto dto);
        Task<IEnumerable<EventoDto>> GetEventos();
        Task<EventoDto?> UpdateEvento(int id, EventoDto dto);
        Task<bool> DeleteEvento(int id);
    }
}
