using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Biblioteca
    {

        public int IdLibro{ get; set; }
        public int ValorCodigo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Cantidad { get; set; }
        public DateTime FechaEmicion { get; set; }
        public string Editorial{ get; set; }
    }
}
