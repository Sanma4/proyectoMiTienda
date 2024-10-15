using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Seguridad
    {
        public static bool SessionIniciada(object persona)
        {
            Usuario oUsuario = persona != null ? (Usuario)persona : null;
            if(oUsuario != null && oUsuario.Id != 0)
                return true;
            else
                return false;

        }

        public static bool Admin(object User)
        {
            Usuario oUsuario = User != null ? (Usuario)User : null;
            return oUsuario != null ? oUsuario.Admin : false;
        }


    }
}
