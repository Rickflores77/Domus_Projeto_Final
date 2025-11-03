using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domus_Projeto.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Água, Luz, Gás, Condomínio
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public bool Paga { get; set; }

        public int MoradorId { get; set; }
        public Morador Morador { get; set; }
    }
}