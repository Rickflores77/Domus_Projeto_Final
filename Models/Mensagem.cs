using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domus_Projeto.Models
{
    public class Mensagem
    {
           public int Id { get; set; }   
         public string Remetente { get; set; } 
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Nova { get; set; }
    }
}