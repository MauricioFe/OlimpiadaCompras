namespace OlimpiadaCompras.Telas.Avaliador
{
    partial class FrmTodasSolicitacoes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTodasSolicitacoes));
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSolicitacoes = new System.Windows.Forms.DataGridView();
            this.colMinhaIdSolicitacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaJustificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(562, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Filtrar";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(623, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 26);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista de solicitações";
            // 
            // dgvSolicitacoes
            // 
            this.dgvSolicitacoes.AllowUserToAddRows = false;
            this.dgvSolicitacoes.AllowUserToDeleteRows = false;
            this.dgvSolicitacoes.AllowUserToOrderColumns = true;
            this.dgvSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMinhaIdSolicitacao,
            this.colMinhaData,
            this.colMinhaJustificativa,
            this.colMinhaStatus,
            this.colMinhaStatusID});
            this.dgvSolicitacoes.Location = new System.Drawing.Point(16, 51);
            this.dgvSolicitacoes.Name = "dgvSolicitacoes";
            this.dgvSolicitacoes.ReadOnly = true;
            this.dgvSolicitacoes.Size = new System.Drawing.Size(922, 405);
            this.dgvSolicitacoes.TabIndex = 24;
            // 
            // colMinhaIdSolicitacao
            // 
            this.colMinhaIdSolicitacao.HeaderText = "Codigo da solicitação";
            this.colMinhaIdSolicitacao.Name = "colMinhaIdSolicitacao";
            this.colMinhaIdSolicitacao.ReadOnly = true;
            // 
            // colMinhaData
            // 
            this.colMinhaData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colMinhaData.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMinhaData.HeaderText = "Data da solicitação";
            this.colMinhaData.Name = "colMinhaData";
            this.colMinhaData.ReadOnly = true;
            // 
            // colMinhaJustificativa
            // 
            this.colMinhaJustificativa.HeaderText = "Justificativa";
            this.colMinhaJustificativa.Name = "colMinhaJustificativa";
            this.colMinhaJustificativa.ReadOnly = true;
            // 
            // colMinhaStatus
            // 
            this.colMinhaStatus.HeaderText = "Status";
            this.colMinhaStatus.Name = "colMinhaStatus";
            this.colMinhaStatus.ReadOnly = true;
            // 
            // colMinhaStatusID
            // 
            this.colMinhaStatusID.HeaderText = "statusID";
            this.colMinhaStatusID.Name = "colMinhaStatusID";
            this.colMinhaStatusID.ReadOnly = true;
            this.colMinhaStatusID.Visible = false;
            // 
            // FrmTodasSolicitacoes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 468);
            this.Controls.Add(this.dgvSolicitacoes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTodasSolicitacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Todas as solicitacoes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSolicitacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaIdSolicitacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaJustificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaStatusID;
    }
}