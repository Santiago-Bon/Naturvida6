using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CE_Entidades;

namespace CapaNegocios
{
    public class CN_Vendedores
    {
        CD_Vendedores oCD_Vendedores = new CD_Vendedores();


        //Consultar


        public bool buscardatovende(CE_Vendedores usuario)
        {
            DataTable tabla = new DataTable();
            tabla = oCD_Vendedores.BuscarDatosVendedores(usuario);
            if (tabla.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public bool BuscarVend(CE_Vendedores vendedores)
        {
            DataTable encontrado = oCD_Vendedores.Buscarvendedor(vendedores);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public bool BuscarVendEditar(CE_Vendedores vendedores)
        {
            DataTable encontrado = oCD_Vendedores.BuscarvendedorEditar(vendedores);
            if (encontrado.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }


        public DataTable Buscarnombrevend()
        {
            DataTable tabla = new DataTable();
            tabla = oCD_Vendedores.BuscarnombreVendedor();
            return tabla;
        }


        public DataTable mostrartodatablavend()
        {
            DataTable tabla = oCD_Vendedores.mostrartodatablavendedores();
            return tabla;
        }


        public DataTable mostrartodatablavendeditar(CE_Vendedores vendedores)
        {
            DataTable tabla3 = oCD_Vendedores.mostrartodatablavendeditar(vendedores);
            return tabla3;
        }


        public DataTable BuscarTodosvend(CE_Vendedores vendedores)
        {
            DataTable tabla = oCD_Vendedores.BuscarTodosVendedor(vendedores);
            return tabla;
        }


        //Insertar


        public void InsertarVend(CE_Vendedores vendedores)
        {
            oCD_Vendedores.InsertarVendedores(vendedores);
        }


        //Editar


        public void EditarVend(CE_Vendedores vendedores)
        {
            oCD_Vendedores.EditarVendedor(vendedores);
        }


        //Eliminar


        public void eliminarvend(CE_Vendedores vendedores)
        {
            oCD_Vendedores.eliminarvendedor(vendedores);
        }
    }
}
