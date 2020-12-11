namespace OlimpiadaCompras.Telas.Coordenacao.Cadastros
{
    partial class FrmCadastroGrupos
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoProtheus = new System.Windows.Forms.TextBox();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.colCodigoProtheusGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAnexo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(135)))), ((int)(((byte)(5)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(447, 381);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(142, 40);
            this.btnEditar.TabIndex = 58;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(17)))), ((int)(((byte)(54)))));
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(595, 381);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(142, 40);
            this.btnExcluir.TabIndex = 57;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_ClickAsync);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(595, 153);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(142, 40);
            this.btnSalvar.TabIndex = 56;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 22);
            this.label1.TabIndex = 55;
            this.label1.Text = "Código Protheus";
            // 
            // txtCodigoProtheus
            // 
            this.txtCodigoProtheus.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProtheus.Location = new System.Drawing.Point(68, 46);
            this.txtCodigoProtheus.Name = "txtCodigoProtheus";
            this.txtCodigoProtheus.Size = new System.Drawing.Size(285, 29);
            this.txtCodigoProtheus.TabIndex = 54;
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrupos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoProtheusGrupo,
            this.colDescricaoGrupo,
            this.colIdGrupo});
            this.dgvGrupos.Location = new System.Drawing.Point(68, 199);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.Size = new System.Drawing.Size(669, 176);
            this.dgvGrupos.TabIndex = 50;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            // 
            // colCodigoProtheusGrupo
            // 
            this.colCodigoProtheusGrupo.HeaderText = "Código do Protheus";
            this.colCodigoProtheusGrupo.Name = "colCodigoProtheusGrupo";
            this.colCodigoProtheusGrupo.ReadOnly = true;
            // 
            // colDescricaoGrupo
            // 
            this.colDescricaoGrupo.HeaderText = "Descrição";
            this.colDescricaoGrupo.Name = "colDescricaoGrupo";
            this.colDescricaoGrupo.ReadOnly = true;
            // 
            // colIdGrupo
            // 
            this.colIdGrupo.HeaderText = "Id";
            this.colIdGrupo.Name = "colIdGrupo";
            this.colIdGrupo.ReadOnly = true;
            this.colIdGrupo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 22);
            this.label2.TabIndex = 60;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(359, 46);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(378, 29);
            this.txtDescricao.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAnexo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(68, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 67);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anexos";
            // 
            // txtAnexo
            // 
            this.txtAnexo.Location = new System.Drawing.Point(6, 28);
            this.txtAnexo.Name = "txtAnexo";
            this.txtAnexo.Size = new System.Drawing.Size(515, 29);
            this.txtAnexo.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 29);
            this.button1.TabIndex = 33;
            this.button1.Text = "Selecionar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 22);
            this.label4.TabIndex = 63;
            this.label4.Text = "Filtro";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(121, 164);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(261, 29);
            this.txtFiltro.TabIndex = 62;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChangedAsync);
            // 
            // FrmCadastroGrupos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 429);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoProtheus);
            this.Controls.Add(this.dgvGrupos);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCadastroGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Grupos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoProtheus;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAnexo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoProtheusGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGrupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}