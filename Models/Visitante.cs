using System;
using System.ComponentModel.DataAnnotations;

namespace Domus_Projeto.Models
{
    public class Visitante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string RG { get; set; } = string.Empty;

        public DateTime DataHora { get; set; }

        public string Status { get; set; } = "Agendado"; // Agendado, Ativo, Concluído

        public int? MoradorId { get; set; }
    }
}
