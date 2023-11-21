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

namespace Supermercado2Chinos
{
    public partial class fmrCategoria : Form
    {
        public fmrCategoria()
        {
            InitializeComponent();
        }

        private void fmrCategoria_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });  //MUESTRA EL ESTADO ES LOS COMBO BOX
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto"; //lo que muestra el combobox
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

           
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

            //Mostrar todos las Categorias en el datagv
            List<Categoria> lista = new CN_Categoria().Listar();
            foreach (Categoria item in lista)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdCategoria,
                item.Descripcion,
                item.Estado==true ? 1 : 0, //si es verdadero muestra es 1 en el estado si no 0.
                item.Estado== true ? "Activo" : "No Activo" //si es verdadero muestra es activo..
        });

            }
        }

        private void btbguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Categoria obj = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtid.Text),
                Descripcion = txtdescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdCategoria == 0)
            {

                int idGenerado = new CN_Categoria().Registrar(obj, out mensaje);

                if (idGenerado != 0) // si hubo un registro correcto de un usuario va a mostrarlo en el datagridview
                {

                    dgvdata.Rows.Add(new object[] {"",idGenerado,txtdescripcion.Text,
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
                bool resultado = new CN_Categoria().Editar(obj, out mensaje);

                if (resultado)
                {
                    if (MessageBox.Show("¿Desea EDITAR el usuario seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)]; //obtengo la fila para poder editar las calumnas
                        row.Cells["Id"].Value = txtid.Text;
                        row.Cells["Descripcion"].Value = txtdescripcion.Text;
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
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;

            txtdescripcion.Select();// el cursor vuelve al documento


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
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                  
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if ( (oc.Valor) ==  dgvdata.Rows[indice].Cells["EstadoValor"].Value)
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
                if (MessageBox.Show("¿Desea ELIMINAR la Categoria seleccionada?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Categoria objcategoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtid.Text),

                    };


                    bool respuesta = new CN_Categoria().Eliminar(objcategoria, out mensaje);

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

       

        private void btnbuscar_Click(object sender, EventArgs e)
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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
