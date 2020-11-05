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
    }
}
