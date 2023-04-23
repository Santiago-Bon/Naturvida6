using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CE_Entidades;
using CapaNegocios;
using CapaPresentacion.Properties;
using System.Security.Cryptography.X509Certificates;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Vendedores oCN_Vendedores = new CN_Vendedores();


        static public class VendedorGlobal //Se crea una variable global
        {
            static public string vendedor1 { get; set; }
        }


        public Form1()
        {
            InitializeComponent();
        }


        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            CE_Vendedores vendedores = new CE_Vendedores();
            CN_Validaciones validacion = new CN_Validaciones();

            VendedorGlobal.vendedor1 = TxtLogin.Text; //La variable global va a ser igual al login ingresado
            vendedores.Usuario = TxtLogin.Text.Trim();
            //vendedor.Usuario = TxtLogin.Text.Trim();
            //string vendedor2 = TxtLogin.Text;          
            //MessageBox.Show(vendedor1);
            vendedores.Contraseña = validacion.Encriptacion(TxtContraseña.Text.ToLower().Trim()); //Encripta la contraseña

            if (oCN_Vendedores.buscardatovende(vendedores) == true) //Si la búsqueda del vendedor es igual a verdadera pasa al formulario de naturvida
            {
                Form naturvida = new naturvida();
                naturvida.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
        //public string vendedor()
        //{
        //    string vendedor = TxtLogin.Text;
        //    return vendedor;
        //}


        private void BtnSalir_Click(object sender, EventArgs e) //Sale de la aplicación
        {
            Application.Exit();
        }
    }
}
