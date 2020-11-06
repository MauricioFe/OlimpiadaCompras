using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiadaCompras.Models
{
   public class SolicitacaoCompra
    {
        public SolicitacaoCompra(long codigoProtheus, string descricao, int quantidade, string tipoCompra, string status)
        {
            CodigoProtheus = codigoProtheus;
            Descricao = descricao;
            Quantidade = quantidade;
            TipoCompra = tipoCompra;
            Status = status;
        }

        public long CodigoProtheus { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string TipoCompra { get; set; }
        public string Status { get; set; }
    }
}
