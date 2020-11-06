using OlimpiadaCompras.Telas.Avaliador;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "coordenador@email.com")
            {
                FrmAreaCoordenacao form = new FrmAreaCoordenacao();
                form.Show();
                this.Hide();
            }
            else
            {
                FrmAreaAvaliador form = new FrmAreaAvaliador();
                form.Show();
                this.Hide();
            }
        }
    }
}
