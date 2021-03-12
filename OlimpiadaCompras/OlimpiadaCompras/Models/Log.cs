using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiadaCompras.Models
{
    public class Log
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
