using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiadaCompras.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public long CodigoProtheus { get; set; }
        public string Descricao { get; set; }
        public long GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
