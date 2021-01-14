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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colMinhaIdSolicitacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinhaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSolicitacoesPendentes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label4.Size = new System.Drawing.Size(55, 22);
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
            this.txtFiltroPendentes.Size = new System.Drawing.Size(240, 29);
            this.txtFiltroPendentes.TabIndex = 9;
            // 
            // lblNomeUsuarioLogado
            // 
            this.lblNomeUsuarioLogado.AutoSize = true;
            this.lblNomeUsuarioLogado.Location = new System.Drawing.Point(259, 9);
            this.lblNomeUsuarioLogado.Name = "lblNomeUsuarioLogado";
            this.lblNomeUsuarioLogado.Size = new System.Drawing.Size(143, 22);
            this.lblNomeUsuarioLogado.TabIndex = 8;
            this.lblNomeUsuarioLogado.Text = "Olá, Daniel Carlos";
            this.lblNomeUsuarioLogado.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 22);
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
            this.label5.Size = new System.Drawing.Size(55, 22);
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
            this.txtFiltroMinhas.Size = new System.Drawing.Size(240, 29);
            this.txtFiltroMinhas.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 22);
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
            this.btnNovaSolicitacao.Location = new System.Drawing.Point(744, 592);
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
            this.linkSair.Size = new System.Drawing.Size(39, 22);
            this.linkSair.TabIndex = 21;
            this.linkSair.TabStop = true;
            this.linkSair.Text = "Sair";
            this.linkSair.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSair_LinkClicked);
            // 
            // dgvMinhasSolicitacoes
            // 
            this.dgvMinhasSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMinhasSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMinhasSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMinhasSolicitacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMinhaIdSolicitacao,
            this.colMinhaData,
            this.colMinhaUsuario,
            this.colMinhaStatus});
            this.dgvMinhasSolicitacoes.Location = new System.Drawing.Point(12, 390);
            this.dgvMinhasSolicitacoes.Name = "dgvMinhasSolicitacoes";
            this.dgvMinhasSolicitacoes.Size = new System.Drawing.Size(901, 197);
            this.dgvMinhasSolicitacoes.TabIndex = 23;
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
            // colMinhaIdSolicitacao
            // 
            this.colMinhaIdSolicitacao.HeaderText = "Codigo da solicitação";
            this.colMinhaIdSolicitacao.Name = "colMinhaIdSolicitacao";
            // 
            // colMinhaData
            // 
            this.colMinhaData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colMinhaData.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMinhaData.HeaderText = "Data da solicitação";
            this.colMinhaData.Name = "colMinhaData";
            // 
            // colMinhaUsuario
            // 
            this.colMinhaUsuario.HeaderText = "Usuário solicitante";
            this.colMinhaUsuario.Name = "colMinhaUsuario";
            // 
            // colMinhaStatus
            // 
            this.colMinhaStatus.HeaderText = "Status";
            this.colMinhaStatus.Name = "colMinhaStatus";
            // 
            // dgvSolicitacoesPendentes
            // 
            this.dgvSolicitacoesPendentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSolicitacoesPendentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitacoesPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitacoesPendentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvSolicitacoesPendentes.Location = new System.Drawing.Point(12, 143);
            this.dgvSolicitacoesPendentes.Name = "dgvSolicitacoesPendentes";
            this.dgvSolicitacoesPendentes.Size = new System.Drawing.Size(901, 197);
            this.dgvSolicitacoesPendentes.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo da solicitação";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Data da solicitação";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Usuário solicitante";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Status";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
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
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaIdSolicitacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinhaStatus;
        private System.Windows.Forms.DataGridView dgvSolicitacoesPendentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}