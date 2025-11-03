using System;
using System.ComponentModel.DataAnnotations;

namespace Domus_Projeto.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Area { get; set; } = string.Empty;

        [Required]
        public DateTime DataHora { get; set; }

        public string Status { get; set; } = "Pendente"; // Pendente, Confirmada, Cancelada

        public int? MoradorId { get; set; }
    }
}
