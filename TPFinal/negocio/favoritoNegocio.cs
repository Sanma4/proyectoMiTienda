using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class favoritoNegocio
    {
        public List<Favorito> ListarFavoritos(int id)
        {
            List<Favorito> lista = new List<Favorito>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select U.Id, F.Id, IdArticulo, IdUser, A.Id, A.Nombre, A.IdMarca, A.ImagenUrl from FAVORITOS F, ARTICULOS A, USERS U where F.IdArticulo = A.Id and U.Id = " + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Favorito aux = new Favorito();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.IdUsuario = (int)datos.Lector["IdUser"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void AgregarFavorito(articulo Producto, Usuario User)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Favoritos values (@IdUsuario, @IdArticulo)");
                datos.setearParametro("@IdUsuario", User.Id);
                datos.setearParametro("@IdArticulo", Producto.Id);
                datos.ejecutarAccion();
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

        public void EliminarFavorito(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete top(1) from Favoritos where IdArticulo = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
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
