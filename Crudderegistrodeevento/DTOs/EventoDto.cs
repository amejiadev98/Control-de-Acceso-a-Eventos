using System;

namespace Crudderegistrodeevento.DTOs
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
