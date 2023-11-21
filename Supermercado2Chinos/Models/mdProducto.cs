using CapaDatos;
using CapaEntidad1;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermercado2Chinos.Models
{
    public partial class mdProducto : Form
    {

        public Producto _Producto { get; set; }
        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                   
                }
            }
            cbobusqueda.DisplayMember = "Texto"; //lo que muestra el combo box
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //Mostrar todos los usuarios en el datagv
            List<Producto> listaproducto = new CN_Producto().Listar();

            foreach (Producto item in listaproducto)
            {
                dgvdata.Rows.Add(new object[] 
                {
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.oCategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
               
                });
            }
        }
       

        

        private void btbbuscar_Click(object sender, EventArgs e)
        {
            string columnafiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)           // trim elimina los espacios antes y despues de valor
                                                                        //toUpper lo convierte a mayuscula para faciitar la busqueda
                                                                        // y que coincida en ambos
                {
                    if (row.Cells[columnafiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;

                    }
                    else { row.Visible = false; }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            };
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Id"].Value.ToString()),
                    Codigo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvdata.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dgvdata.Rows[iRow].Cells["PrecioCompra"].Value.ToString()),
                    PrecioVenta = Convert.ToDecimal(dgvdata.Rows[iRow].Cells["PrecioVenta"].Value.ToString()),

                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
