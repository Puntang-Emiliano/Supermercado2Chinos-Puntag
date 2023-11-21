using CapaEntidad1;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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
    public partial class fmrDetalleVenta : Form
    {
        public fmrDetalleVenta()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Venta _venta = new CN_Venta().ObtenerVenta(txtbusqueda.Text);

            if (_venta.IdVenta != 0)
            {

                txtnumerodocumento.Text = _venta.NumeroDocumento;

                txtfecha.Text = _venta.FechaRegistro;
                txttipodocumento.Text = _venta.TipoDocumento;
                txtusuario.Text = _venta.oUsuario.NombreCompleto;


                txtdoccliente.Text = _venta.DocumentoCliente;
                txtnombrecliente.Text = _venta.NombreCliente;

                dgvdata.Rows.Clear();
                foreach (Detalle_Venta dv in _venta.Detalle_Venta)
                {
                    dgvdata.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal });
                }

                txtmontototal.Text = _venta.MontoTotal.ToString("0.00");
                txtmontopago.Text = _venta.MontoPago.ToString("0.00");
                txtmontocambio.Text = _venta.MontoCambio.ToString("0.00");


            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdoccliente.Text = "";
            txtnombrecliente.Text = "";
            txtbusqueda.Text = "";

            dgvdata.Rows.Clear();
            txtmontototal.Text = "0.00";
            txtmontopago.Text = "0.00";
            txtmontocambio.Text = "0.00";

        }

        private void btndescargar_Click(object sender, EventArgs e)
        {
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
            Supermercado _datos = new CN_Supermercado().Datos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", _datos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", _datos.CUIT);
            Texto_Html = Texto_Html.Replace("@direcnegocio", _datos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);


            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {

                    Document _pdf = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(_pdf, stream);
                    _pdf.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Supermercado().ObtenerLogo(out obtenido); //OBTENEMOS EL LOGO CARGADO..

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(_pdf.Left, _pdf.GetTop(51));
                        _pdf.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, _pdf, sr);
                    }

                    _pdf.Close();
                    stream.Close();
                    MessageBox.Show("PDF GENERADO CON EXITO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
