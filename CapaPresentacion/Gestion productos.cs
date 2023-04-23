using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CE_Entidades;

namespace CapaPresentacion
{
    public partial class Gestion_productos : Form
    {
        CE_Productos productos = new CE_Productos();
        CN_Productos oCN_Productos = new CN_Productos();
        CN_Validaciones validaciones = new CN_Validaciones();


        public Gestion_productos()
        {
            InitializeComponent();
        }


        private void Gestion_productos_Load(object sender, EventArgs e)
        {
            mostrartodoseditarproductos();
            Limpiar();
            mostrarnombreproducto();
            editarmostrarnombreproducto();
            eliminarmostrarnombreproducto();
        }


        #region Mis métodos


        private void Limpiar() //Limpia las cajas de texto de ingresar producto
        {
            Txtingresar_producto_codigo.Clear();
            Txtingresar_producto_cantidad.Clear();
            Txtingresar_producto_descripcion.Clear();
            Txtingresar_producto_valor.Clear();
        }


        private void LimpiarEditar() //Limpia las cajas de texto de editar producto
        {
            Txtmodificar_producto_codigo.Clear();
            Txtmodificar_producto_cantidad.Clear();
            Txtmodificar_producto_descripcion.Clear();
            Txtmodificar_producto_valor.Clear();
        }


        //Consultar


        private void mostrarnombreproducto() //Muestra la descripción de los productos en el combobox de consultar productos
        {
            Cbxconsultar_producto_producto.DataSource = oCN_Productos.Buscarnombreprod();
            Cbxconsultar_producto_producto.DisplayMember = "Descripción";
            Cbxconsultar_producto_producto.ValueMember = "Codigo";
            Cbxconsultar_producto_producto.SelectedIndex = -1;
        }


        private void mostrartodosproductos() //Muestra los datos del producto seleccionado en el combobox en el datagridview de consultar productos
        {
            productos.Codigo = Convert.ToInt32(Cbxconsultar_producto_producto.SelectedValue);
            Dgwconsultarproducto.DataSource = oCN_Productos.BuscarTodosprod(productos);
        }


        private void mosstrartablatodoproductos() //Muestra todos los datos de los productos en el datagridview de consultar productos
        {
            Dgwconsultarproducto.DataSource = oCN_Productos.mostrartodatablaprod();
            Cbxconsultar_producto_producto.SelectedIndex = -1;
        }


        //Editar


        private void editarmostrarnombreproducto() //Muestra la descripción de los productos en el combobox de editar productos
        {
            Cbomodificar_produntos_producto.DataSource = oCN_Productos.Buscarnombreprod();
            Cbomodificar_produntos_producto.DisplayMember = "Descripción";
            Cbomodificar_produntos_producto.ValueMember = "Codigo";
            Cbomodificar_produntos_producto.SelectedIndex = -1;
        }


        private void mostrartodoseditarproductos() //Muestra todos los datos de los productos en el datagridview oculto de editar productos
        {
            CE_Productos productos = new CE_Productos();
            productos.Codigo = Convert.ToInt32(Cbomodificar_produntos_producto.SelectedValue);
            dataGridView1.DataSource = oCN_Productos.mostrartodatablaproductoeditar(productos);
            dataGridView1.Visible = false;
        }


        //Eliminar


        private void eliminarmostrarnombreproducto() //Muestra la descripción de los productos en el combobox de eliminar productos
        {
            Cboeliminar_produncto_producto.DataSource = oCN_Productos.Buscarnombreprod();
            Cboeliminar_produncto_producto.DisplayMember = "Descripción";
            Cboeliminar_produncto_producto.ValueMember = "Codigo";
            Cboeliminar_produncto_producto.SelectedIndex = -1;
        }


        #endregion


        //Ingresar


        private void Btningresa_producto_guardar_Click(object sender, EventArgs e)
        {
            if (Txtingresar_producto_codigo.Text == string.Empty || //Verifica que ningún campo esté vacio
                Txtingresar_producto_descripcion.Text == string.Empty ||
                Txtingresar_producto_valor.Text == string.Empty ||
                Txtingresar_producto_cantidad.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                if (Convert.ToInt32(Txtingresar_producto_cantidad.Text) >= 1 & Convert.ToInt32(Txtingresar_producto_valor.Text) >= 1) //Verifica que ni el valor ni la cantidad sean de 0
                {
                    productos.Codigo = Convert.ToInt32(Txtingresar_producto_codigo.Text);
                    productos.Descripcion = Txtingresar_producto_descripcion.Text;

                    if (oCN_Productos.BuscarProd(productos) == false) //Envia el código y la descripción y verifica que no exista otro producto con el mismo contenido
                    {
                        productos.Codigo = Convert.ToInt32(Txtingresar_producto_codigo.Text);
                        productos.Descripcion = Txtingresar_producto_descripcion.Text.Trim();
                        productos.Valor_Unidad = Convert.ToInt32(Txtingresar_producto_valor.Text);
                        productos.Cantiad = Convert.ToInt32(Txtingresar_producto_cantidad.Text);
                        oCN_Productos.InsertarProd(productos); //Ingresa el producto
                        MessageBox.Show("Se insertó correctamente el producto");
                        Limpiar(); //Limpia las cajas de texto
                        mostrartodoseditarproductos();
                        mostrarnombreproducto();
                        editarmostrarnombreproducto();
                        eliminarmostrarnombreproducto();
                    }
                    else
                    {
                        MessageBox.Show("El producto ya existe");
                    }
                }
                else
                {
                    MessageBox.Show("No puede haber un un valor o cantidad de 0");
                }
            }
        }


