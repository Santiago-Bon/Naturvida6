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
    public partial class naturvida : Form
    {
        public naturvida()
        {
            InitializeComponent();
        }


        private void Abrir(Form hijo) //Craga los formularios en el panel
        {
            this.panel1.Controls.Clear(); //limpia el panel
            //Form2 hijo = new Form2(); //Instancia
            hijo.TopLevel = false; //Para que no sea mas grande que el panel
            hijo.Dock = DockStyle.Fill; //Da formato completo
            this.panel1.Controls.Add(hijo); //Agrega el formulario que está en hijo
            hijo.Show(); //Abre el formulario en el panel
        }


        //Inicio Naturvida al cargar


        private void naturvida_Load(object sender, EventArgs e)
        {
            Form presentacion = new Presentacion();
            Abrir(presentacion);
        }


        //Productos


        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Gestion_productos = new Gestion_productos();
            Abrir(Gestion_productos);
        }


        //Clientes


        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form clientes = new Clientes();
            Abrir(clientes);
        }


        //Inventario


        private void consultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inventario = new Inventario();
            Abrir(inventario);
        }


        //Facturación


        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form factura = new Factura();
            Abrir(factura);
        }


        //Vendedores


        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form vendedores = new Vendedores();
            Abrir(vendedores);
        }


        //Inicio de Sesión


        private void inicioSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inicio_sesion = new Form1();
            inicio_sesion.Show();
            Hide();
        }


        //Inicio Naturvida


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form presentacion = new Presentacion();
            Abrir(presentacion);
        }


        //Salir


        private void salirToolStripMenuItem_Click(object sender, EventArgs e) //Sale de la aplicación
        {
            Application.Exit();
        }
    }
}
