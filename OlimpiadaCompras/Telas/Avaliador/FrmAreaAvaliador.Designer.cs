﻿namespace OlimpiadaCompras.Telas.Avaliador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVisualizaTodas = new System.Windows.Forms.Button();
            this.btnNovaSolicitacao = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.linkSair = new System.Windows.Forms.LinkLabel();
            this.dgvSolicitacoes = new System.Windows.Forms.DataGridView();
            this.codProtheus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocupacao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(673, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 29);
            this.textBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Olá, Daniel Carlos";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brasão do estado";
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
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(673, 355);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(240, 29);
            this.textBox2.TabIndex = 14;
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
            // dgvSolicitacoes
            // 
            this.dgvSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codProtheus,
            this.Descricao,
            this.TipoCompra,
            this.ocupacao,
            this.Status});
            this.dgvSolicitacoes.Location = new System.Drawing.Point(12, 143);
            this.dgvSolicitacoes.Name = "dgvSolicitacoes";
            this.dgvSolicitacoes.Size = new System.Drawing.Size(901, 206);
            this.dgvSolicitacoes.TabIndex = 22;
            // 
            // codProtheus
            // 
            this.codProtheus.HeaderText = "Codigo da solicitação";
            this.codProtheus.Name = "codProtheus";
            this.codProtheus.Width = 150;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descricao.HeaderText = "Data da solicitação";
            this.Descricao.Name = "Descricao";
            // 
            // TipoCompra
            // 
            this.TipoCompra.HeaderText = "Usuário solicitante";
            this.TipoCompra.Name = "TipoCompra";
            // 
            // ocupacao
            // 
            this.ocupacao.HeaderText = "Ocupação";
            this.ocupacao.Name = "ocupacao";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(901, 197);
            this.dataGridView1.TabIndex = 23;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo da solicitação";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Data da solicitação";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Usuário solicitante";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Ocupação";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvSolicitacoes);
            this.Controls.Add(this.linkSair);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNovaSolicitacao);
            this.Controls.Add(this.btnVisualizaTodas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAreaAvaliador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área do Avaliador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAreaAvaliador_FormClosed);
            this.Load += new System.EventHandler(this.FrmAreaAvaliador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnVisualizaTodas;
        private System.Windows.Forms.Button btnNovaSolicitacao;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.LinkLabel linkSair;
        private System.Windows.Forms.DataGridView dgvSolicitacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProtheus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCompra;
        private System.Windows.Forms.DataGridViewComboBoxColumn ocupacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}