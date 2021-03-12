namespace OlimpiadaCompras.Telas.Avaliador
{
    partial class FrmAreaAvaliador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAreaAvaliador));
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltroPendentes = new System.Windows.Forms.TextBox();
            this.lblNomeUsuarioLogado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFiltroMinhas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVisualizaTodas = new System.Windows.Forms.Button();
            this.btnNovaSolicitacao = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.linkSair = new System.Windows.Forms.LinkLabel();
            this.dgvMinhasSolicitacoes = new System.Windows.Forms.DataGridView();
            this.colMinhaIdSolicitacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaJustificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvSolicitacoesPendentes = new System.Windows.Forms.DataGridView();
            this.colPendenteIdSolicitacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendenteData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendenteJustificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendenteStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendenteStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinhasSolicitacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoesPendentes)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(612, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filtrar";
            // 
            // txtFiltroPendentes
            // 
            this.txtFiltroPendentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroPendentes.Location = new System.Drawing.Point(673, 108);
            this.txtFiltroPendentes.Name = "txtFiltroPendentes";
            this.txtFiltroPendentes.Size = new System.Drawing.Size(240, 26);
            this.txtFiltroPendentes.TabIndex = 9;
            // 
            // lblNomeUsuarioLogado
            // 
            this.lblNomeUsuarioLogado.AutoSize = true;
            this.lblNomeUsuarioLogado.Location = new System.Drawing.Point(259, 9);
            this.lblNomeUsuarioLogado.Name = "lblNomeUsuarioLogado";
            this.lblNomeUsuarioLogado.Size = new System.Drawing.Size(135, 20);
            this.lblNomeUsuarioLogado.TabIndex = 8;
            this.lblNomeUsuarioLogado.Text = "Olá, Daniel Carlos";
            this.lblNomeUsuarioLogado.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista de solicitações pendentes";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(612, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Filtrar";
            // 
            // txtFiltroMinhas
            // 
            this.txtFiltroMinhas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroMinhas.Location = new System.Drawing.Point(673, 355);
            this.txtFiltroMinhas.Name = "txtFiltroMinhas";
            this.txtFiltroMinhas.Size = new System.Drawing.Size(240, 26);
            this.txtFiltroMinhas.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Lista com as minhas solicitações";
            // 
            // btnVisualizaTodas
            // 
            this.btnVisualizaTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVisualizaTodas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(138)))), ((int)(((byte)(191)))));
            this.btnVisualizaTodas.FlatAppearance.BorderSize = 0;
            this.btnVisualizaTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizaTodas.ForeColor = System.Drawing.Color.White;
            this.btnVisualizaTodas.Location = new System.Drawing.Point(12, 593);
            this.btnVisualizaTodas.Name = "btnVisualizaTodas";
            this.btnVisualizaTodas.Size = new System.Drawing.Size(209, 33);
            this.btnVisualizaTodas.TabIndex = 16;
            this.btnVisualizaTodas.Text = "Todas as solicitações";
            this.btnVisualizaTodas.UseVisualStyleBackColor = false;
            this.btnVisualizaTodas.Click += new System.EventHandler(this.btnVisualizaTodas_Click);
            // 
            // btnNovaSolicitacao
            // 
            this.btnNovaSolicitacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNovaSolicitacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnNovaSolicitacao.FlatAppearance.BorderSize = 0;
            this.btnNovaSolicitacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaSolicitacao.ForeColor = System.Drawing.Color.White;
            this.btnNovaSolicitacao.Location = new System.Drawing.Point(744, 593);
            this.btnNovaSolicitacao.Name = "btnNovaSolicitacao";
            this.btnNovaSolicitacao.Size = new System.Drawing.Size(169, 34);
            this.btnNovaSolicitacao.TabIndex = 17;
            this.btnNovaSolicitacao.Text = "Nova solicitação";
            this.btnNovaSolicitacao.UseVisualStyleBackColor = false;
            this.btnNovaSolicitacao.Click += new System.EventHandler(this.btnNovaSolicitacao_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(135)))), ((int)(((byte)(5)))));
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(569, 593);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(169, 34);
            this.btnEditar.TabIndex = 20;
            this.btnEditar.Text = "Editar solicitação";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // linkSair
            // 
            this.linkSair.AutoSize = true;
            this.linkSair.Location = new System.Drawing.Point(879, 9);
            this.linkSair.Name = "linkSair";
            this.linkSair.Size = new System.Drawing.Size(37, 20);
            this.linkSair.TabIndex = 21;
            this.linkSair.TabStop = true;
            this.linkSair.Text = "Sair";
            this.linkSair.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSair_LinkClicked);
            // 
            // dgvMinhasSolicitacoes
            // 
            this.dgvMinhasSolicitacoes.AllowUserToAddRows = false;
            this.dgvMinhasSolicitacoes.AllowUserToDeleteRows = false;
            this.dgvMinhasSolicitacoes.AllowUserToOrderColumns = true;
            this.dgvMinhasSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMinhasSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMinhasSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMinhasSolicitacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMinhaIdSolicitacao,
            this.colMinhaData,
            this.colMinhaJustificativa,
            this.colMinhaStatus,
            this.colMinhaStatusID});
            this.dgvMinhasSolicitacoes.Location = new System.Drawing.Point(12, 390);
            this.dgvMinhasSolicitacoes.Name = "dgvMinhasSolicitacoes";
            this.dgvMinhasSolicitacoes.ReadOnly = true;
            this.dgvMinhasSolicitacoes.Size = new System.Drawing.Size(901, 197);
            this.dgvMinhasSolicitacoes.TabIndex = 23;
            this.dgvMinhasSolicitacoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMinhasSolicitacoes_CellClick);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OlimpiadaCompras.Properties.Resources.Brasão_Dourado;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // dgvSolicitacoesPendentes
            // 
            this.dgvSolicitacoesPendentes.AllowUserToAddRows = false;
            this.dgvSolicitacoesPendentes.AllowUserToDeleteRows = false;
            this.dgvSolicitacoesPendentes.AllowUserToOrderColumns = true;
            this.dgvSolicitacoesPendentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSolicitacoesPendentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitacoesPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitacoesPendentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPendenteIdSolicitacao,
            this.colPendenteData,
            this.colPendenteJustificativa,
            this.colPendenteStatus,
            this.colPendenteStatusID});
            this.dgvSolicitacoesPendentes.Location = new System.Drawing.Point(12, 143);
            this.dgvSolicitacoesPendentes.Name = "dgvSolicitacoesPendentes";
            this.dgvSolicitacoesPendentes.ReadOnly = true;
            this.dgvSolicitacoesPendentes.Size = new System.Drawing.Size(901, 197);
            this.dgvSolicitacoesPendentes.TabIndex = 25;
            this.dgvSolicitacoesPendentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitacoesPendentes_CellClick);
            this.dgvSolicitacoesPendentes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitacoesPendentes_CellDoubleClick);
            // 
            // colPendenteIdSolicitacao
            // 
            this.colPendenteIdSolicitacao.HeaderText = "Codigo da solicitação";
            this.colPendenteIdSolicitacao.Name = "colPendenteIdSolicitacao";
            this.colPendenteIdSolicitacao.ReadOnly = true;
            // 
            // colPendenteData
            // 
            this.colPendenteData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPendenteData.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPendenteData.HeaderText = "Data da solicitação";
            this.colPendenteData.Name = "colPendenteData";
            this.colPendenteData.ReadOnly = true;
            // 
            // colPendenteJustificativa
            // 
            this.colPendenteJustificativa.HeaderText = "Justificativa";
            this.colPendenteJustificativa.Name = "colPendenteJustificativa";
            this.colPendenteJustificativa.ReadOnly = true;
            // 
            // colPendenteStatus
            // 
            this.colPendenteStatus.HeaderText = "Status";
            this.colPendenteStatus.Name = "colPendenteStatus";
            this.colPendenteStatus.ReadOnly = true;
            // 
            // colPendenteStatusID
            // 
            this.colPendenteStatusID.HeaderText = "statusId";
            this.colPendenteStatusID.Name = "colPendenteStatusID";
            this.colPendenteStatusID.ReadOnly = true;
            this.colPendenteStatusID.Visible = false;
            // 
            // FrmAreaAvaliador
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 646);
            this.Controls.Add(this.dgvSolicitacoesPendentes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvMinhasSolicitacoes);
            this.Controls.Add(this.linkSair);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovaSolicitacao);
            this.Controls.Add(this.btnVisualizaTodas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFiltroMinhas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFiltroPendentes);
            this.Controls.Add(this.lblNomeUsuarioLogado);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAreaAvaliador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área do Avaliador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAreaAvaliador_FormClosed);
            this.Load += new System.EventHandler(this.FrmAreaAvaliador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinhasSolicitacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoesPendentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltroPendentes;
        private System.Windows.Forms.Label lblNomeUsuarioLogado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFiltroMinhas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVisualizaTodas;
        private System.Windows.Forms.Button btnNovaSolicitacao;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.LinkLabel linkSair;
        private System.Windows.Forms.DataGridView dgvMinhasSolicitacoes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvSolicitacoesPendentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenteIdSolicitacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenteData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenteJustificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenteStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenteStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaIdSolicitacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaJustificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaStatusID;
    }
}