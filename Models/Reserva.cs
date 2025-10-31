using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domus_Projeto.Models
{
    public class Reserva
    {
           public int Id { get; set; }   
         public string Area { get; set; } // Churrasqueira, Salão de Festas...
        public DateTime Data { get; set; }
        public string Status { get; set; } // "Confirmada", "Pendente"
        public int Capacidade { get; set; }
    }
}