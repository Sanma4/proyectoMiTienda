using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
   public class Favorito
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public string UrlImagen { get; set; }
        public marca Marca { get; set; }
    }
}
