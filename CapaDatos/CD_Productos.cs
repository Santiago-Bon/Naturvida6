using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CE_Entidades;

namespace CapaDatos
{
    public class CD_Productos
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand Comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public DataTable BuscarProducto(CE_Productos productos)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", productos.Codigo);
            Comando.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarProductoEditar(CE_Productos productos)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarProductosEditar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", productos.Codigo);
            Comando.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarnombreProducto()
        {
            DataTable Tabla = new DataTable();
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarnombreProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarTodosProducto(CE_Productos productos)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarTodosProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", productos.Codigo);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable mostrartodatablaproductos()
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "todatablaproductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable mostrartodatablaproductoseditar(CE_Productos productos)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "todatablaproductoseditar";
            Comando.Parameters.AddWithValue("@Cod", productos.Codigo);
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        //Insertar


        public void InsertarProductos(CE_Productos productos)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_INSERTARPRODUCT";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", productos.Codigo);
            Comando.Parameters.AddWithValue("@Descri", productos.Descripcion);
            Comando.Parameters.AddWithValue("@ValUnd", productos.Valor_Unidad);
            Comando.Parameters.AddWithValue("@Cantida", productos.Cantiad);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        //Editar


        public void EditarProductos(CE_Productos productos)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_ACTUALIZARPROD";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Cod", productos.Codigo);
            Comando.Parameters.AddWithValue("@Descri", productos.Descripcion);
            Comando.Parameters.AddWithValue("@ValUnd", productos.Valor_Unidad);
            Comando.Parameters.AddWithValue("@Cant", productos.Cantiad);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        //Eliminar


        public void eliminarproducto(CE_Productos productos)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_ELIMINARPROD";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Cod", productos.Codigo);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
        }


        //Consultar Inventario


        public DataTable MostrarInventarioConsultar(CE_Productos inventario)
        {
            DataTable tabla = new DataTable();
            Comando.Parameters.Clear();
            tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BUSCARINVENTARIO";
            Comando.Parameters.AddWithValue("@Prod", inventario.Codigo);
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            tabla.Load(Leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarInventarioMostrarTodo()
        {
            DataTable tabla = new DataTable();
            Comando.Parameters.Clear();
            tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SP_BUSCARINVENTARIOS";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            tabla.Load(Leer);
            conexion.CerrarConexion();
            return tabla;
        }


        //Consultar Factura


        public string MostrarValorProducto(CE_Productos producto)
        {
            //SqlCommand comando2 = new SqlCommand();
            //SqlDataReader Leer2;
            Comando.Parameters.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "MostrarValorProducto";
            Comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            if (Leer.Read())
            {
                string factura = Leer["Valor_Unidad"].ToString();
                Leer.Close();
                return factura;

            }
            else
            {
                Leer.Close();
                return " ";
            }
            conexion.CerrarConexion();
        }


        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            Comando.Parameters.Clear();
            tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "MostrarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            tabla.Load(Leer);
            conexion.CerrarConexion();
            return tabla;
        }


        //public DataTable MostrarValorProducto(CE_Productos producto)
        //{
        //    DataTable tabla = new DataTable();
        //    comando.Parameters.Clear();
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "MostrarValorProducto";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
        //    Leer = comando.ExecuteReader();
        //    tabla.Load(Leer);
        //    conexion.CerrarConexion();
        //    return tabla;
        //}       
    }
}


