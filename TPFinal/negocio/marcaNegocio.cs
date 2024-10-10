using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class marcaNegocio
    {

        public List<marca> listar()
        {
            List<marca> lista = new List<marca>();
            acessoDatos datos = new acessoDatos();
            try
            {
                datos.setarConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    marca aux = new marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
