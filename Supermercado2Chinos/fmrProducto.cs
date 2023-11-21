using CapaDatos;
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
    public partial class fmrProducto : Form
    {
        public fmrProducto()
        {
            InitializeComponent();
        }

        private void fmrProducto_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });  //MUESTRA EL ESTADO ES LOS COMBO BOX
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto"; //lo que muestra el combo box
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            List<Categoria> listacategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listacategoria)
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto"; //lo que muestra el combo box
            cbocategoria.ValueMember = "Valor";
            cbocategoria.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                    cbobusqueda.DisplayMember = "Texto"; //lo que muestra el combo box
                    cbobusqueda.ValueMember = "Valor";
                    cbobusqueda.SelectedIndex = 0;
                }
            }

            //Mostrar todos los usuarios en el datagv
            List<Producto> listaproducto = new CN_Producto().Listar();

            foreach (Producto item in listaproducto)
            {
                dgvdata.Rows.Add(new object[] {
                "",
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.oCategoria.IdCategoria,
                item.oCategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
                item.Estado==true ? 1 : 0, //si es verdadero muestra es 1 en el estado si no 0.
                item.Estado== true ? "Activo" : "No Activo" //si es verdadero muestra es activo..
        });
            }

        }

        private void btbguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Producto obj = new Producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtnombre.Text,
                Descripcion = txtdescripcion.Text,

                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdProducto == 0)
            {

                int idgenerado = new CN_Producto().Registrar(obj, out mensaje);

                if (idgenerado != 0) // si hubo un registro correcto de un usuario va a mostrarlo en el datagridview
                {

                    dgvdata.Rows.Add(new object[] {
                    "",
                    txtcodigo.Text,
                    txtnombre.Text,
                    txtdescripcion.Text,
                    ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString(),
                    "0",
                    "0.00",
                    "0.00",
                    ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
                    });

                    Limpiar();
                }

                else
                {
                    MessageBox.Show(mensaje);
                }

            }
            else
            {
                bool resultado = new CN_Producto().Editar(obj, out mensaje);

                if (resultado)
                {
                    if (MessageBox.Show("¿Desea EDITAR el PRODUCTO seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)]; //obtengo la fila para poder editar las calumnas
                        row.Cells["Id"].Value = txtid.Text;
                        row.Cells["Codigo"].Value = txtcodigo.Text;
                        row.Cells["Nombre"].Value = txtnombre.Text;
                        row.Cells["Descripcion"].Value = txtdescripcion.Text;
                        row.Cells["IdCategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
                        row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString();
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                        row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();

                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }



        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            cbocategoria.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

            txtcodigo.Select();// el cursor vuelve al documento


        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();

                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();



                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        if ((oc.Valor) == dgvdata.Rows[indice].Cells["EstadoValor"].Value)
                        {
                            int indice_combo = cbocategoria.Items.IndexOf(oc);
                            cbocategoria.SelectedIndex = indice_combo; // muestra el indice
                            break;
                        }
                    }


                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if ((oc.Valor) == dgvdata.Rows[indice].Cells["EstadoValor"].Value)
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }


            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea ELIMINAR el Producto seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Producto obj = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtid.Text),

                    };


                    bool respuesta = new CN_Producto().Eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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

        private void btngenerarexel_Click(object sender, EventArgs e)
        {
             if(dgvdata.Rows.Count <1)
            {
                MessageBox.Show("NO HAY QUE EXPORTAR","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
             else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                                row.Cells[2].Value.ToString(),
                                row.Cells[3].Value.ToString(),
                                row.Cells[4].Value.ToString(),
                                row.Cells[6].Value.ToString(),
                                row.Cells[7].Value.ToString(),
                                row.Cells[8].Value.ToString(),
                                row.Cells[9].Value.ToString(),
                                row.Cells[11].Value.ToString(),
                        });
                }  

                        SaveFileDialog savefile = new SaveFileDialog();
                        savefile.FileName = string.Format("ListaProductos_{0}.xlsx",DateTime.Now.ToString("ddMMyyyyHHmmss"));
                        savefile.Filter = "Excel Files | *.xlsx";
                        
                        if(savefile.ShowDialog()== DialogResult.OK)
                        {
                            try
                            {
                                XLWorkbook wb = new XLWorkbook();
                                var hoja = wb.Worksheets.Add(dt, "Informe");
                                hoja.ColumnsUsed().AdjustToContents(); //ajusta el contenido solo a la columnas que usamos
                                wb.SaveAs(savefile.FileName);
                                MessageBox.Show("Informe de Productos generado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                            }
                            catch 
                            {
                                MessageBox.Show("Error al generar el Informe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                        }

                    }
                
            

        }
    }
}
