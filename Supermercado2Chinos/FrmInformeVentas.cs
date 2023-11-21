using CapaEntidad1;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermercado2Chinos
{
    public partial class FrmInformeVentas : Form
    {
        public FrmInformeVentas()
        {
            InitializeComponent();
        }

        private void FrmInformeVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = col.Name, Texto = col.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

        }

        private void btnbuscarreporte_Click(object sender, EventArgs e)
        {
            List<InformeVenta> lista = new List<InformeVenta>();

            lista = new CN_Informe().Venta(txtfechainicio.Value.ToString(), txtfechafin.Value.ToString());

            dgvdata.Rows.Clear();

            foreach (InformeVenta item in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    item.FechaRegistro,
                    item.TipoDocumento,
                    item.NumeroDocumento,
                    item.MontoTotal,
                    item.UsuarioRegistro,
                    item.DocumentoCliente,
                    item.NombreCliente,
                    item.CodigoProducto,
                    item.NombreProducto,
                    item.Categoria,
                    item.PrecioVenta,
                    item.Cantidad,
                    item.SubTotal
                });

            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string filtro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[filtro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }

                }
            }

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }

        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {

                MessageBox.Show("No se encontro nada para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                        });
                }

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("InformeVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("El Informe se  genero correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar Informe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

            }
        }
    }
}
