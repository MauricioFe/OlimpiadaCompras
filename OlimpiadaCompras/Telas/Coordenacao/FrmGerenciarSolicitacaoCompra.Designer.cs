namespace OlimpiadaCompras.Telas.Coordenacao
{
    partial class FrmGerenciarSolicitacaoCompra
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
            this.btnSolicitarAlteracao = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnReprvar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtIdOrcamento3 = new System.Windows.Forms.TextBox();
            this.btnProximo3 = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.txtValorFrete3 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboFormaPagamento3 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDataOrcamento3 = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.btnSelecionar3 = new System.Windows.Forms.Button();
            this.txtAnexarPdf3 = new System.Windows.Forms.TextBox();
            this.txtValorFinal3 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtTotalIpi3 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtTotalProdutos3 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCnpj3 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtFornecedor3 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvProdutoCompra3 = new System.Windows.Forms.DataGridView();
            this.colCodProtheus3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitario3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesconto3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIpi3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colICMS3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colProdutoSolicitacaoId3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdutoPedidoOrcamentoId3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoCompra3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSolicitarAlteracao
            // 
            this.btnSolicitarAlteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSolicitarAlteracao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(138)))), ((int)(((byte)(191)))));
            this.btnSolicitarAlteracao.FlatAppearance.BorderSize = 0;
            this.btnSolicitarAlteracao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitarAlteracao.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarAlteracao.Location = new System.Drawing.Point(185, 558);
            this.btnSolicitarAlteracao.Name = "btnSolicitarAlteracao";
            this.btnSolicitarAlteracao.Size = new System.Drawing.Size(169, 34);
            this.btnSolicitarAlteracao.TabIndex = 37;
            this.btnSolicitarAlteracao.Text = "Solicitar alteração";
            this.btnSolicitarAlteracao.UseVisualStyleBackColor = false;
            this.btnSolicitarAlteracao.Click += new System.EventHandler(this.btnSolicitarAlteracao_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(135)))), ((int)(((byte)(5)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(10, 558);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(169, 34);
            this.btnEditar.TabIndex = 36;
            this.btnEditar.Text = "Editar pedido";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAprovar
            // 
            this.btnAprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnAprovar.FlatAppearance.BorderSize = 0;
            this.btnAprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprovar.ForeColor = System.Drawing.Color.White;
            this.btnAprovar.Location = new System.Drawing.Point(734, 559);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(169, 34);
            this.btnAprovar.TabIndex = 35;
            this.btnAprovar.Text = "Aprovar pedido";
            this.btnAprovar.UseVisualStyleBackColor = false;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // btnReprvar
            // 
            this.btnReprvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(17)))), ((int)(((byte)(54)))));
            this.btnReprvar.FlatAppearance.BorderSize = 0;
            this.btnReprvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprvar.ForeColor = System.Drawing.Color.White;
            this.btnReprvar.Location = new System.Drawing.Point(909, 559);
            this.btnReprvar.Name = "btnReprvar";
            this.btnReprvar.Size = new System.Drawing.Size(169, 34);
            this.btnReprvar.TabIndex = 34;
            this.btnReprvar.Text = "Reprovar pedido";
            this.btnReprvar.UseVisualStyleBackColor = false;
            this.btnReprvar.Click += new System.EventHandler(this.btnReprvar_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 100);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            // 
            // txtIdOrcamento3
            // 
            this.txtIdOrcamento3.Location = new System.Drawing.Point(0, 0);
            this.txtIdOrcamento3.Name = "txtIdOrcamento3";
            this.txtIdOrcamento3.Size = new System.Drawing.Size(100, 20);
            this.txtIdOrcamento3.TabIndex = 0;
            // 
            // btnProximo3
            // 
            this.btnProximo3.Location = new System.Drawing.Point(0, 0);
            this.btnProximo3.Name = "btnProximo3";
            this.btnProximo3.Size = new System.Drawing.Size(75, 23);
            this.btnProximo3.TabIndex = 0;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(0, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(100, 23);
            this.label40.TabIndex = 0;
            // 
            // txtValorFrete3
            // 
            this.txtValorFrete3.Location = new System.Drawing.Point(0, 0);
            this.txtValorFrete3.Name = "txtValorFrete3";
            this.txtValorFrete3.Size = new System.Drawing.Size(100, 20);
            this.txtValorFrete3.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 23);
            this.label28.TabIndex = 0;
            // 
            // cboFormaPagamento3
            // 
            this.cboFormaPagamento3.Location = new System.Drawing.Point(0, 0);
            this.cboFormaPagamento3.Name = "cboFormaPagamento3";
            this.cboFormaPagamento3.Size = new System.Drawing.Size(121, 21);
            this.cboFormaPagamento3.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(360, 83);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(162, 20);
            this.label29.TabIndex = 59;
            this.label29.Text = "Forma de pagamento";
            // 
            // dtpDataOrcamento3
            // 
            this.dtpDataOrcamento3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataOrcamento3.Location = new System.Drawing.Point(174, 105);
            this.dtpDataOrcamento3.Name = "dtpDataOrcamento3";
            this.dtpDataOrcamento3.Size = new System.Drawing.Size(180, 20);
            this.dtpDataOrcamento3.TabIndex = 58;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(170, 83);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(146, 20);
            this.label30.TabIndex = 57;
            this.label30.Text = "Data do orçamento";
            // 
            // btnSelecionar3
            // 
            this.btnSelecionar3.Location = new System.Drawing.Point(921, 104);
            this.btnSelecionar3.Name = "btnSelecionar3";
            this.btnSelecionar3.Size = new System.Drawing.Size(125, 29);
            this.btnSelecionar3.TabIndex = 56;
            this.btnSelecionar3.Text = "Selecionar";
            this.btnSelecionar3.UseVisualStyleBackColor = true;
            this.btnSelecionar3.Click += new System.EventHandler(this.btnSelecionar3_Click);
            // 
            // txtAnexarPdf3
            // 
            this.txtAnexarPdf3.Enabled = false;
            this.txtAnexarPdf3.Location = new System.Drawing.Point(636, 105);
            this.txtAnexarPdf3.Name = "txtAnexarPdf3";
            this.txtAnexarPdf3.Size = new System.Drawing.Size(279, 20);
            this.txtAnexarPdf3.TabIndex = 55;
            // 
            // txtValorFinal3
            // 
            this.txtValorFinal3.Enabled = false;
            this.txtValorFinal3.Location = new System.Drawing.Point(6, 105);
            this.txtValorFinal3.Name = "txtValorFinal3";
            this.txtValorFinal3.Size = new System.Drawing.Size(162, 20);
            this.txtValorFinal3.TabIndex = 53;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(2, 85);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 20);
            this.label31.TabIndex = 54;
            this.label31.Text = "Valor Final";
            // 
            // txtTotalIpi3
            // 
            this.txtTotalIpi3.Enabled = false;
            this.txtTotalIpi3.Location = new System.Drawing.Point(738, 53);
            this.txtTotalIpi3.Name = "txtTotalIpi3";
            this.txtTotalIpi3.Size = new System.Drawing.Size(125, 20);
            this.txtTotalIpi3.TabIndex = 51;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(734, 28);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(68, 20);
            this.label32.TabIndex = 52;
            this.label32.Text = "Total IPI";
            // 
            // txtTotalProdutos3
            // 
            this.txtTotalProdutos3.Enabled = false;
            this.txtTotalProdutos3.Location = new System.Drawing.Point(611, 53);
            this.txtTotalProdutos3.Name = "txtTotalProdutos3";
            this.txtTotalProdutos3.Size = new System.Drawing.Size(122, 20);
            this.txtTotalProdutos3.TabIndex = 49;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(607, 28);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(112, 20);
            this.label33.TabIndex = 50;
            this.label33.Text = "Total Produtos";
            // 
            // txtCnpj3
            // 
            this.txtCnpj3.Location = new System.Drawing.Point(394, 53);
            this.txtCnpj3.Name = "txtCnpj3";
            this.txtCnpj3.Size = new System.Drawing.Size(211, 20);
            this.txtCnpj3.TabIndex = 47;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(390, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 20);
            this.label34.TabIndex = 48;
            this.label34.Text = "Cnpj";
            // 
            // txtFornecedor3
            // 
            this.txtFornecedor3.Location = new System.Drawing.Point(6, 53);
            this.txtFornecedor3.Name = "txtFornecedor3";
            this.txtFornecedor3.Size = new System.Drawing.Size(382, 20);
            this.txtFornecedor3.TabIndex = 45;
            this.txtFornecedor3.Enter += new System.EventHandler(this.txtFornecedor3_Enter);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(2, 28);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(91, 20);
            this.label39.TabIndex = 46;
            this.label39.Text = "Fornecedor";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvProdutoCompra3);
            this.groupBox6.Location = new System.Drawing.Point(8, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1062, 279);
            this.groupBox6.TabIndex = 57;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Valores do produto";
            // 
            // dgvProdutoCompra3
            // 
            this.dgvProdutoCompra3.AllowUserToAddRows = false;
            this.dgvProdutoCompra3.AllowUserToDeleteRows = false;
            this.dgvProdutoCompra3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutoCompra3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutoCompra3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoCompra3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodProtheus3,
            this.colGrupo3,
            this.colDescricao3,
            this.colQuantidade3,
            this.colUnitario3,
            this.colDesconto3,
            this.colIpi3,
            this.colICMS3,
            this.colTotal3,
            this.dataGridViewLinkColumn2,
            this.colProdutoSolicitacaoId3,
            this.colProdutoPedidoOrcamentoId3});
            this.dgvProdutoCompra3.Location = new System.Drawing.Point(11, 23);
            this.dgvProdutoCompra3.Name = "dgvProdutoCompra3";
            this.dgvProdutoCompra3.Size = new System.Drawing.Size(1040, 233);
            this.dgvProdutoCompra3.TabIndex = 44;
            this.dgvProdutoCompra3.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutoCompra3_CellEndEdit);
            this.dgvProdutoCompra3.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutoCompra3_RowLeave);
            // 
            // colCodProtheus3
            // 
            this.colCodProtheus3.HeaderText = "Código do protheus";
            this.colCodProtheus3.Name = "colCodProtheus3";
            this.colCodProtheus3.ReadOnly = true;
            // 
            // colGrupo3
            // 
            this.colGrupo3.HeaderText = "Grupo";
            this.colGrupo3.Name = "colGrupo3";
            this.colGrupo3.ReadOnly = true;
            // 
            // colDescricao3
            // 
            this.colDescricao3.HeaderText = "Descrição";
            this.colDescricao3.Name = "colDescricao3";
            this.colDescricao3.ReadOnly = true;
            // 
            // colQuantidade3
            // 
            this.colQuantidade3.HeaderText = "Quantidade";
            this.colQuantidade3.Name = "colQuantidade3";
            // 
            // colUnitario3
            // 
            this.colUnitario3.HeaderText = "Valor Unitário";
            this.colUnitario3.Name = "colUnitario3";
            // 
            // colDesconto3
            // 
            this.colDesconto3.HeaderText = "Desconto";
            this.colDesconto3.Name = "colDesconto3";
            // 
            // colIpi3
            // 
            this.colIpi3.HeaderText = "IPI";
            this.colIpi3.Name = "colIpi3";
            // 
            // colICMS3
            // 
            this.colICMS3.HeaderText = "ICMS";
            this.colICMS3.Name = "colICMS3";
            // 
            // colTotal3
            // 
            this.colTotal3.HeaderText = "Total";
            this.colTotal3.Name = "colTotal3";
            this.colTotal3.ReadOnly = true;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.HeaderText = "Remover";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Visible = false;
            // 
            // colProdutoSolicitacaoId3
            // 
            this.colProdutoSolicitacaoId3.HeaderText = "produtoId";
            this.colProdutoSolicitacaoId3.Name = "colProdutoSolicitacaoId3";
            this.colProdutoSolicitacaoId3.Visible = false;
            // 
            // colProdutoPedidoOrcamentoId3
            // 
            this.colProdutoPedidoOrcamentoId3.HeaderText = "ProdutoPedidoOrcamentoId";
            this.colProdutoPedidoOrcamentoId3.Name = "colProdutoPedidoOrcamentoId3";
            this.colProdutoPedidoOrcamentoId3.Visible = false;
            // 
            // FrmGerenciarSolicitacaoCompra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 600);
            this.Controls.Add(this.btnSolicitarAlteracao);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.btnReprvar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmGerenciarSolicitacaoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Solicitacao de Compra";
            this.Load += new System.EventHandler(this.FrmGerenciarSolicitacaoCompra_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoCompra3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSolicitarAlteracao;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Button btnReprvar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtIdOrcamento3;
        private System.Windows.Forms.Button btnProximo3;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtValorFrete3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboFormaPagamento3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtpDataOrcamento3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnSelecionar3;
        private System.Windows.Forms.TextBox txtAnexarPdf3;
        private System.Windows.Forms.TextBox txtValorFinal3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtTotalIpi3;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtTotalProdutos3;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtCnpj3;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtFornecedor3;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvProdutoCompra3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodProtheus3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupo3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantidade3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitario3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesconto3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIpi3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colICMS3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdutoSolicitacaoId3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdutoPedidoOrcamentoId3;
    }
}