        private void Btningresar_producto_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        //Modificar


        private void Btnmodificar_producto_consultar_Click(object sender, EventArgs e)
        {
            mostrartodoseditarproductos();

            if (Cbomodificar_produntos_producto.SelectedIndex >= 0) //Si lo seleccionado en el combobox es mayor a 0 trae los campos del datagridview a las cajas de texto
            {
                Txtmodificar_producto_codigo.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                Txtmodificar_producto_descripcion.Text = dataGridView1.CurrentRow.Cells["Descripción"].Value.ToString();
                Txtmodificar_producto_valor.Text = dataGridView1.CurrentRow.Cells["Valor_Unidad"].Value.ToString();
                Txtmodificar_producto_cantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
            }
            mostrarnombreproducto();
            editarmostrarnombreproducto();
            eliminarmostrarnombreproducto();
            mostrartodoseditarproductos();
        }


        private void Btnmodificar_producto_guardarcambios_Click(object sender, EventArgs e)
        {
            if (Txtmodificar_producto_codigo.Text == string.Empty || //Verifica que ningún campo esté vacio
                Txtmodificar_producto_descripcion.Text == string.Empty ||
                Txtmodificar_producto_valor.Text == string.Empty ||
                Txtmodificar_producto_cantidad.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                if (Convert.ToInt32(Txtmodificar_producto_cantidad.Text) >= 1 & Convert.ToInt32(Txtmodificar_producto_valor.Text) >= 1) //Verifica que ni el valor ni la cantidad sean de 0
                {
                    productos.Codigo = Convert.ToInt32(Txtmodificar_producto_codigo.Text);
                    productos.Descripcion = Txtmodificar_producto_descripcion.Text;

                    if (oCN_Productos.BuscarProdEditar(productos) == false) //Envia el código y la descripción y verifica que no exista otro producto con el mismo contenido
                    {
                        productos.Codigo = Convert.ToInt32(Txtmodificar_producto_codigo.Text);
                        productos.Descripcion = Txtmodificar_producto_descripcion.Text.Trim();
                        productos.Valor_Unidad = Convert.ToInt32(Txtmodificar_producto_valor.Text); ;
                        productos.Cantiad = Convert.ToInt32(Txtmodificar_producto_cantidad.Text);
                        oCN_Productos.EditarProd(productos); //Edita el producto
                        MessageBox.Show("Se editó correctamente");
                        mostrartodoseditarproductos();
                        mostrarnombreproducto();
                        editarmostrarnombreproducto();
                        eliminarmostrarnombreproducto();
                        LimpiarEditar(); //Limpia las cajas de texto
                    }
                    else
                    {
                        MessageBox.Show("El producto ya existe");
                    }
                }
                else
                {
                    MessageBox.Show("No puede haber un un valor o cantidad de 0");
                }
            }
        }


        //Consultar


        private void Btn_consultar_producto_consultar_Click(object sender, EventArgs e)
        {
            mostrartodosproductos();
            //mostrarnombreproducto();
        }


        private void Btnconsultar_producto_mostrarproducto_Click(object sender, EventArgs e)
        {
            mosstrartablatodoproductos();
            //mostrartodoseditarproductos();
            //mostrarnombreproducto();
            //editarmostrarnombreproducto();
            //eliminarmostrarnombreproducto();
        }
      

        //Eliminar


        private void Btneliminar_productos_productos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres eliminar", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes) //Mensaje de verificación al usuario para proceder a eliminar
            {
                productos.Codigo = Convert.ToInt32(Cboeliminar_produncto_producto.SelectedValue);
                oCN_Productos.eliminarprod(productos); //Elimina el producto
                Cboeliminar_produncto_producto.SelectedIndex = -1;
                MessageBox.Show("Se eliminó correctamente");
                mostrartodoseditarproductos();
                mostrarnombreproducto();
                editarmostrarnombreproducto();
                eliminarmostrarnombreproducto();
            }
            else
            {
                MessageBox.Show("Se canceló la eliminación");
            }
        }


        //Validaciones


        private void Txtingresar_producto_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }


        private void Txtingresar_producto_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }


        private void Txtingresar_producto_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }


        private void Txtmodificar_producto_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }


        private void Txtmodificar_producto_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }
    }
}

