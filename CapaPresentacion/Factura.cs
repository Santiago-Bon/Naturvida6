using CapaNegocios;
using CE_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Factura : Form
    {
        CN_Factura oCN_Factura = new CN_Factura();
        CN_Clientes oCN_Clientes = new CN_Clientes();
        CN_Productos oCN_Productos = new CN_Productos();
        CN_Validaciones validaciones = new CN_Validaciones();


        DataTable tabla = new DataTable();
        int factura = 0;


        public Factura()
        {
            InitializeComponent();
        }


        private void Factura_Load(object sender, EventArgs e)
        {
            MostrarNFactura();
            MostrarDataGridView();
            MostrarClientes();
            MostrarProductos();
            BtnTerminarFactura.Enabled = false;
        }


        #region Mis métodos


        private void MostrarNFactura() //Muestra el número de la última factura en la base de datos y le suma 1 
        {
            if (oCN_Factura.MostrarNFactura() != " ")
            {
                factura = Convert.ToInt32(oCN_Factura.MostrarNFactura()) + 1;
                TxtNFactura.Text = factura.ToString();
            }
            else
                TxtNFactura.Text = 1.ToString();
        }


        private void MostrarClientes() //Muestra el nombre de los clientes en el combobox de factura
        {
            CboCliente.DataSource = oCN_Clientes.MostrarClientes();
            CboCliente.DisplayMember = "Nombre";
            CboCliente.ValueMember = "Documento";
            CboCliente.SelectedIndex = -1;
        }


        private void MostrarProductos() //Muestra la descripción de los productos en el combobox de factura
        {
            CboProducto.DataSource = oCN_Productos.MostrarProductos();
            CboProducto.DisplayMember = "Descripción";
            CboProducto.ValueMember = "Codigo";
            CboProducto.SelectedIndex = -1;
        }


        //private void MostrardgvFactura()
        //{
        //    DgvFactura.DataSource = oCN_Factura.Mostrardgvfactura();
        //    TxtNFactura.Text = DgvFactura.CurrentRow.Cells["IdFactu"].Value.ToString();
        //}


        private void MostrarDataGridView() //Agrega columnas al datadridview 
        {
            //tabla.Columns.Add("Factura");
            /*tabla.Columns.Add("Fecha")*/;
            //tabla.Columns.Add("Cliente");
            tabla.Columns.Add("Codigo producto");
            tabla.Columns.Add("Producto");
            tabla.Columns.Add("Valor Unitario");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Subtotal");

            DgvProductosFactura.DataSource = tabla;
            DgvProductosFactura.Columns["Codigo producto"].Visible = false;
        }


        private void EliminarDataGridView() //Limpia el contenido de las columnas en el datagridview
        {
            //tabla.Columns.Remove("Factura");
            //tabla.Columns.Remove("Fecha");
            //tabla.Columns.Remove("Cliente");
            //tabla.Columns.Remove("Codigo producto");
            //tabla.Columns.Remove("Producto");
            //tabla.Columns.Remove("Valor Unitario");
            //tabla.Columns.Remove("Cantidad");
            //tabla.Columns.Remove("Subtotal");
            //DgvProductosFactura.DataSource = tabla;
            DataTable dt = (DataTable)DgvProductosFactura.DataSource;
            dt.Clear();
        }


        private int TotalFactura() //Muestra la suma de todos los subtotales del datagridview dando el total de la factura
        {
            int Valor_total = 0;
            foreach (DataRow filas in tabla.Rows)
            {
                Valor_total += Convert.ToInt32(filas["Subtotal"]);
            }
            int valor = Valor_total;
            return valor;
        }


        private void LimpiarAgregar() //Limpia el combobox de los productos y la caja de texto de la cantidad
        {
            CboProducto.SelectedIndex = -1;
            TxtCantidad.Clear();
        }


        private void LimpiarTodoFactura() //Limpia todos los campos de la factura
        {
            CboCliente.SelectedIndex = -1;
            CboProducto.SelectedIndex = -1;
            TxtCantidad.Clear();
            TxtTotal_Factura.Clear();
        }


        #endregion


        //Agregar producto


        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (TxtCantidad.Text != string.Empty & //Verifica que ningún campo esté vacio 
                CboCliente.SelectedIndex != -1 &
                CboProducto.SelectedIndex != -1)
            {
                if (Convert.ToInt32(TxtCantidad.Text) >=1) //Verifica que la canntidad sea mayor o igual a 1
                {
                    CE_Detalle_Factura cantidad = new CE_Detalle_Factura();
                    CE_Productos productos = new CE_Productos();
                    DataRow filas = tabla.NewRow();

                    CboCliente.Enabled = false;
                    int valor_unitario = 0;
                    bool respuesta = true;
                    int cant = 0;

                    /*filas["Factura"] = TxtNFactura.Text;*/
                    //filas["Fecha"] = DtpFecha_Factura.Text;
                    //filas["Cliente"] = CboCliente.Text;

                    cantidad.Cod_Producto = Convert.ToInt32(CboProducto.SelectedValue);
                    cant = Convert.ToInt32(oCN_Factura.TraerCantidad(cantidad)); //Consultamos la cantidad del producto seleccionado en el combobox de los productos 

                    if (cant-Convert.ToInt32(TxtCantidad.Text) >= 0) //Si la cantidad del producto traida menos la cantidad que vayamos a ingresar es mayor o igual a 0
                    {
                        filas["Producto"] = CboProducto.Text; //Enviamos los datos a las columnas del datagridview
                        filas["Codigo producto"] = CboProducto.SelectedValue;
                        filas["Cantidad"] = TxtCantidad.Text;

                        productos.Descripcion = CboProducto.Text;
                        valor_unitario = Convert.ToInt32(oCN_Productos.MostrarValorProducto(productos)); //Consultamos el valor unitario del producto seleccionado en el combobox de los productos 
                        
                        filas["Valor Unitario"] = valor_unitario;
                        filas["Subtotal"] = Convert.ToInt32(TxtCantidad.Text) * Convert.ToInt32(oCN_Productos.MostrarValorProducto(productos).ToString()); //Calculamos el subtotal multiplicando la cantidad ingresada por el valor unitario del producto seleccionado 

                        foreach (DataRow fila in tabla.Rows) //Recorremos el datagridview
                        {
                            while (Convert.ToInt32(fila["Codigo producto"]) == Convert.ToInt32(CboProducto.SelectedValue)) //Mientras el código del producto de la columna del datagridview sea igual a el código del producto seleccionado en el combobox de los productos
                            {
                                respuesta = false;
                                break; //Rompa el ciclo
                            }
                        }                      
                        if (respuesta == true) //Si respuesta es igual a verdadera
                        {
                            tabla.Rows.Add(filas); //Añada los datos a las columnas del datagridview
                            TxtTotal_Factura.Text = TotalFactura().ToString(); //Muestra el total de la factura
                            LimpiarAgregar(); //Limpia las cajas de texto y los combobox
                            BtnTerminarFactura.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ya agregó este producto");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente de este producto");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede agregar un producto sin cantidad");
                }
            }
            else
            {
                MessageBox.Show("No se puede agregar el producto");
            }
        }


        //Terminar factura


        private void BtnTerminarFactura_Click(object sender, EventArgs e)
        {
            CE_Factura factura = new CE_Factura();
            CE_Detalle_Factura Detalle_factura = new CE_Detalle_Factura();

            factura.Fecha_Factura = DtpFecha_Factura.Value;
            factura.Doc_Cliente = Convert.ToInt32(CboCliente.SelectedValue);
            factura.Cod_Vendedor = Convert.ToInt32(oCN_Factura.BuscarCodigoVendedor(Form1.VendedorGlobal.vendedor1)); //Traemos el usuario del vendedor de la variable global y consultamos para traer su código
            oCN_Factura.InsertarFactura(factura);//Ingresa la factura

            foreach (DataRow filas in tabla.Rows) //Recorremos el datagridview
            {
                Detalle_factura.Cod_Producto = Convert.ToInt32(filas["Codigo producto"]);
                Detalle_factura.Cantidad = Convert.ToInt32(filas["Cantidad"]);
                oCN_Factura.ActualizarCantidad(Detalle_factura); //Actualizamos la cantidad del producto

                Detalle_factura.Cod_Producto = Convert.ToInt32(filas["Codigo producto"]);
                Detalle_factura.Id_Factura = Convert.ToInt32(TxtNFactura.Text);
                Detalle_factura.Cantidad = Convert.ToInt32(filas["Cantidad"]);
                Detalle_factura.Valor_Unidad = Convert.ToInt32(filas["Valor Unitario"]);
                oCN_Factura.InsertarDetalleFactura(Detalle_factura); //Ingresa el detalle de la factura
            }
            CboCliente.Enabled = true;
            BtnTerminarFactura.Enabled = false;
            MostrarNFactura();
            EliminarDataGridView(); //Limpia el contenido de las columnas del datagridview
            LimpiarTodoFactura(); //Limpia las cajas de texto y los combobox
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            EliminarDataGridView(); //Limpia el contenido de las columnas del datagridview
            LimpiarTodoFactura(); //Limpia las cajas de texto y los combobox
            BtnTerminarFactura.Enabled = false;
            CboCliente.Enabled = true;
        }


        //Validaciones


        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);          
        }
    }
}
