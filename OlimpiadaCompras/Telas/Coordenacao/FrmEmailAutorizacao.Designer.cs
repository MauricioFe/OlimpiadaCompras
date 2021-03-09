
namespace OlimpiadaCompras.Telas.Coordenacao
{
    partial class FrmEmailAutorizacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmailAutorizacao));
            this.btnReprovar = new System.Windows.Forms.Button();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.pdfReader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.pdfReader)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReprovar
            // 
            this.btnReprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(17)))), ((int)(((byte)(54)))));
            this.btnReprovar.FlatAppearance.BorderSize = 0;
            this.btnReprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprovar.ForeColor = System.Drawing.Color.White;
            this.btnReprovar.Location = new System.Drawing.Point(494, 450);
            this.btnReprovar.Name = "btnReprovar";
            this.btnReprovar.Size = new System.Drawing.Size(169, 34);
            this.btnReprovar.TabIndex = 40;
            this.btnReprovar.Text = "Não enviar";
            this.btnReprovar.UseVisualStyleBackColor = false;
            this.btnReprovar.Click += new System.EventHandler(this.btnReprovar_Click);
            // 
            // btnAprovar
            // 
            this.btnAprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnAprovar.FlatAppearance.BorderSize = 0;
            this.btnAprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprovar.ForeColor = System.Drawing.Color.White;
            this.btnAprovar.Location = new System.Drawing.Point(669, 450);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(169, 34);
            this.btnAprovar.TabIndex = 39;
            this.btnAprovar.Text = "Enviar e-mail";
            this.btnAprovar.UseVisualStyleBackColor = false;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
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
            this.pdfReader.TabIndex = 38;
            // 
            // FrmEmailAutorizacao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(848, 489);
            this.Controls.Add(this.btnReprovar);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.pdfReader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmEmailAutorizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar e-mail de autorizacao";
            this.Load += new System.EventHandler(this.FrmEmailAutorizacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pdfReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReprovar;
        private System.Windows.Forms.Button btnAprovar;
        private AxAcroPDFLib.AxAcroPDF pdfReader;
    }
}