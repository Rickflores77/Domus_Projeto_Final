using System;
using System.ComponentModel.DataAnnotations;

namespace Domus_Projeto.Models
{
    public class Mensagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Remetente { get; set; } = string.Empty;

        [Required]
        public string Conteudo { get; set; } = string.Empty;

        public DateTime EnviadoEm { get; set; } = DateTime.Now;

        public bool Lida { get; set; } = false;

        public int? MoradorId { get; set; } // opcional para relacionar
    }
}
