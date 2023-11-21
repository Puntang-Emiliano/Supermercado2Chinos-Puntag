namespace Supermercado2Chinos
{
    partial class frmCamara
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboCam = new System.Windows.Forms.ComboBox();
            this.picCam = new System.Windows.Forms.PictureBox();
            this.btniniciarcam = new System.Windows.Forms.Button();
            this.btnapagar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCam)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCam
            // 
            this.cboCam.FormattingEnabled = true;
            this.cboCam.Location = new System.Drawing.Point(53, 12);
            this.cboCam.Name = "cboCam";
            this.cboCam.Size = new System.Drawing.Size(184, 21);
            this.cboCam.TabIndex = 0;
            // 
            // picCam
            // 
            this.picCam.Location = new System.Drawing.Point(53, 45);
            this.picCam.Name = "picCam";
            this.picCam.Size = new System.Drawing.Size(735, 414);
            this.picCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCam.TabIndex = 1;
            this.picCam.TabStop = false;
            // 
            // btniniciarcam
            // 
            this.btniniciarcam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniniciarcam.Location = new System.Drawing.Point(273, 12);
            this.btniniciarcam.Name = "btniniciarcam";
            this.btniniciarcam.Size = new System.Drawing.Size(112, 27);
            this.btniniciarcam.TabIndex = 2;
            this.btniniciarcam.Text = "Iniciar Camara";
            this.btniniciarcam.UseVisualStyleBackColor = true;
            this.btniniciarcam.Click += new System.EventHandler(this.btniniciarcam_Click);
            // 
            // btnapagar
            // 
            this.btnapagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapagar.Location = new System.Drawing.Point(401, 12);
            this.btnapagar.Name = "btnapagar";
            this.btnapagar.Size = new System.Drawing.Size(112, 27);
            this.btnapagar.TabIndex = 3;
            this.btnapagar.Text = "Apagar Camara";
            this.btnapagar.UseVisualStyleBackColor = true;
            this.btnapagar.Click += new System.EventHandler(this.btnapagar_Click);
            // 
            // frmCamara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.btnapagar);
            this.Controls.Add(this.btniniciarcam);
            this.Controls.Add(this.picCam);
            this.Controls.Add(this.cboCam);
            this.Name = "frmCamara";
            this.Text = "frmCamara";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCamara_FormClosed);
            this.Load += new System.EventHandler(this.frmCamara_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCam;
        private System.Windows.Forms.PictureBox picCam;
        private System.Windows.Forms.Button btniniciarcam;
        private System.Windows.Forms.Button btnapagar;
    }
}