using OlimpiadaCompras.Models;
using OlimpiadaCompras.Telas.Coordenacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras
{
    public partial class FrmAreaCoordenacao : Form
    {
        public FrmAreaCoordenacao()
        {
            InitializeComponent();
        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            if (pnlCadastros.Visible == true)
            {
                pnlCadastros.Visible = false;
            }
            else
            {
                pnlCadastros.Visible = true;
            }
        }

        private void FrmAreaCoordenacao_Load(object sender, EventArgs e)
        {
            dgvSolicitacoes.Rows.Add(908170, "Fresa de Topo de Metal Duro Para Desbaste Pesado Em Aco Ø16mm, Com Cobertura de Tialn, ComprimentoTotal de 100 Mm, Aresta de Corte de 34mm, 4 Navalhas Em Helice de 38°, Chanfro de 45° Nas Arestas, Si ", 2, "Material para cursos", "Em análise");
        }

        private void dgvSolicitacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmGerenciarSolicitacaoCompra form = new FrmGerenciarSolicitacaoCompra();
            form.ShowDialog();
        }
    }
}
