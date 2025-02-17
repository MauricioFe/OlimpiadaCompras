﻿namespace OlimpiadaCompras.Telas.Coordenacao.Cadastros
{
    partial class FrmCadastroEscolas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroEscolas));
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeResponsavel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dgvResponsavel = new System.Windows.Forms.DataGridView();
            this.colResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmailResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colIdResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEscolas = new System.Windows.Forms.DataGridView();
            this.colNomeEscola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEscola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNomeEscola = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponsavel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscolas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(17)))), ((int)(((byte)(54)))));
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(744, 631);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(142, 40);
            this.btnExcluir.TabIndex = 35;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(744, 406);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(142, 40);
            this.btnSalvar.TabIndex = 37;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCargo);
            this.groupBox1.Controls.Add(this.btnAdicionar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNomeResponsavel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.dgvResponsavel);
            this.groupBox1.Location = new System.Drawing.Point(17, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 261);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados dos responsáveis";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(755, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 29);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Cargo";
            // 
            // txtCargo
            // 
            this.txtCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargo.Location = new System.Drawing.Point(552, 55);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(194, 26);
            this.txtCargo.TabIndex = 10;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(755, 55);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(108, 29);
            this.btnAdicionar.TabIndex = 11;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Responsável";
            // 
            // txtNomeResponsavel
            // 
            this.txtNomeResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeResponsavel.Location = new System.Drawing.Point(6, 55);
            this.txtNomeResponsavel.Name = "txtNomeResponsavel";
            this.txtNomeResponsavel.Size = new System.Drawing.Size(272, 26);
            this.txtNomeResponsavel.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(281, 55);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 26);
            this.txtEmail.TabIndex = 9;
            // 
            // dgvResponsavel
            // 
            this.dgvResponsavel.AllowUserToAddRows = false;
            this.dgvResponsavel.AllowUserToDeleteRows = false;
            this.dgvResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResponsavel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResponsavel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponsavel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResponsavel,
            this.colEmailResponsavel,
            this.colCargo,
            this.colRemove,
            this.colIdResponsavel});
            this.dgvResponsavel.Location = new System.Drawing.Point(6, 90);
            this.dgvResponsavel.Name = "dgvResponsavel";
            this.dgvResponsavel.Size = new System.Drawing.Size(857, 152);
            this.dgvResponsavel.TabIndex = 35;
            this.dgvResponsavel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResponsavel_CellClick);
            this.dgvResponsavel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResponsavel_CellContentClick);
            // 
            // colResponsavel
            // 
            this.colResponsavel.HeaderText = "Nome responsável";
            this.colResponsavel.Name = "colResponsavel";
            // 
            // colEmailResponsavel
            // 
            this.colEmailResponsavel.HeaderText = "Email";
            this.colEmailResponsavel.Name = "colEmailResponsavel";
            // 
            // colCargo
            // 
            this.colCargo.HeaderText = "Cargo";
            this.colCargo.Name = "colCargo";
            // 
            // colRemove
            // 
            this.colRemove.HeaderText = "Remover da lista";
            this.colRemove.Name = "colRemove";
            // 
            // colIdResponsavel
            // 
            this.colIdResponsavel.HeaderText = "id";
            this.colIdResponsavel.Name = "colIdResponsavel";
            this.colIdResponsavel.ReadOnly = true;
            this.colIdResponsavel.Visible = false;
            // 
            // dgvEscolas
            // 
            this.dgvEscolas.AllowUserToAddRows = false;
            this.dgvEscolas.AllowUserToDeleteRows = false;
            this.dgvEscolas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEscolas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEscolas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEscolas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomeEscola,
            this.colLogradouro,
            this.colBairro,
            this.colCep,
            this.colNumero,
            this.colCidade,
            this.colEstado,
            this.colIdEscola});
            this.dgvEscolas.Location = new System.Drawing.Point(14, 452);
            this.dgvEscolas.Name = "dgvEscolas";
            this.dgvEscolas.ReadOnly = true;
            this.dgvEscolas.Size = new System.Drawing.Size(872, 173);
            this.dgvEscolas.TabIndex = 51;
            this.dgvEscolas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEscolas_CellClick);
            // 
            // colNomeEscola
            // 
            this.colNomeEscola.HeaderText = "Nome da escola";
            this.colNomeEscola.Name = "colNomeEscola";
            this.colNomeEscola.ReadOnly = true;
            // 
            // colLogradouro
            // 
            this.colLogradouro.HeaderText = "Logradouro";
            this.colLogradouro.Name = "colLogradouro";
            this.colLogradouro.ReadOnly = true;
            // 
            // colBairro
            // 
            this.colBairro.HeaderText = "Bairro";
            this.colBairro.Name = "colBairro";
            this.colBairro.ReadOnly = true;
            // 
            // colCep
            // 
            this.colCep.HeaderText = "CEP";
            this.colCep.Name = "colCep";
            this.colCep.ReadOnly = true;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "Número";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            // 
            // colCidade
            // 
            this.colCidade.HeaderText = "Cidade";
            this.colCidade.Name = "colCidade";
            this.colCidade.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colIdEscola
            // 
            this.colIdEscola.HeaderText = "id";
            this.colIdEscola.Name = "colIdEscola";
            this.colIdEscola.ReadOnly = true;
            this.colIdEscola.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Filtro";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(68, 417);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(200, 26);
            this.txtFiltro.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "Bairro";
            // 
            // txtNomeEscola
            // 
            this.txtNomeEscola.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNomeEscola.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeEscola.Location = new System.Drawing.Point(17, 44);
            this.txtNomeEscola.Name = "txtNomeEscola";
            this.txtNomeEscola.Size = new System.Drawing.Size(418, 26);
            this.txtNomeEscola.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nome da escola";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(593, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Logradouro";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLogradouro.Location = new System.Drawing.Point(597, 44);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(286, 26);
            this.txtLogradouro.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Cep";
            // 
            // txtCep
            // 
            this.txtCep.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCep.Location = new System.Drawing.Point(441, 44);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(150, 26);
            this.txtCep.TabIndex = 2;
            // 
            // txtBairro
            // 
            this.txtBairro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBairro.Location = new System.Drawing.Point(17, 101);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(237, 26);
            this.txtBairro.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNumero.Location = new System.Drawing.Point(260, 101);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(149, 26);
            this.txtNumero.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(618, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 47;
            this.label11.Text = "Cidade";
            // 
            // cboEstado
            // 
            this.cboEstado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO",
            "DF"});
            this.cboEstado.Location = new System.Drawing.Point(416, 100);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(200, 28);
            this.cboEstado.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(412, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 53;
            this.label12.Text = "Estado";
            // 
            // txtCidade
            // 
            this.txtCidade.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCidade.Location = new System.Drawing.Point(622, 101);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(261, 26);
            this.txtCidade.TabIndex = 7;
            // 
            // FrmCadastroEscolas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 676);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.dgvEscolas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLogradouro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeEscola);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCadastroEscolas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Escolas";
            this.Load += new System.EventHandler(this.FrmCadastrarEscolas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponsavel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscolas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeResponsavel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DataGridView dgvResponsavel;
        private System.Windows.Forms.DataGridView dgvEscolas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeEscola;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEscola;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNomeEscola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmailResponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargo;
        private System.Windows.Forms.DataGridViewLinkColumn colRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdResponsavel;
        private System.Windows.Forms.Button btnCancelar;
    }
}