using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using static AccesoDatos.AccesoDatos;

namespace AccesoDatos
{
    public class articuloNegocio
    {
        public List<articulo> listar()
        {
            List<articulo> lista = new List<articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as  Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca And C.Id = A.IdCategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca  = new marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"], new CultureInfo("es-AR"));

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
        
        public void agregar(articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS values (@codigo, @titulo, @descripcion, @idMarca, @idCategoria, @urlImagen, @precio)");
                
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@titulo", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@urlImagen", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);

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

        public void Modificar(articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @marca, IdCategoria = @categoria, ImagenUrl = @img, Precio = @precio where Id = @id");
                
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@marca", nuevo.Marca.Id);
                datos.setearParametro("@categoria", nuevo.Categoria.Id);
                datos.setearParametro("@img", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@id", nuevo.Id);
                
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
        

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
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

        public List<articulo> filtrar(string criterio, string parametro, string filtro)
        {
            List<articulo> lista = new List<articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as  Dispositivo, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca And C.Id = A.IdCategoria And ";

                switch (criterio)
                {
                    case "Codigo":
                        switch (parametro)
                        {
                            case "Empieza":
                                consulta += "codigo like '" + filtro + "%'";
                                break;
                            case "Contiene":
                                consulta += "codigo like '%" + filtro + "%'";
                                break;
                            case "Termina":
                                consulta += "codigo like '%" + filtro + "'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (parametro)
                        {
                            case "Empieza":
                                consulta += "nombre like '" + filtro + "%'";
                                break;
                            case "Contiene":
                                consulta += "nombre like '%" + filtro + "%'";
                                break;
                            case "Termina":
                                consulta += "nombre like '%" + filtro + "'";
                                break;
                        }
                        break;

                    case "Marca":
                        switch (parametro)
                        {
                            case "Samsung":
                                consulta += "M.Descripcion like '" + parametro + "'";
                                break;
                            case "Apple":
                                consulta += "M.Descripcion like '" + parametro + "'";
                                break;
                            case "Sony":
                                consulta += "M.Descripcion like '" + parametro + "'";
                                break;
                            case "Huawei":
                                consulta += "M.Descripcion like '" + parametro + "'";
                                break;
                            case "Motorola":
                                consulta += "M.Descripcion like '" + parametro + "'";
                                break;

                        }
                        break;

                    case "Categoria":
                        switch (parametro)
                        {
                            case "Celulares":
                                consulta += "C.Descripcion like '" + parametro + "'";
                                break;
                            case "Televisores":
                                consulta += "C.Descripcion like '" + parametro + "'";
                                break;
                            case "Media":
                                consulta += "C.Descripcion like '" + parametro + "'";
                                break;
                            case "Audio":
                                consulta += "C.Descripcion like '" + parametro + "'";
                                break;
                        }
                        break;

                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["idMarca"];
                    aux.Categoria = new categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Dispositivo"];
                    aux.Categoria.Id = (int)datos.Lector["idCategoria"];
                    aux.ImagenUrl = (string)datos.Lector["imagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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
