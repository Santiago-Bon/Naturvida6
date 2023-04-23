using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE_Entidades;

namespace CapaDatos
{
    public class CD_Vendedores
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand Comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public DataTable BuscarDatosVendedores(CE_Vendedores usuario)
        {
            Tabla.Clear();
            Comando.Parameters.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarDatosUsuarios";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Usuario", usuario.Usuario);
            Comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            Leer = Comando.ExecuteReader();
            Tabla.Clear();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable Buscarvendedor(CE_Vendedores vendedores)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarVendedores";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedores.Usuario);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarvendedorEditar(CE_Vendedores vendedores)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarVendedoresEditar";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedores.Usuario);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarnombreVendedor()
        {
            DataTable Tabla = new DataTable();
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarnombreVendedores";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable BuscarTodosVendedor(CE_Vendedores vendedores)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "BuscarTodosVendedores";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable mostrartodatablavendedores()
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "todatablavendedores";
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        public DataTable mostrartodatablavendeditar(CE_Vendedores vendedores)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "todatablavendedoreseditar";
            Comando.Parameters.AddWithValue("@Cod", vendedores.Codigo);
            Comando.CommandType = CommandType.StoredProcedure;
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
            return Tabla;
        }


        //Insertar


        public void InsertarVendedores(CE_Vendedores vendedores)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "InsertarVendedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedores.Usuario);
            Comando.Parameters.AddWithValue("@Contrasena", vendedores.Contraseña);
            Comando.Parameters.AddWithValue("@Nombre", vendedores.Nombre);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        //Editar


        public void EditarVendedor(CE_Vendedores vendedores)
        {
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "ActualizarVendedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Comando.Parameters.AddWithValue("@Usuario", vendedores.Usuario);
            Comando.Parameters.AddWithValue("@Nombre", vendedores.Nombre);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        //Eliminar


        public void eliminarvendedor(CE_Vendedores vendedores)
        {
            Comando.Parameters.Clear();
            Tabla.Clear();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "EliminarVendedor";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Codigo", vendedores.Codigo);
            Leer = Comando.ExecuteReader();
            Comando.Parameters.Clear();
            Tabla.Load(Leer);
            conexion.CerrarConexion();
        }
    }
}

