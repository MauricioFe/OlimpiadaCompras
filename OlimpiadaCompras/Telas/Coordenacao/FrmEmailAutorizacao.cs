﻿using System;
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
        public FrmEmailAutorizacao()
        {
            InitializeComponent();
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enviado com sucesso");
            this.Dispose();
        }
    }
}
