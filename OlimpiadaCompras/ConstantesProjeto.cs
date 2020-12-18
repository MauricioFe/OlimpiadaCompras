using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiadaCompras
{
    public abstract class ConstantesProjeto
    {
        //url remota
        //public static string URL_BASE = "http://177.74.238.210:5000";
        //url local
        public static string URL_BASE = "http://192.168.0.100:5000";
        public static string MENSAGEM_ERRO_SERVIDOR = "Erro interno no servidor, tente em novamente em outro momento";
        public static string MENSAGEM_PREENCHER_CAMPOS = "Todos os campos são obrigatórios";
        public static string CONFIRMACAO_EXLUSAO = "Você realmente deseja excluir esse registro?";
    }
}
