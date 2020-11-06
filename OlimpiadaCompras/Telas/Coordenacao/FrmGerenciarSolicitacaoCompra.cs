using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Telas.Coordenacao
{
    public partial class FrmGerenciarSolicitacaoCompra : Form
    {
        public FrmGerenciarSolicitacaoCompra()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitandoEdicao();
        }

        private void btnSolicitarAlteracao_Click(object sender, EventArgs e)
        {
            FrmModalSolicitacao form = new FrmModalSolicitacao(1);
            form.ShowDialog();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            FrmModalSolicitacao form = new FrmModalSolicitacao(2);
            form.ShowDialog();
        }

        private void btnReprvar_Click(object sender, EventArgs e)
        {
            FrmModalSolicitacao form = new FrmModalSolicitacao(3);
            form.ShowDialog();
        }

        private void HabilitandoEdicao()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(GroupBox))
                {
                    GroupBox box = (GroupBox)item;
                    foreach (var group in box.Controls)
                    {
                        if (group.GetType() == typeof(TextBox))
                        {
                            var txt = (TextBox)group;
                            txt.Enabled = true;


                        }
                        if (group.GetType() == typeof(ComboBox))
                        {
                            var combo = (ComboBox)group;
                            combo.Enabled = true;
                        }
                    }

                }
            }
            button1.Visible = true;
            btnSolicitarAlteracao.Location = new Point(btnSolicitarAlteracao.Location.X + 173, btnSolicitarAlteracao.Location.Y);
        }
    }
}
