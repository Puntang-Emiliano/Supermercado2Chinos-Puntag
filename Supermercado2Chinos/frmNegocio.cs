using CapaEntidad1;
using CapaNegocio;
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


namespace Supermercado2Chinos
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }
        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes,0,imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new CN_Supermercado().ObtenerLogo(out obtenido);

            if (obtenido)
            {
                picLogo.Image = ByteToImage(byteimage);
            }

            Supermercado datos = new CN_Supermercado().Datos();

            txtnombre.Text = datos.Nombre;
            txtcuit.Text = datos.CUIT;
            txtdireccion.Text = datos.Direccion;
        }

        private void btnsubirlogo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.FileName = "Files |*.jpg;*jpeg;*.png";

            if(oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(oOpenFileDialog.FileName);
                bool respuesta = new CN_Supermercado().ActualizarLogo(byteimage, out mensaje);

                if (respuesta)
                {
                    picLogo.Image = ByteToImage(byteimage);
                }
                else
                    MessageBox.Show(mensaje,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Supermercado obj = new Supermercado()
            {
                Nombre = txtnombre.Text,
                CUIT = txtcuit.Text,
                Direccion = txtdireccion.Text,
            };

            bool respuesta = new CN_Supermercado().GuardarDatos(obj, out mensaje);

            if ( respuesta)
            {
                MessageBox.Show("Los cambios se guardaron con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No se Pudo guardar los Cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
