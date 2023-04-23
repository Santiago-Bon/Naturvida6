using CE_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Factura
    {
        CD_Conexion conexion = new CD_Conexion();

        SqlDataReader Leer;
        SqlCommand comando = new SqlCommand();
        DataTable Tabla = new DataTable();


        //Consultar


        public string MostrarNFactura()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarNFactura";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            if (Leer.Read() == true)
            {
                string factura = Leer["IdFactu"].ToString();
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


        //public DataTable Mostrardgvfactura() //Se crea el método Mostrar tipo DataTable
        //{
        //    comando.Parameters.Clear(); //Limpiamos los parámetros de la tabla
        //    //DataTable tabla = new DataTable(); //Para limpiar la tabla cada vez, se instancia dentro del método
        //    comando.Connection = conexion.AbrirConexion(); //Con el método abre la conexión
        //    comando.CommandText = "dgvfactura"; //Con el comando tipo texto hace la consulta
        //    comando.CommandType = CommandType.StoredProcedure; //Define el comando tipo texto / Procedimiento
        //    Leer = comando.ExecuteReader(); //Guarda y lee el comando en la variable leer, solo para consultas
        //    Tabla.Clear(); //Limpiamos la tabla
        //    Tabla.Load(Leer); //Carga lo guardado en la variable leer
        //    comando.Parameters.Clear(); //Limpiamos los parámetros de la tabla
        //    conexion.CerrarConexion(); //Cierra la conexión
        //    return Tabla; //Retorna la tabla
        //}


        //Insertar


        public void InsertarFactura(CE_Factura factura)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_AGGFACT";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fech", factura.Fecha_Factura);
            comando.Parameters.AddWithValue("@DoClient", factura.Doc_Cliente);
            comando.Parameters.AddWithValue("@CodVende", factura.Cod_Vendedor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        public void InsertarDetalleFactura(CE_Detalle_Factura factura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_AGGFACTDETA";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IDFac", factura.Id_Factura);
            comando.Parameters.AddWithValue("@CodProd", factura.Cod_Producto);
            comando.Parameters.AddWithValue("@Cant", factura.Cantidad);
            comando.Parameters.AddWithValue("@ValUnidad", factura.Valor_Unidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        //Consultar Vendedores


        public string BuscarCodigoVendedor(string vendedor)
        {
            //SqlCommand comando2 = new SqlCommand();
            //SqlDataReader Leer2;
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "BuscarCodigoVendedor";
            comando.Parameters.AddWithValue("@Usuario", vendedor);
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            if (Leer.Read())
            {
                string factura = Leer["Codigo"].ToString();
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


        //Consultar Productos


        public int TraerCantidad(CE_Detalle_Factura factura)
        {
            //SqlCommand comando2 = new SqlCommand();
            //SqlDataReader Leer2;
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "TraerCantidad";
            comando.Parameters.AddWithValue("@Codprod", factura.Cod_Producto);
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            if (Leer.Read())
            {
                int cantidad = Convert.ToInt32(Leer["Cantidad"]);
                Leer.Close();
                return cantidad;
            }
            else
            {
                Leer.Close();
                return 0;
            }
            conexion.CerrarConexion();
        }


        //Editar Productos


        public void ActualizarCantidad(CE_Detalle_Factura factura)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_DESCONTARCANT";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Codprod", factura.Cod_Producto);
            comando.Parameters.AddWithValue("@Cantidad", factura.Cantidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}

