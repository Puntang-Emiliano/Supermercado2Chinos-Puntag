using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace Supermercado2Chinos
{
    public partial class frmCamara : Form
    {
        private bool dispositivoVinculado = false;
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice cam1 = null;

        public frmCamara()
        {
            InitializeComponent();
        }

        private void frmCamara_Load(object sender, EventArgs e)
        {
            CargarDispositivos();

        }


        public void CargarDispositivos()
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(dispositivos.Count > 0)
            {
                dispositivoVinculado = true;
                for (int i = 0; i < dispositivos.Count; i++)
                {
                    cboCam.Items.Add(dispositivos[i].Name.ToString()); //va a cargar los dispositivos vinculados
                }
                cboCam.Text = dispositivos[0].ToString();
            }
            else
            {
                dispositivoVinculado = false;
            }
        }

        public void CerrarCam()
        {
           if (cam1 != null && cam1.IsRunning)
            {
                cam1.SignalToStop();
                cam1 = null;
            }
        }

        private void btniniciarcam_Click(object sender, EventArgs e)
        {
            CerrarCam();
            int i = cboCam.SelectedIndex;
            if (i == -1) MessageBox.Show("Debe Seleccionar una Camara");
            else
            {
                string nombreVideo = dispositivos[i].MonikerString; // captura el nombre del dispositivo de ese indice
                cam1 = new VideoCaptureDevice(nombreVideo);
                cam1.NewFrame += new NewFrameEventHandler(Capturando);
                cam1.Start();
            }; 

        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            picCam.Image = Imagen;

        }

        private void frmCamara_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarCam();
        }

        private void btnapagar_Click(object sender, EventArgs e)
        {
            CerrarCam();
            picCam.Image = null;
        }
    }
}
