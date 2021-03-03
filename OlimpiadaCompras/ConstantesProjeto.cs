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
        public static string URL_BASE = $"http://localhost:5000";
        public const string MENSAGEM_ERRO_SERVIDOR = "Erro interno no servidor, tente em novamente em outro momento";
        public const string MENSAGEM_PREENCHER_CAMPOS = "Todos os campos são obrigatórios";
        public const string CONFIRMACAO_EXLUSAO = "Você realmente deseja excluir esse registro?";
        public const int STATUS_EM_ANALISE = 1;
        public const int STATUS_APROVADO = 2;
        public const int STATUS_REPROVADO = 3;
        public const int STATUS_FINALIZAR_CADASTRO = 4;
        public const int STATUS_ANEXAR_NF = 5;
        public const int STATUS_EM_ANALISE_NF = 6;
        public const int STATUS_PENDENTE_ALTERACAO = 7;
        public const int STATUS_FINALIZADO = 8;
        public const int SOLICITAR_ALTERACAO = 1;
        public const int SOLICITACAO_APROVADA = 2;
        public const int SOLICITACAO_REPROVADA = 3;
        public const int EDITAR = 1;
        public const int VISUALIZAR = 2;
        public const int SALVAR = 3;
    }
}
