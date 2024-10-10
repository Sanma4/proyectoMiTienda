using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoDatos;

namespace AccesoDatos
{
    public class marcaNegocio
    {

        public List<marca> listar()
        {
            List<marca> lista = new List<marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    marca aux = new marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
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
