
namespace OlimpiadaCompras.Telas.Coordenacao
{
    partial class FrmVisualizarNotaFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualizarNotaFiscal));
            this.pdfReader = new AxAcroPDFLib.AxAcroPDF();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnReprovar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnBaixar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pdfReader)).BeginInit();
            this.SuspendLayout();
            // 
            // pdfReader
            // 
            this.pdfReader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfReader.Enabled = true;
            this.pdfReader.Location = new System.Drawing.Point(0, 0);
            this.pdfReader.Name = "pdfReader";
            this.pdfReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfReader.OcxState")));
            this.pdfReader.Size = new System.Drawing.Size(848, 438);
            this.pdfReader.TabIndex = 0;
            // 
            // btnAprovar
            // 
            this.btnAprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnAprovar.FlatAppearance.BorderSize = 0;
            this.btnAprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprovar.ForeColor = System.Drawing.Color.White;
            this.btnAprovar.Location = new System.Drawing.Point(669, 446);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(169, 34);
            this.btnAprovar.TabIndex = 36;
            this.btnAprovar.Text = "Aprovar";
            this.btnAprovar.UseVisualStyleBackColor = false;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // btnReprovar
            // 
            this.btnReprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(17)))), ((int)(((byte)(54)))));
            this.btnReprovar.FlatAppearance.BorderSize = 0;
            this.btnReprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprovar.ForeColor = System.Drawing.Color.White;
            this.btnReprovar.Location = new System.Drawing.Point(494, 446);
            this.btnReprovar.Name = "btnReprovar";
            this.btnReprovar.Size = new System.Drawing.Size(169, 34);
            this.btnReprovar.TabIndex = 37;
            this.btnReprovar.Text = "Reprovar";
            this.btnReprovar.UseVisualStyleBackColor = false;
            this.btnReprovar.Click += new System.EventHandler(this.btnReprovar_Click);
            // 
            // btnBaixar
            // 
            this.btnBaixar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBaixar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(135)))), ((int)(((byte)(5)))));
            this.btnBaixar.FlatAppearance.BorderSize = 0;
            this.btnBaixar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaixar.ForeColor = System.Drawing.Color.White;
            this.btnBaixar.Location = new System.Drawing.Point(12, 446);
            this.btnBaixar.Name = "btnBaixar";
            this.btnBaixar.Size = new System.Drawing.Size(169, 34);
            this.btnBaixar.TabIndex = 71;
            this.btnBaixar.Text = "Baixar arquivo";
            this.btnBaixar.UseVisualStyleBackColor = false;
            this.btnBaixar.Click += new System.EventHandler(this.btnBaixar_Click);
            // 
            // FrmVisualizarNotaFiscal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(848, 489);
            this.Controls.Add(this.btnBaixar);
            this.Controls.Add(this.btnReprovar);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.pdfReader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVisualizarNotaFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Nota Fiscal";
            this.Load += new System.EventHandler(this.FrmVisualizarNotaFiscal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pdfReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF pdfReader;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Button btnReprovar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnBaixar;
    }
}