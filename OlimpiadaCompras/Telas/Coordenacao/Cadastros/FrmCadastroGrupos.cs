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
    public partial class FrmCadastroGrupos : Form
    {
        private Usuario usuarioLogado;
        List<Grupo> grupos = new List<Grupo>();
        private long id = 0;

        public FrmCadastroGrupos(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            AtualizaGrid();
        }

        private async Task AtualizaGridByFiltro()
        {
            grupos = await HttpGrupos.GetGruposBySearch(txtFiltro.Text, usuarioLogado.token);
            dgvGrupos.Rows.Clear();
            foreach (var grupo in grupos)
            {
                int n = dgvGrupos.Rows.Add();
                dgvGrupos.Rows[n].Cells[0].Value = grupo.CodigoProtheus;
                dgvGrupos.Rows[n].Cells[1].Value = grupo.Descricao;
                dgvGrupos.Rows[n].Cells[2].Value = grupo.Id;
            }
        }
        private async void AtualizaGrid()
        {
            grupos = await HttpGrupos.GetAllGrupos(usuarioLogado.token);
            dgvGrupos.Rows.Clear();
            foreach (var grupo in grupos)
            {
                int n = dgvGrupos.Rows.Add();
                dgvGrupos.Rows[n].Cells[0].Value = grupo.CodigoProtheus;
                dgvGrupos.Rows[n].Cells[1].Value = grupo.Descricao;
                dgvGrupos.Rows[n].Cells[2].Value = grupo.Id;
            }

        }

        private async void txtFiltro_TextChangedAsync(object sender, EventArgs e)
        {
            await AtualizaGridByFiltro();
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt64(dgvGrupos.Rows[e.RowIndex].Cells["colIdGrupo"].Value);
            txtCodigoProtheus.Text = dgvGrupos.Rows[e.RowIndex].Cells["colCodigoProtheusGrupo"].Value.ToString();
            txtDescricao.Text = dgvGrupos.Rows[e.RowIndex].Cells["colDescricaoGrupo"].Value.ToString();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                await Update();
            }
            else
            {
                await Create();
            }
        }
        private async Task Create()
        {
            Grupo grupo = new Grupo();
            if (!string.IsNullOrEmpty(txtCodigoProtheus.Text) && !string.IsNullOrEmpty(txtDescricao.Text))
            {
                grupo.CodigoProtheus = long.Parse(txtCodigoProtheus.Text);
                grupo.Descricao = txtDescricao.Text;
                var grupoCriado = await HttpGrupos.Create(grupo, usuarioLogado.token);
                if (grupoCriado == null)
                {
                    MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
                }
                else
                {
                    AtualizaGrid();
                    MessageBox.Show("Grupo de produto adicionado com sucesso");
                    ManipulaFormGenericoUtil.LimpaCampos(this);
                }
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }
        private new async Task Update()
        {
            Grupo grupo = new Grupo();
            if (id != 0)
            {

                if (!string.IsNullOrEmpty(txtCodigoProtheus.Text) && !string.IsNullOrEmpty(txtDescricao.Text))
                {
                    grupo.CodigoProtheus = long.Parse(txtCodigoProtheus.Text);
                    grupo.Descricao = txtDescricao.Text;
                    var grupoCriado = await HttpGrupos.Update(grupo, id, usuarioLogado.token);
                    if (grupoCriado == null)
                    {
                        MessageBox.Show(ConstantesProjeto.MENSAGEM_ERRO_SERVIDOR);
                    }
                    else
                    {
                        AtualizaGrid();
                        MessageBox.Show("Grupo de produto editado com sucesso");
                        ManipulaFormGenericoUtil.LimpaCampos(this);
                    }
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios");
                }
            }
            else
            {
                MessageBox.Show("Selecione um Grupo de produto da lista");
            }
        }
        private async void btnExcluir_ClickAsync(object sender, EventArgs e)
        {
            if (MessageBox.Show(ConstantesProjeto.CONFIRMACAO_EXLUSAO, "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (id != 0)
                {
                    await HttpGrupos.Delete(id, usuarioLogado.token);
                    AtualizaGrid();
                    MessageBox.Show("Grupo de produto excluído com sucesso");
                    ManipulaFormGenericoUtil.LimpaCampos(this);
                }
                else
                {
                    MessageBox.Show("Selecione um Grupo de produto da lista");
                }
            }
        }
    }
}
