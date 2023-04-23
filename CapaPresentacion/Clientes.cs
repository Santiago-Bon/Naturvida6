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
using CapaNegocios;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class Clientes : Form
    {
        CE_Clientes clientes = new CE_Clientes();
        CN_Clientes oCN_Clientes =new CN_Clientes();
        CN_Validaciones validaciones = new CN_Validaciones();


        public Clientes()
        {
            InitializeComponent();
        }


        private void Clientes_Load(object sender, EventArgs e)
        {
            mostrartodoseditarclientes();
            Limpiar();
            mostrarnombrecliente();
            editarmostrarnombrecliente();
            eliminarmostrarnombrecliente();
        }


        #region Mis métodos


        private void Limpiar() //Limpia las cajas de texto de ingresar cliente
        {
            Txtingresar_Cliente_documento.Clear();
            Txtingresar_cliente_nombre.Clear();
            Txtingresar_Cliente_direccion.Clear();
            Txtingresar_Cliente_telefono.Clear();
            Txtingresar_Cliente_correo.Clear();
        }


        private void LimpiarEditar() //Limpia las cajas de texto de editar cliente
        {
            Txtmodificar_Cliente_nombre.Clear();
            Txtmodificar_Cliente_Documento.Clear();
            Txtmodificar_Cliente_Direccion.Clear();
            Txtmodificar_Cliente_telefono.Clear();
            Txtmodificar_Cliente_correo.Clear();
        }


        //Consultar


        private void mostrarnombrecliente() //Muestra el nombre de los clientes en el combobox de consultar clientes
        {
            Cbxconsultar_Cliente_cliente.DataSource = oCN_Clientes.MostrarClientes();
            Cbxconsultar_Cliente_cliente.DisplayMember = "Nombre";
            Cbxconsultar_Cliente_cliente.ValueMember = "Documento";
            Cbxconsultar_Cliente_cliente.SelectedIndex = -1;
        }


        private void mostrartodoscliente() //Muestra los datos del cliente seleccionado en el combobox en el datagridview de consultar clientes
        {
            clientes.Documento = Convert.ToInt32(Cbxconsultar_Cliente_cliente.SelectedValue);
            Dgwconsultarclientes.DataSource = oCN_Clientes.BuscarTodoscliente(clientes);
        }


        private void mosstrartablatodoclientes() //Muestra todos los datos de los clientes en el datagridview de consultar clientes
        {
            Dgwconsultarclientes.DataSource = oCN_Clientes.mostrartodatablacliente();
            Cbxconsultar_Cliente_cliente.SelectedIndex = -1;
        }


        //Editar


        private void editarmostrarnombrecliente() //Muestra el nombre de los clientes en el combobox de editar clientes
        {
            Cbomodificar_clientes_nombre.DataSource = oCN_Clientes.MostrarClientes();
            Cbomodificar_clientes_nombre.DisplayMember = "Nombre";
            Cbomodificar_clientes_nombre.ValueMember = "Documento";
            Cbomodificar_clientes_nombre.SelectedIndex = -1;
        }


        private void mostrartodoseditarclientes() //Muestra todos los datos de los clientes en el datagridview oculto de editar clientes
        {
            CE_Clientes clientes = new CE_Clientes();
            clientes.Documento = Convert.ToInt32(Cbomodificar_clientes_nombre.SelectedValue);
            dataGridView11.DataSource = oCN_Clientes.mostrartodatablaclienteeditar(clientes);
            dataGridView11.Visible = false;
        }


        //Eliminar


        private void eliminarmostrarnombrecliente() //Muestra el nombre de los clientes en el combobox de eliminar clientes
        {
            Cboeliminar_Cliente.DataSource = oCN_Clientes.MostrarClientes();
            Cboeliminar_Cliente.DisplayMember = "Nombre";
            Cboeliminar_Cliente.ValueMember = "Documento";
            Cboeliminar_Cliente.SelectedIndex = -1;
        }


        #endregion


        //Ingresar


        private void Btningresa_Cliente_guardar_Click(object sender, EventArgs e)
        {
            if (Txtingresar_Cliente_correo.Text == string.Empty || //Verifica que ningún campo esté vacio
                Txtingresar_Cliente_direccion.Text == string.Empty ||
                Txtingresar_Cliente_telefono.Text == string.Empty ||
                Txtingresar_cliente_nombre.Text == string.Empty ||
                Txtingresar_Cliente_documento.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                clientes.Documento = Convert.ToInt32(Txtingresar_Cliente_documento.Text);
                clientes.Correo = Txtingresar_Cliente_correo.Text.Trim();

                if (oCN_Clientes.Buscarclientes(clientes) == false) //Envia el documento y el correo y verifica que no exista otro cliente con el mismo contenido
                {
                    clientes.Documento = Convert.ToInt32(Txtingresar_Cliente_documento.Text);
                    clientes.Nombre = Txtingresar_cliente_nombre.Text.Trim();
                    clientes.Direccion = Txtingresar_Cliente_direccion.Text.Trim();
                    clientes.Telefono = Txtingresar_Cliente_telefono.Text.Trim();
                    clientes.Correo = Txtingresar_Cliente_correo.Text.Trim();

                    if (validaciones.correo(Txtingresar_Cliente_correo.Text.Trim()) == false) //Verifica que el correo sea válido
                    {
                        MessageBox.Show("No es valido el correo");
                    }
                    else
                    {
                        oCN_Clientes.insertarcliente(clientes); //Ingresa el cliente
                        MessageBox.Show("Se ingresó correctamente el cliente");
                        Limpiar(); //Limpia las cajas de texto
                        mostrartodoseditarclientes();
                        mostrarnombrecliente();
                        editarmostrarnombrecliente();
                        eliminarmostrarnombrecliente();
                    }
                    //if (validaciones.email(Txtingresar_Cliente_correo.Text) == false)
                    //{
                    //    MessageBox.Show("Dirección de correo inválida");
                    //}
                }
                else
                {
                    MessageBox.Show("El cliente ya existe");
                }
            }
        }


        private void Btningresar_Cliente_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        //Modificar


        private void Btnmodificar_Cliente_consultar_Click(object sender, EventArgs e)
        {
            mostrartodoseditarclientes();
            if (Cbomodificar_clientes_nombre.SelectedIndex >= 0) //Si lo seleccionado en el combobox es mayor a 0 trae los campos del datagridview a las cajas de texto
            {
                Txtmodificar_Cliente_Documento.Text = dataGridView11.CurrentRow.Cells["Documento"].Value.ToString();
                Txtmodificar_Cliente_nombre.Text = dataGridView11.CurrentRow.Cells["Nombre"].Value.ToString();
                Txtmodificar_Cliente_Direccion.Text = dataGridView11.CurrentRow.Cells["Direccion"].Value.ToString();
                Txtmodificar_Cliente_telefono.Text = dataGridView11.CurrentRow.Cells["Telefono"].Value.ToString();
                Txtmodificar_Cliente_correo.Text = dataGridView11.CurrentRow.Cells["Correo"].Value.ToString();
            }
            mostrarnombrecliente();
            editarmostrarnombrecliente();
            eliminarmostrarnombrecliente();
            mostrartodoseditarclientes();
        }


        private void Btnmodificar_Cliente_guardar_Click(object sender, EventArgs e)
        {
            if (Txtmodificar_Cliente_Documento.Text == string.Empty || //Verifica que ningún campo esté vacio
                Txtmodificar_Cliente_nombre.Text == string.Empty ||
                Txtmodificar_Cliente_Direccion.Text == string.Empty ||
                Txtmodificar_Cliente_telefono.Text == string.Empty ||
                Txtmodificar_Cliente_correo.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                if (validaciones.correo(Txtmodificar_Cliente_correo.Text.Trim()) == false) //Verifica que el correo sea válido
                {
                    MessageBox.Show("No es valido el correo");
                }
                else
                {
                    clientes.Documento = Convert.ToInt32(Txtmodificar_Cliente_Documento.Text);
                    clientes.Correo = Txtmodificar_Cliente_correo.Text.Trim();

                    if (oCN_Clientes.BuscarclientesEditar(clientes) == false) //Envia el documento y el correo y verifica que no exista otro cliente con el mismo contenido
                    {
                        clientes.Documento = Convert.ToInt32(Txtmodificar_Cliente_Documento.Text);
                        clientes.Nombre = Txtmodificar_Cliente_nombre.Text.Trim();
                        clientes.Direccion = Txtmodificar_Cliente_Direccion.Text.Trim();
                        clientes.Telefono = Txtmodificar_Cliente_telefono.Text.Trim();
                        clientes.Correo = Txtmodificar_Cliente_correo.Text.Trim();
                        oCN_Clientes.Editarcliente(clientes); //Edita el cliente
                        MessageBox.Show("Se editó correctamente");
                        mostrartodoseditarclientes();
                        mostrarnombrecliente();
                        editarmostrarnombrecliente();
                        eliminarmostrarnombrecliente();
                        LimpiarEditar(); //Limpia las cajas de texto
                    }
                    else
                    {
                        MessageBox.Show("El cliente ya existe");
                    }
                }
            }
        }


        //Consultar


        private void Btn_consultar_Cliente_consultar_Click(object sender, EventArgs e)
        {
            mostrartodoscliente();
            //mostrarnombrecliente();
        }


        private void Btnconsultar_Cliente_mostrarvendedor_Click(object sender, EventArgs e)
        {
            mosstrartablatodoclientes();
            //mostrartodoseditarclientes();
            //editarmostrarnombrecliente();
            //mostrarnombrecliente();
            //eliminarmostrarnombrecliente();
        }


        //Eliminar
        

        private void Btneliminar_Cliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres eliminar", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes) //Mensaje de verificación al usuario para proceder a eliminar
            {
                clientes.Documento = Convert.ToInt32(Cboeliminar_Cliente.SelectedValue);
                oCN_Clientes.eliminarclientes(clientes); //Elimina el cliente
                Cboeliminar_Cliente.SelectedIndex = -1;
                MessageBox.Show("Se eliminó correctamente");
                mostrartodoseditarclientes();
                mostrarnombrecliente();
                editarmostrarnombrecliente();
                eliminarmostrarnombrecliente();
            }
            else
            {
                MessageBox.Show("Se canceló la eliminación");
            }
        }


        //Validaciones


        private void Txtingresar_Cliente_documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }


        private void Txtingresar_cliente_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloLetras(e);
        }


        private void Txtingresar_Cliente_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }
    }
}
