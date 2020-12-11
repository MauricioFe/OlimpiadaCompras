using ApiSGCOlimpiada.Models;
using OlimpiadaCompras.Requests;
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
    }
}
