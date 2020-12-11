namespace OlimpiadaCompras
{
    partial class FrmAreaCoordenacao
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlCadastros = new System.Windows.Forms.Panel();
            this.btnCadastroOcupacoes = new System.Windows.Forms.Button();
            this.btnCadastroGrupos = new System.Windows.Forms.Button();
            this.btnCadastroTipoCompra = new System.Windows.Forms.Button();
            this.btnCadastroUsuarios = new System.Windows.Forms.Button();
            this.btnCadastroEscolas = new System.Windows.Forms.Button();
            this.btnCadastroProdutos = new System.Windows.Forms.Button();
            this.btnCadastros = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.dgvSolicitacoes = new System.Windows.Forms.DataGridView();
            this.codProtheus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocupacao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkSair = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
            this.pnlCadastros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.pnlCadastros);
            this.pnlMenu.Controls.Add(this.btnCadastros);
            this.pnlMenu.Controls.Add(this.btnRelatorios);
            this.pnlMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(301, 605);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlCadastros
            // 
            this.pnlCadastros.Controls.Add(this.btnCadastroOcupacoes);
            this.pnlCadastros.Controls.Add(this.btnCadastroGrupos);
            this.pnlCadastros.Controls.Add(this.btnCadastroTipoCompra);
            this.pnlCadastros.Controls.Add(this.btnCadastroUsuarios);
            this.pnlCadastros.Controls.Add(this.btnCadastroEscolas);
            this.pnlCadastros.Controls.Add(this.btnCadastroProdutos);
            this.pnlCadastros.Location = new System.Drawing.Point(58, 211);
            this.pnlCadastros.Name = "pnlCadastros";
            this.pnlCadastros.Size = new System.Drawing.Size(243, 220);
            this.pnlCadastros.TabIndex = 8;
            this.pnlCadastros.Visible = false;
            // 
            // btnCadastroOcupacoes
            // 
            this.btnCadastroOcupacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroOcupacoes.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroOcupacoes.Location = new System.Drawing.Point(0, 37);
            this.btnCadastroOcupacoes.Name = "btnCadastroOcupacoes";
            this.btnCadastroOcupacoes.Size = new System.Drawing.Size(243, 37);
            this.btnCadastroOcupacoes.TabIndex = 10;
            this.btnCadastroOcupacoes.Text = "Cadastro de Ocupações";
            this.btnCadastroOcupacoes.UseVisualStyleBackColor = true;
            this.btnCadastroOcupacoes.Click += new System.EventHandler(this.btnCadastroOcupacoes_Click);
            // 
            // btnCadastroGrupos
            // 
            this.btnCadastroGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroGrupos.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroGrupos.Location = new System.Drawing.Point(0, 73);
            this.btnCadastroGrupos.Name = "btnCadastroGrupos";
            this.btnCadastroGrupos.Size = new System.Drawing.Size(243, 37);
            this.btnCadastroGrupos.TabIndex = 9;
            this.btnCadastroGrupos.Text = "Cadastro de Grupos";
            this.btnCadastroGrupos.UseVisualStyleBackColor = true;
            this.btnCadastroGrupos.Click += new System.EventHandler(this.btnCadastroGrupos_Click);
            // 
            // btnCadastroTipoCompra
            // 
            this.btnCadastroTipoCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroTipoCompra.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroTipoCompra.Location = new System.Drawing.Point(0, 109);
            this.btnCadastroTipoCompra.Name = "btnCadastroTipoCompra";
            this.btnCadastroTipoCompra.Size = new System.Drawing.Size(243, 37);
            this.btnCadastroTipoCompra.TabIndex = 8;
            this.btnCadastroTipoCompra.Text = "Cadastro de Tipo de compra";
            this.btnCadastroTipoCompra.UseVisualStyleBackColor = true;
            this.btnCadastroTipoCompra.Click += new System.EventHandler(this.btnCadastroTipoCompra_Click);
            // 
            // btnCadastroUsuarios
            // 
            this.btnCadastroUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroUsuarios.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroUsuarios.Location = new System.Drawing.Point(0, 145);
            this.btnCadastroUsuarios.Name = "btnCadastroUsuarios";
            this.btnCadastroUsuarios.Size = new System.Drawing.Size(243, 37);
            this.btnCadastroUsuarios.TabIndex = 7;
            this.btnCadastroUsuarios.Text = "Cadastro de usuários";
            this.btnCadastroUsuarios.UseVisualStyleBackColor = true;
            this.btnCadastroUsuarios.Click += new System.EventHandler(this.btnCadastroUsuarios_Click);
            // 
            // btnCadastroEscolas
            // 
            this.btnCadastroEscolas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroEscolas.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroEscolas.Location = new System.Drawing.Point(0, 181);
            this.btnCadastroEscolas.Name = "btnCadastroEscolas";
            this.btnCadastroEscolas.Size = new System.Drawing.Size(243, 37);
            this.btnCadastroEscolas.TabIndex = 6;
            this.btnCadastroEscolas.Text = "Cadastro de Escolas";
            this.btnCadastroEscolas.UseVisualStyleBackColor = true;
            this.btnCadastroEscolas.Click += new System.EventHandler(this.btnCadastroEscolas_Click);
            // 
            // btnCadastroProdutos
            // 
            this.btnCadastroProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastroProdutos.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroProdutos.Location = new System.Drawing.Point(0, 1);
            this.btnCadastroProdutos.Name = "btnCadastroProdutos";
            this.btnCadastroProdutos.Size = new System.Drawing.Size(243, 37);
            this.btnCadastroProdutos.TabIndex = 5;
            this.btnCadastroProdutos.Text = "Cadastro de Produtos";
            this.btnCadastroProdutos.UseVisualStyleBackColor = true;
            this.btnCadastroProdutos.Click += new System.EventHandler(this.btnCadastroProdutos_Click);
            // 
            // btnCadastros
            // 
            this.btnCadastros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastros.Location = new System.Drawing.Point(0, 151);
            this.btnCadastros.Name = "btnCadastros";
            this.btnCadastros.Size = new System.Drawing.Size(301, 62);
            this.btnCadastros.TabIndex = 7;
            this.btnCadastros.Text = "Cadastros";
            this.btnCadastros.UseVisualStyleBackColor = true;
            this.btnCadastros.Click += new System.EventHandler(this.btnCadastros_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorios.Location = new System.Drawing.Point(0, 90);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(301, 62);
            this.btnRelatorios.TabIndex = 6;
            this.btnRelatorios.Text = "Relatórios";
            this.btnRelatorios.UseVisualStyleBackColor = true;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
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
            this.dgvSolicitacoes.Location = new System.Drawing.Point(310, 92);
            this.dgvSolicitacoes.Name = "dgvSolicitacoes";
            this.dgvSolicitacoes.Size = new System.Drawing.Size(723, 516);
            this.dgvSolicitacoes.TabIndex = 1;
            this.dgvSolicitacoes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitacoes_CellClick);
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle1;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lista de solicitações";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Olá Ariele";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(803, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 29);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(742, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Filtrar";
            // 
            // linkSair
            // 
            this.linkSair.AutoSize = true;
            this.linkSair.Location = new System.Drawing.Point(986, 9);
            this.linkSair.Name = "linkSair";
            this.linkSair.Size = new System.Drawing.Size(39, 22);
            this.linkSair.TabIndex = 6;
            this.linkSair.TabStop = true;
            this.linkSair.Text = "Sair";
            this.linkSair.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSair_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OlimpiadaCompras.Properties.Resources.Brasão_Dourado;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAreaCoordenacao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1037, 608);
            this.Controls.Add(this.linkSair);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSolicitacoes);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAreaCoordenacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área da coordenação";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAreaCoordenacao_FormClosed);
            this.Load += new System.EventHandler(this.FrmAreaCoordenacao_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlCadastros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlCadastros;
        private System.Windows.Forms.Button btnCadastroOcupacoes;
        private System.Windows.Forms.Button btnCadastroGrupos;
        private System.Windows.Forms.Button btnCadastroTipoCompra;
        private System.Windows.Forms.Button btnCadastroUsuarios;
        private System.Windows.Forms.Button btnCadastroEscolas;
        private System.Windows.Forms.Button btnCadastroProdutos;
        private System.Windows.Forms.Button btnCadastros;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.DataGridView dgvSolicitacoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkSair;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProtheus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCompra;
        private System.Windows.Forms.DataGridViewComboBoxColumn ocupacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}