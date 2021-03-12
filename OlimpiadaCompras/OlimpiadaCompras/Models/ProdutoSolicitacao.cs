using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiadaCompras.Models
{
    public class ProdutoSolicitacao
    {
        public long Id { get; set; }
        public long SolicitacaoComprasId { get; set; }
        public long ProdutosId { get; set; }
        public Produto Produto { get; set; }
        public SolicitacaoCompra SolicitacaoCompra { get; set; }
    }
}
