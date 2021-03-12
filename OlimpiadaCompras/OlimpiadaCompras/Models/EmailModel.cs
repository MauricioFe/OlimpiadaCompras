﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiadaCompras.Models
{
    public class EmailModel
    {
        public string CodUnidadeOrganizacional { get; set; }
        public string CentroResponsabilidade { get; set; }
        public string ClasseValor { get; set; }
        public string UnidadeOrganizacional { get; set; }
        public string ContaContabil { get; set; }
        public List<Responsavel> Responsaveis { get; set; }
        public Orcamento Orcamento { get; set; }
        public List<Ocupacao> Ocupacoes { get; set; }
        public Acompanhamento Acompanhamento { get; set; }
    }
}
