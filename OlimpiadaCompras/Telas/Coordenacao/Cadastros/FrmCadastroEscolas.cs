using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Requests;
using OlimpiadaCompras.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Coordenacao.Cadastros
{
    public partial class FrmCadastroEscolas : Form
    {
        private Usuario usuarioLogado;
        List<Escola> escolas = new List<Escola>();
        List<Responsavel> responsaveis = new List<Responsavel>();
        long idEscola = 0;
        long idResponsavel = 0;
        int linhaClicada = 0;
        public FrmCadastroEscolas(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            AtualizaGrid();
        }

        private async void AtualizaGridByFiltro()
        {
            responsaveis = await HttpResponsaveis.GetResponsavelsBySearch(txtFiltro.Text, usuarioLogado.token);
            dgvEscolas.Rows.Clear();
            foreach (var responsavel in escolas)
            {
                int n = dgvEscolas.Rows.Add();
            }
        }
        private async void AtualizaGrid()
        {
            escolas = await HttpEscolas.GetAllEscolas(usuarioLogado.token);
            dgvEscolas.Rows.Clear();
            foreach (var escola in escolas)
            {
                int n = dgvEscolas.Rows.Add();
                dgvEscolas.Rows[n].Cells["colIdEscola"].Value = escola.Id;
                dgvEscolas.Rows[n].Cells["colNomeEscola"].Value = escola.Nome;
                dgvEscolas.Rows[n].Cells["colLogradouro"].Value = escola.Logradouro;
                dgvEscolas.Rows[n].Cells["colBairro"].Value = escola.Bairro;
                dgvEscolas.Rows[n].Cells["colCep"].Value = escola.Cep;
                dgvEscolas.Rows[n].Cells["colNumero"].Value = escola.Numero;
                dgvEscolas.Rows[n].Cells["colCidade"].Value = escola.Cidade;
                dgvEscolas.Rows[n].Cells["colEstado"].Value = escola.Estado;
            }

        }

        private void FrmCadastrarEscolas_Load(object sender, EventArgs e)
        {
        }

        private async Task Create()
        {
            Escola escola = new Escola();
            if (CampoVazio())
            {
                escola.Nome = txtNomeEscola.Text;
                escola.Cep = txtCep.Text;
                escola.Logradouro = txtLogradouro.Text;
                escola.Bairro = txtBairro.Text;
                escola.Numero = txtNumero.Text;
                escola.Estado = cboEstado.Text;
                escola.Cidade = txtCidade.Text;
                if (ResponsavelNaLista())
                {

                    var escolaEditada = await HttpEscolas.Create(escola, usuarioLogado.token);
                    if (escolaEditada == null)
                    {
                        MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                    }
                    else
                    {
                        AtualizaGrid();
                        escolas = await HttpEscolas.GetAllEscolas(usuarioLogado.token);
                        for (int i = 0; i < dgvResponsavel.Rows.Count; i++)
                        {
                            Responsavel responsavel = new Responsavel();
                            responsavel.EscolaId = escolas.Last().Id;
                            responsavel.Nome = dgvResponsavel.Rows[i].Cells[0].Value.ToString();
                            responsavel.Email = dgvResponsavel.Rows[i].Cells[1].Value.ToString();
                            responsavel.Cargo = dgvResponsavel.Rows[i].Cells[2].Value.ToString();
                            var responsavelCriado = await HttpResponsaveis.Create(responsavel, usuarioLogado.token);
                        }
                        MessageBox.Show("Escola adicionada com sucesso");
                        ManipulaFormGenericoUtil.LimpaCampos(this);
                    }
                }
                else
                {
                    MessageBox.Show("Coloque pelo menos 3 responsáveis para a escola");
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }

        private bool CampoVazio()
        {
            return !string.IsNullOrEmpty(txtNomeEscola.Text) && !string.IsNullOrEmpty(txtCep.Text) && !string.IsNullOrEmpty(txtLogradouro.Text)
                            && !string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtNumero.Text) && !string.IsNullOrEmpty(cboEstado.Text)
                            && !string.IsNullOrEmpty(txtCidade.Text);
        }
        private bool ResponsavelNaLista()
        {
            return (dgvResponsavel.Rows.Count != -1 && dgvResponsavel.Rows.Count >= 3);
        }

        private new async Task Update()
        {
            if (idEscola != 0)
            {

                Escola escola = new Escola();
                if (CampoVazio())
                {
                    escola.Nome = txtNomeEscola.Text;
                    escola.Cep = txtCep.Text;
                    escola.Logradouro = txtLogradouro.Text;
                    escola.Bairro = txtBairro.Text;
                    escola.Numero = txtNumero.Text;
                    escola.Estado = cboEstado.Text;
                    escola.Cidade = txtCidade.Text;
                    if (ResponsavelNaLista())
                    {

                        var escolaEditada = await HttpEscolas.Update(escola, idEscola, usuarioLogado.token);
                        if (escolaEditada == null)
                        {
                            MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                        }
                        else
                        {
                            AtualizaGrid();
                            for (int i = 0; i < dgvResponsavel.Rows.Count; i++)
                            {
                                Responsavel responsavel = new Responsavel();
                                responsavel.EscolaId = idEscola;
                                responsavel.Nome = dgvResponsavel.Rows[i].Cells[0].Value.ToString();
                                responsavel.Email = dgvResponsavel.Rows[i].Cells[1].Value.ToString();
                                responsavel.Cargo = dgvResponsavel.Rows[i].Cells[2].Value.ToString();
                                idResponsavel = Convert.ToInt64(dgvResponsavel.Rows[i].Cells["colIdResponsavel"].Value);

                                if (idResponsavel == 0)
                                {
                                    var responsavelCriado = await HttpResponsaveis.Create(responsavel, usuarioLogado.token);
                                }
                                else
                                {
                                    var responsavelEditado = await HttpResponsaveis.Update(responsavel, idResponsavel, usuarioLogado.token);
                                }
                            }
                            MessageBox.Show("Escola Editada com sucesso");
                            ManipulaFormGenericoUtil.LimpaCampos(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Coloque pelo menos 3 responsáveis para a escola");
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios");
                }
            }
            else
            {
                MessageBox.Show("Selecione ao menos uma escola na lista");
            }
        }
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (idEscola > 0)
            {
                await Update();
            }
            else
            {
                await Create();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeResponsavel.Text) && !string.IsNullOrEmpty(txtCargo.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text))
            {
                if (idResponsavel == 0)
                {
                    dgvResponsavel.Rows.Add(txtNomeResponsavel.Text, txtEmail.Text, txtCargo.Text, "Remover");
                }
                else
                {
                    dgvResponsavel.Rows[linhaClicada].Cells[0].Value = txtNomeResponsavel.Text;
                    dgvResponsavel.Rows[linhaClicada].Cells[1].Value = txtEmail.Text;
                    dgvResponsavel.Rows[linhaClicada].Cells[2].Value = txtCargo.Text;
                    LimpaEdicaoResponsavel();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos campos de responsáveis");
            }
        }

        private async void dgvResponsavel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResponsavel.Columns[e.ColumnIndex].Name == "colRemove")
            {
                if (MessageBox.Show("Tem certeza que deseja remover este item?", "Remover item", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (idResponsavel == 0)
                    {
                        dgvResponsavel.Rows.RemoveAt(e.RowIndex);
                        LimpaEdicaoResponsavel();
                    }
                    else
                    {
                        if (await HttpResponsaveis.Delete(idResponsavel, usuarioLogado.token))
                        {
                            dgvResponsavel.Rows.RemoveAt(e.RowIndex);
                            LimpaEdicaoResponsavel();
                        }
                        else
                        {
                            MessageBox.Show("Erro interno no servidor, tente em novamente em outro momento");
                        }

                    }
                }
                else
                {
                    LimpaEdicaoResponsavel();
                }
            }
        }

        private async void dgvEscolas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

                idEscola = Convert.ToInt64(dgvEscolas.Rows[e.RowIndex].Cells["colIdEscola"].Value);
                txtNomeEscola.Text = dgvEscolas.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtLogradouro.Text = dgvEscolas.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBairro.Text = dgvEscolas.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCep.Text = dgvEscolas.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNumero.Text = dgvEscolas.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCidade.Text = dgvEscolas.Rows[e.RowIndex].Cells[5].Value.ToString();
                cboEstado.Text = dgvEscolas.Rows[e.RowIndex].Cells[6].Value.ToString();
                responsaveis = await HttpResponsaveis.GetResponsavelsBySearch(dgvEscolas.Rows[e.RowIndex].Cells[0].Value.ToString(), usuarioLogado.token);
                dgvResponsavel.Rows.Clear();
                foreach (var item in responsaveis)
                {
                    dgvResponsavel.Rows.Add(item.Nome, item.Email, item.Cargo, "Remover", item.Id);
                }

            
        }

        private void dgvResponsavel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idResponsavel = Convert.ToInt64(dgvResponsavel.Rows[e.RowIndex].Cells["colIdResponsavel"].Value);
            txtNomeResponsavel.Text = dgvResponsavel.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtEmail.Text = dgvResponsavel.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCargo.Text = dgvResponsavel.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnCancelar.Visible = true;
            btnAdicionar.Text = "Alterar";
            btnAdicionar.BackColor = Color.Blue;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            linhaClicada = e.RowIndex;
            GerenciaBloqueioControles(false);
        }

        private void GerenciaBloqueioControles(bool enabled)
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() != typeof(GroupBox))
                {
                    var controle = (Control) item;
                    controle.Enabled = enabled;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaEdicaoResponsavel();
        }

        private void LimpaEdicaoResponsavel()
        {
            idResponsavel = 0;
            txtNomeResponsavel.Text = "";
            txtEmail.Text = "";
            txtCargo.Text = "";
            btnCancelar.Visible = false;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.BackColor = Color.FromArgb(3, 166, 90);
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            linhaClicada = 0;
            GerenciaBloqueioControles(true);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
           
        }
    }
}
