using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiadaCompras
{
    public abstract class ConstantesProjeto
    {
        //url remota
        //public static string URL_BASE = "http://177.74.238.210:5000";
        //url local
        public static string URL_BASE = $"http://{Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First()}:5000";
        public static string MENSAGEM_ERRO_SERVIDOR = "Erro interno no servidor, tente em novamente em outro momento";
        public static string MENSAGEM_PREENCHER_CAMPOS = "Todos os campos são obrigatórios";
        public static string CONFIRMACAO_EXLUSAO = "Você realmente deseja excluir esse registro?";
        public static int STATUS_APROVADO = 2;
        public static int STATUS_ANEXAR_NF = 3;
        public static int STATUS_EM_ANALISE_NF = 4;
        public static int STATUS_PENDENTE_ALTERACAO = 5;
        public static int STATUS_FINALIZADO = 6;
        public static int STATUS_REPROVADO = 7;
        public static int SOLICITAR_ALTERACAO = 1;
        public static int SOLICITACAO_APROVADA = 2;
        public static int SOLICITACAO_REPROVADA = 3;
        public const int EDITAR = 1;
        public const int VISUALIZAR = 2;

    }
}
