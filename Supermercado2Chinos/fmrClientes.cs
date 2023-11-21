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
    public partial class fmrClientes : Form
    {
        public fmrClientes()
        {
            InitializeComponent();
        }

        private void fmrClientes_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });  //MUESTRA EL ESTADO ES LOS COMBO BOX
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto"; //lo que muestra el combo box
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            List<Rol> listarol = new CN_Rol().Listar();


            
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
            List<Cliente> lista = new CN_Cliente().Listar();
            foreach (Cliente item in lista)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdCliente,item.Documento,item.NombreCompleto,item.Correo,item.Telefono,
                item.Estado==true ? 1 : 0, //si es verdadero muestra es 1 en el estado si no 0.
                item.Estado== true ? "Activo" : "No Activo" //si es verdadero muestra es activo..
        });
            }
        }

        private void btbguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Cliente obj = new Cliente()
            {
                IdCliente = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdCliente == 0)
            {

                int idgenerado = new CN_Cliente().Registrar(obj, out mensaje);

                if (idgenerado != 0) // si hubo un registro correcto de un usuario va a mostrarlo en el datagridview
                {

                    dgvdata.Rows.Add(new object[] {"",idgenerado,txtdocumento.Text,txtnombrecompleto.Text,txtcorreo.Text,txttelefono.Text, 
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
                bool resultado = new CN_Cliente().Editar(obj, out mensaje);

                if (resultado)
                {
                    if (MessageBox.Show("¿Desea EDITAR el usuario seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)]; //obtengo la fila para poder editar las calumnas
                        row.Cells["Id"].Value = txtid.Text;
                        row.Cells["Documento"].Value = txtdocumento.Text;
                        row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                        row.Cells["Correo"].Value = txtcorreo.Text;
                        row.Cells["Telefono"].Value = txttelefono.Text;
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
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cboestado.SelectedIndex = 0;
            txtdocumento.Select();// el cursor vuelve al documento


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
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();

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
                if (MessageBox.Show("¿Desea ELIMINAR el Cliente seleccionado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Cliente obj = new Cliente()
                    {
                        IdCliente = Convert.ToInt32(txtid.Text),

                    };


                    bool respuesta = new CN_Cliente().Eliminar(obj, out mensaje);

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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
    
}
