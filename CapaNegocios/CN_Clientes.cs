using CapaDatos;
using CE_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Clientes
    {
        CD_Clientes oCD_cliente= new CD_Clientes();


        //Consultar


        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = oCD_cliente.MostrarClientes();
            return tabla;
        }


        public bool Buscarclientes(CE_Clientes clientes)
        {
            DataTable encontrado = oCD_cliente.Buscarcliente(clientes);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public bool BuscarclientesEditar(CE_Clientes clientes)
        {
            DataTable encontrado = oCD_cliente.BuscarclienteEditar(clientes);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public DataTable BuscarTodoscliente(CE_Clientes clientes)
        {
            DataTable tabla = oCD_cliente.BuscarTodosclientes(clientes);
            return tabla;
        }


        public DataTable mostrartodatablacliente()
        {
            DataTable tabla2 = oCD_cliente.mostrartodatablaclientes();
            return tabla2;
        }


        public DataTable mostrartodatablaclienteeditar(CE_Clientes clientes)
        {
            DataTable tabla3 = oCD_cliente.mostrartodatablaclienteseditar(clientes);
            return tabla3;
        }


        //Insertar


        public void insertarcliente(CE_Clientes clientes)
        {
            oCD_cliente.Insertarcliente(clientes);
        }


        //Editar


        public void Editarcliente(CE_Clientes clientes)
        {
            oCD_cliente.Editarcliente(clientes);
        }


        //Eliminar


        public void eliminarclientes(CE_Clientes clientes)
        {
            oCD_cliente.eliminarclientes(clientes);
        }
    }
}
