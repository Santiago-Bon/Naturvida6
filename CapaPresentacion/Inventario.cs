using CapaNegocios;
using CE_Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Inventario : Form
    {
        CN_Productos inventario = new CN_Productos();


        public Inventario()
        {
            InitializeComponent();
        }


        private void Inventario_Load(object sender, EventArgs e)
        {
            mostrarnombreproducto();
            BtnExportarExcel.Enabled = false;
            BtnExportarPdf.Enabled = false;
        }


        #region Mis Métodos


        private void mostrarnombreproducto() //Muestra la descripción de los productos en el combobox de factura
        {
            Cbo_Inventario_Producto.DataSource = inventario.Buscarnombreprod();
            Cbo_Inventario_Producto.DisplayMember = "Descripción";
            Cbo_Inventario_Producto.ValueMember = "Codigo";
            Cbo_Inventario_Producto.SelectedIndex = -1;
        }


        private void MostrarInventarioConsultar() //Muestra los datos del producto seleccionado en el combobox en el datagridview de inventario
        {
            CE_Productos inventario1 = new CE_Productos();
            inventario1.Codigo = Convert.ToInt32(Cbo_Inventario_Producto.SelectedValue);
            Dgv_Inventario.DataSource = inventario.MostrarInventarioConsultar(inventario1);
        }


        private void MostrarInventarioMostrarTodo() //Muestra todos los datos de los productos en el datagridview de inventario
        {
            Dgv_Inventario.DataSource = inventario.MostrarInventarioMostrarTodo();
        }


        #endregion


        private void Btn_Inventario_Consultar_Click(object sender, EventArgs e)
        {
            MostrarInventarioConsultar();
            BtnExportarExcel.Enabled = true;
            BtnExportarPdf.Enabled = true;
        }


        private void Btn_MInventario_Mostrar_Todo_Click(object sender, EventArgs e)
        {
            MostrarInventarioMostrarTodo();
            BtnExportarExcel.Enabled = true;
            BtnExportarPdf.Enabled = true;
        }


        //Exportar a Excel


        public void ExportarExcel(DataGridView Dgvproductos) //Exporta a excel recibiendo el datagridview de inventario como parámetro 
        {
            Microsoft.Office.Interop.Excel.Application exportar = new Microsoft.Office.Interop.Excel.Application();

            exportar.Application.Workbooks.Add(true);

            int Indicecolumna = 0;

            foreach (DataGridViewColumn columns in Dgvproductos.Columns)
            {
                Indicecolumna++;
                exportar.Cells[1, Indicecolumna] = columns.Name;
            }

            int Indicefila = 0;

            foreach (DataGridViewRow filas in Dgvproductos.Rows)
            {
                Indicefila++;
                Indicecolumna = 0;

                foreach (DataGridViewColumn columnas in Dgv_Inventario.Columns)
                {
                    Indicecolumna++;
                    exportar.Cells[Indicefila + 1, Indicecolumna] = filas.Cells[columnas.Name].Value;
                }
            }
            exportar.Visible = true;
        }


        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel(Dgv_Inventario); //Envía el datagridview de inventario como parámetro
        }


        //Exportar a PDF


        private void BtnExportarPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog(); //Se crea un objeto de tipo savefiledialog
            string ruta = string.Empty;

            guardar.Filter = "Archivo pdf (*.pdf)|*.pdf"; //Se filtra por pdf
            guardar.Title = "Guardar";

            if (guardar.ShowDialog() == DialogResult.OK) //Si la respuesta del savefiledialog abierto es igual a ok
            { 
                ruta = guardar.FileName; //Se guarda la ruta en una variable
                
                FileStream filestream = new FileStream(ruta, FileMode.Create);
                {
                    Document documento = new Document(PageSize.A4);
                    PdfWriter pdfwriter = PdfWriter.GetInstance(documento, filestream);
                    documento.Open();

                    PdfPTable pdfptable = new PdfPTable(Dgv_Inventario.Columns.Count);

                    foreach (DataGridViewColumn columnas in Dgv_Inventario.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(columnas.HeaderText));
                        pdfptable.AddCell(cell);
                    }

                    if (Dgv_Inventario.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in Dgv_Inventario.Rows)
                        {
                            foreach (DataGridViewCell celdas in fila.Cells)
                            {
                                pdfptable.AddCell(celdas.Value?.ToString() ?? "");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar al pdf");
                    }
                    documento.Add(pdfptable);
                    documento.Close();
                }
            }
        }
    }
}

