using OlimpiadaCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OlimpiadaCompras.Requests
{
    public abstract class HttpProdutoSolicitacoes
    {
        public static async Task<List<ProdutoSolicitacao>> GetAll(string token)
        {
            List<ProdutoSolicitacao> produtoSolicitacoes = new List<ProdutoSolicitacao>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ProdutoSolicitacoes");
                    if (response.IsSuccessStatusCode)
                    {
                        var solicitacaoStr = await response.Content.ReadAsStringAsync();
                        produtoSolicitacoes = new JavaScriptSerializer().Deserialize<List<ProdutoSolicitacao>>(solicitacaoStr);
                        return produtoSolicitacoes;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao conectar na api " + e.Message);
                return null;
            }
        }
        public async static Task<ProdutoSolicitacao> GetById(long id, string token)
        {
            ProdutoSolicitacao produtoSolicitacao = new ProdutoSolicitacao();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtoSolicitacoes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoSolicitacaoStr = await response.Content.ReadAsStringAsync();
                        produtoSolicitacao = new JavaScriptSerializer().Deserialize<ProdutoSolicitacao>(produtoSolicitacaoStr);
                        return produtoSolicitacao;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao conectar na api {e.Message}");
                return null;
            }
        }

        public static async Task<List<ProdutoSolicitacao>> GetByIdSolicitacao(long idSolicitacao, string token)
        {
            List<ProdutoSolicitacao> produtoSolicitacoes = new List<ProdutoSolicitacao>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtoSolicitacoes/solicitacao/{idSolicitacao}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoSolicitacaoStr = await response.Content.ReadAsStringAsync();
                        produtoSolicitacoes = new JavaScriptSerializer().Deserialize<List<ProdutoSolicitacao>>(produtoSolicitacaoStr);
                        return produtoSolicitacoes;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao conectar na api {e.Message}");
                return null;
            }
        }
        public async static Task<ProdutoSolicitacao> Create(ProdutoSolicitacao produtoSolicitacao, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var json = new JavaScriptSerializer().Serialize(produtoSolicitacao);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/ProdutoSolicitacoes", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoSolicitacaoStr = await response.Content.ReadAsStringAsync();
                        produtoSolicitacao = new JavaScriptSerializer().Deserialize<ProdutoSolicitacao>(produtoSolicitacaoStr);
                        return produtoSolicitacao;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao conectar na api {e.Message}");
                return null;
            }
        }
        public async static Task<ProdutoSolicitacao> Update(ProdutoSolicitacao produtoSolicitacao, long id, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var json = new JavaScriptSerializer().Serialize(produtoSolicitacao);
                    var content = new StringContent(json, Encoding.UTF8, "aplication/json");
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/produtoSolicitacoes/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoSolicitacaoStr = await response.Content.ReadAsStringAsync();
                        produtoSolicitacao = new JavaScriptSerializer().Deserialize<ProdutoSolicitacao>(produtoSolicitacaoStr);
                        return produtoSolicitacao;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao conectar na api {e.Message}");
                return null;
            }
        }
        public async static Task<bool> Delete(long id, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/produtoSolicitacoes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoSolicitacaoStr = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao conectar na api {e.Message}");
                return false;
            }
        }
    }
}
