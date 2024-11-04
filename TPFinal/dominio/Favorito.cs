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
        public marca Marca { get; set; }
        public articulo Articulo { get; set; }

    }
}
