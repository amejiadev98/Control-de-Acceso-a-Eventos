using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crudderegistrodeevento.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        
        public int? InvitadoId { get; set; }
    }
}
