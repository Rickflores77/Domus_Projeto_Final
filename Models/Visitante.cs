using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domus_Projeto.Models
{
    public class Visitante
    {
           public int Id { get; set; }   
        public string Nome { get; set; }
        public string RG { get; set; }
        public DateTime DataVisita { get; set; }
        public string Status { get; set; }
    }
}