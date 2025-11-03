using System;
using System.ComponentModel.DataAnnotations;

namespace Domus_Projeto.Models
{
    public class Financa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(100)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Valor é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        // Se quiser associar a um morador específico
        
        public string Status { get; set; } = "Pendente"; // NOVA PROPRIEDADE
        public int? MoradorId { get; set; }
        // public Morador? Morador { get; set; } // Descomente se houver relação
    }
}
