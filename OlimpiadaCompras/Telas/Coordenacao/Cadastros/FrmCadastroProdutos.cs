﻿using ApiSGCOlimpiada.Models;
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
    public partial class FrmCadastroProdutos : Form
    {
        private Usuario usuarioLogado;

        public FrmCadastroProdutos(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
        }
    }
}
