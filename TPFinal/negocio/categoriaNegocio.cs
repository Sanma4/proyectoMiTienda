using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoDatos;



namespace AccesoDatos
{
    public class categoriaNegocio
    {

        public List<categoria> listar()
        {
            List<categoria> lista = new List<categoria>(); 
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Descripcion from categorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    categoria aux = new categoria();
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
