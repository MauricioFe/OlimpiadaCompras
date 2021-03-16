
namespace OlimpiadaCompras.Telas.Coordenacao
{
    partial class FrmPrecadastroEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecadastroEmail));
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodUnidadeOrganizacional = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCentroResponsabilidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContaContabil = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProjeto = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codigo da Unidade Organizacional";
            // 
            // txtCodUnidadeOrganizacional
            // 
            this.txtCodUnidadeOrganizacional.Location = new System.Drawing.Point(143, 51);
            this.txtCodUnidadeOrganizacional.Name = "txtCodUnidadeOrganizacional";
            this.txtCodUnidadeOrganizacional.Size = new System.Drawing.Size(279, 26);
            this.txtCodUnidadeOrganizacional.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Centro de Responsabilidade";
            // 
            // txtCentroResponsabilidade
            // 
            this.txtCentroResponsabilidade.Location = new System.Drawing.Point(463, 51);
            this.txtCentroResponsabilidade.Name = "txtCentroResponsabilidade";
            this.txtCentroResponsabilidade.Size = new System.Drawing.Size(279, 26);
            this.txtCentroResponsabilidade.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Conta Contábil";
            // 
            // txtContaContabil
            // 
            this.txtContaContabil.Location = new System.Drawing.Point(143, 129);
            this.txtContaContabil.Name = "txtContaContabil";
            this.txtContaContabil.Size = new System.Drawing.Size(279, 26);
            this.txtContaContabil.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Projeto";
            // 
            // txtProjeto
            // 
            this.txtProjeto.Location = new System.Drawing.Point(463, 129);
            this.txtProjeto.Name = "txtProjeto";
            this.txtProjeto.Size = new System.Drawing.Size(279, 26);
            this.txtProjeto.TabIndex = 8;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(138)))), ((int)(((byte)(191)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(463, 242);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(160, 39);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(17)))), ((int)(((byte)(54)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(297, 242);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 39);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmPrecadastroEmail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(906, 293);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProjeto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContaContabil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCentroResponsabilidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodUnidadeOrganizacional);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrecadastroEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pré cadastro do E-mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodUnidadeOrganizacional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCentroResponsabilidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContaContabil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProjeto;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}