using OlimpiadaCompras.Models;
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
    public partial class FrmEmailAutorizacao : Form
    {
        private EmailModel data;
        private Usuario usuarioLogado;
        private FrmAreaCoordenacao frmAreaCoordenacao;

        public FrmEmailAutorizacao(EmailModel data, Usuario usuarioLogado, FrmAreaCoordenacao frmAreaCoordenacao)
        {
            this.data = data;
            this.usuarioLogado = usuarioLogado;
            this.frmAreaCoordenacao = frmAreaCoordenacao;
            InitializeComponent();
        }

    }
}
