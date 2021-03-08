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
    public partial class FrmVisualizarNotaFiscal : Form
    {
        private FrmAreaCoordenacao form;
        private long idSolicitacao;

        public FrmVisualizarNotaFiscal(FrmAreaCoordenacao form, long idSolicitacao)
        {
            this.form = form;
            this.idSolicitacao = idSolicitacao;
            InitializeComponent();
            pdfReader.LoadFile(dowloadNotaFiscal(idSolicitacao));
        }

        private string dowloadNotaFiscal(long idSolicitacao)
        {
            return "bacon";
        }
    }
}
