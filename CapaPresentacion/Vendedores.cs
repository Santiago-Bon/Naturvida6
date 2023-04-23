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
    public partial class Vendedores : Form
    {
        CE_Vendedores vendedores = new CE_Vendedores();
        CN_Vendedores oCN_Vendedores = new CN_Vendedores();
        CN_Validaciones validaciones = new CN_Validaciones();


        public Vendedores()
        {
            InitializeComponent();
        }


        private void Vendedores_Load(object sender, EventArgs e)
        {
            mostrartodoseditarvendedores();
            Limpiar();
            mostrarnombrevendedor();
            editarmostrarnombrevendedor();
            eliminarmostrarnombrevendedor();
        }


        #region Mis métodos


        private void Limpiar() //Limpia las cajas de texto de ingresar vendedor
        {
            Txtingresar_vendedor_codigo.Clear();
            Txtingresar_vendedor_usuario.Clear();
            Txtingresar_vendedor_contrasena.Clear();
            Txtingresar_vendedor_nombre.Clear();
            TxtRepetir_Contraseña.Clear();
        }


        private void LimpiarEditar() //Limpia las cajas de texto de editar vendedor
        {
            Txtmodificar_vendedor_codigo.Clear();
            Txtmodificar_vendedor_usuario.Clear();
            Txtmodificar_vendedor_nombre.Clear();
            Txtmodificar_vendedor_contrasena.Clear();
        }


        //Consultar


        private void mostrarnombrevendedor() //Muestra el usuario de los vendedores en el combobox de consultar vendedores
        {
            Cbxconsultar_vendedor_vendedor.DataSource = oCN_Vendedores.Buscarnombrevend();
            Cbxconsultar_vendedor_vendedor.DisplayMember = "Usuario";
            Cbxconsultar_vendedor_vendedor.ValueMember = "Codigo";
            Cbxconsultar_vendedor_vendedor.SelectedIndex = -1;
        }


        private void mostrartodosvendedores() //Muestra los datos del vendedor seleccionado en el combobox en el datagridview de consultar vendedores
        {
            vendedores.Codigo = Convert.ToInt32(Cbxconsultar_vendedor_vendedor.SelectedValue);
            Dgwconsultarvendedor.DataSource = oCN_Vendedores.BuscarTodosvend(vendedores);
        }


        private void mosstrartablatodovendedores() //Muestra todos los datos de los vendedores en el datagridview de consultar vendedores
        {
            Dgwconsultarvendedor.DataSource = oCN_Vendedores.mostrartodatablavend();
            Cbxconsultar_vendedor_vendedor.SelectedIndex = -1;
        }


        //Editar


        private void editarmostrarnombrevendedor() //Muestra el usuario de los vendedores en el combobox de editar vendedores
        {
            Cbomodificar_vendedor_usuario.DataSource = oCN_Vendedores.Buscarnombrevend();
            Cbomodificar_vendedor_usuario.DisplayMember = "Usuario";
            Cbomodificar_vendedor_usuario.ValueMember = "Codigo";
            Cbomodificar_vendedor_usuario.SelectedIndex = -1;
        }


        private void mostrartodoseditarvendedores() //Muestra todos los datos de los vendedores en el datagridview oculto de editar vendedores
        {
            CE_Vendedores vendedores = new CE_Vendedores();
            vendedores.Codigo = Convert.ToInt32(Cbomodificar_vendedor_usuario.SelectedValue);
            dataGridView1.DataSource = oCN_Vendedores.mostrartodatablavendeditar(vendedores);
            dataGridView1.Visible = false;
        }


        //Eliminar


        private void eliminarmostrarnombrevendedor() //Muestra el usuario de los vendedores en el combobox de eliminar vendedores
        {
            Cboeliminar_vendedor_usuario.DataSource = oCN_Vendedores.Buscarnombrevend();
            Cboeliminar_vendedor_usuario.DisplayMember = "Usuario";
            Cboeliminar_vendedor_usuario.ValueMember = "Codigo";
            Cboeliminar_vendedor_usuario.SelectedIndex = -1;
        }


        #endregion


        //Ingresar


        private void Btningresa_vendedor_guardar_Click(object sender, EventArgs e)
        {
            CN_Validaciones encriptacion = new CN_Validaciones();

            if (Txtingresar_vendedor_codigo.Text == string.Empty || //Verifica que ningún campo esté vacio
                Txtingresar_vendedor_usuario.Text == string.Empty ||
                Txtingresar_vendedor_contrasena.Text == string.Empty ||
                Txtingresar_vendedor_nombre.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                vendedores.Codigo = Convert.ToInt32(Txtingresar_vendedor_codigo.Text); ;
                vendedores.Usuario = Txtingresar_vendedor_usuario.Text.Trim();

                if (oCN_Vendedores.BuscarVend(vendedores) == false) //Envia el código y el usuario y verifica que no exista otro vendedor con el mismo contenido
                {
                    vendedores.Codigo = Convert.ToInt32(Txtingresar_vendedor_codigo.Text);
                    vendedores.Usuario = Txtingresar_vendedor_usuario.Text.Trim();
                    vendedores.Contraseña = encriptacion.Encriptacion(Txtingresar_vendedor_contrasena.Text.ToLower().Trim()); //Encripta la contraseña
                    vendedores.Nombre = Txtingresar_vendedor_nombre.Text.Trim();

                    if (Txtingresar_vendedor_contrasena.Text.Trim() == TxtRepetir_Contraseña.Text.Trim()) //Verifica que la contraseña y su repetición coincidan
                    {
                        oCN_Vendedores.InsertarVend(vendedores); //Ingresa el vendedor
                        MessageBox.Show("Se ingresó correctamente el vendedor");
                        Limpiar(); //Limpia las cajas de texto
                        mostrarnombrevendedor();
                        mostrartodoseditarvendedores();
                        editarmostrarnombrevendedor();
                        eliminarmostrarnombrevendedor();
                    }
                    else
                    {
                        MessageBox.Show("Error las contraseñas no coinciden");
                    }
                }
                else
                {
                    MessageBox.Show("El vendedor ya existe");
                }
            }
        }


        private void Btningresar_vendedor_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        //Modificar


        private void Btnmodificar_vendedor_consultar_Click(object sender, EventArgs e)
        {
            mostrartodoseditarvendedores();
            if (Cbomodificar_vendedor_usuario.SelectedIndex >= 0) //Si lo seleccionado en el combobox es mayor a 0 trae los campos del datagridview a las cajas de texto
            {
                Txtmodificar_vendedor_codigo.Text = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                Txtmodificar_vendedor_usuario.Text = dataGridView1.CurrentRow.Cells["Usuario"].Value.ToString();
                //Txtmodificar_vendedor_contrasena.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
                Txtmodificar_vendedor_nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            }
            mostrarnombrevendedor();
            editarmostrarnombrevendedor();
            eliminarmostrarnombrevendedor();
            mostrartodoseditarvendedores();
        }


        private void Btnmodificar_vendedor_guardarcambios_Click(object sender, EventArgs e)
        {
            if (Txtmodificar_vendedor_codigo.Text == string.Empty || //Verifica que ningún campo esté vacio
                Txtmodificar_vendedor_usuario.Text == string.Empty ||
                Txtmodificar_vendedor_nombre.Text == string.Empty)
            {
                MessageBox.Show("Error ingrese los datos");
            }
            else
            {
                vendedores.Codigo = Convert.ToInt32(Txtmodificar_vendedor_codigo.Text);
                vendedores.Usuario = Txtmodificar_vendedor_usuario.Text.Trim();

                if (oCN_Vendedores.BuscarVendEditar(vendedores) == false) //Envia el código y el usuario y verifica que no exista otro vendedor con el mismo contenido
                {
                    vendedores.Codigo = Convert.ToInt32(Txtmodificar_vendedor_codigo.Text);
                    vendedores.Usuario = Txtmodificar_vendedor_usuario.Text.Trim();
                    vendedores.Nombre = Txtmodificar_vendedor_nombre.Text.Trim();
                    oCN_Vendedores.EditarVend(vendedores);
                    MessageBox.Show("Se editó correctamente"); //Edita el vendedor
                    mostrartodoseditarvendedores();
                    mostrarnombrevendedor();
                    editarmostrarnombrevendedor();
                    eliminarmostrarnombrevendedor();
                    LimpiarEditar(); //Limpia las cajas de texto
                }
                else
                {
                    MessageBox.Show("El vendedor ya existe");
                }
            }
        }


        //Consultar


        private void Btn_consultar_vendedor_consultar_Click(object sender, EventArgs e)
        {
            mostrartodosvendedores();
            //mostrarnombrevendedor();
        }


        private void Btnconsultar_vendedor_mostrarvendedor_Click(object sender, EventArgs e)
        {
            mosstrartablatodovendedores();
            //mostrartodoseditarvendedores();
            //editarmostrarnombrevendedor();
            //mostrarnombrevendedor();
            //eliminarmostrarnombrevendedor();
        }


        //Eliminar


        private void Btneliminar_vendedor_vendedor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres eliminar", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes) //Mensaje de verificación al usuario para proceder a eliminar
            {
                vendedores.Codigo = Convert.ToInt32(Cboeliminar_vendedor_usuario.SelectedValue);
                oCN_Vendedores.eliminarvend(vendedores); //Elimina el vendedor
                Cboeliminar_vendedor_usuario.SelectedIndex = -1;
                MessageBox.Show("Se eliminó correctamente");
                mostrartodoseditarvendedores();
                mostrarnombrevendedor();
                editarmostrarnombrevendedor();
                eliminarmostrarnombrevendedor();
            }
            else
            {
                MessageBox.Show("Se canceló la eliminación");
            }
        }


        //Validaciones


        private void Txtingresar_vendedor_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloNum(e);
        }


        private void Txtingresar_vendedor_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloLetras(e);
        }


        private void Txtmodificar_vendedor_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.SoloLetras(e);

        }
    }
}
