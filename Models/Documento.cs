using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domus_Projeto.Models
{
    public class Documento
    {
           public int Id { get; set; }   
         public string Titulo { get; set; }
        public string CaminhoArquivo { get; set; }
        public DateTime Data { get; set; }
        public decimal TamanhoMB { get; set; }
    }
}