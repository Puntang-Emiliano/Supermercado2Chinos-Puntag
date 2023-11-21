﻿using CapaEntidad1;
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
    public partial class fmrDetalleCompra : Form
    {
        public fmrDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra _Compra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);

            if (_Compra.IdCompra != 0)
            {

                txtnumerodocumento.Text = _Compra.NumeroDocumento;

                txtfecha.Text = _Compra.FechaRegistro;
                txttipodocumento.Text = _Compra.TipoDocumento;
                txtusuario.Text = _Compra.oUsuario.NombreCompleto;
                txtdocproveedor.Text = _Compra.oProveedor.Documento;
                txtnombreproveedor.Text = _Compra.oProveedor.RazonSocial;

                dgvdata.Rows.Clear();
                foreach (Detalle_Compra dc in _Compra.oDetalleCompra)
                {
                    dgvdata.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                txtmontototal.Text = _Compra.MontoTotal.ToString("0.00");

            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdocproveedor.Text = "";
            txtnombreproveedor.Text = "";

            dgvdata.Rows.Clear();
            txtmontototal.Text = "0.00";
        }

        private void btndescargar_Click(object sender, EventArgs e)
        {
            
                if (txttipodocumento.Text == "")
                {
                    MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string Texto_Html = Properties.Resources.PlantillaCompra.ToString();
                Supermercado odatos = new CN_Supermercado().Datos();

                Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
                Texto_Html = Texto_Html.Replace("@docnegocio", odatos.CUIT);
                Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

                Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
                Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);


                Texto_Html = Texto_Html.Replace("@docproveedor", txtdocproveedor.Text);
                Texto_Html = Texto_Html.Replace("@nombreproveedor", txtnombreproveedor.Text);
                Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
                Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

                string filas = string.Empty;
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                    filas += "</tr>";
                }
                Texto_Html = Texto_Html.Replace("@filas", filas);
                Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
                savefile.Filter = "Pdf Files|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {

                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        bool obtenido = true;
                        byte[] byteImage = new CN_Supermercado().ObtenerLogo(out obtenido); //OBTENEMOS EL LOGO CARGADO..

                        if (obtenido)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                            pdfDoc.Add(img);
                        }

                        using (StringReader sr = new StringReader(Texto_Html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("PDF GENERADO CON EXITO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            
        }

       
    }
}