using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad1;

namespace Supermercado2Chinos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            

            Usuario ousuario = new CN_Usuario().Listar().Where(x => x.Documento ==txtDocumento.Text && x.Clave ==
            txtClave.Text).FirstOrDefault();

            if (ousuario != null)
            {

                Inicio form = new Inicio(ousuario);

                form.Show();
                this.Hide();

                form.FormClosing += fmr_closing;
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto","MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void fmr_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
