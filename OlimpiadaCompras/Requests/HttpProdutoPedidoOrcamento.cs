using ApiSGCOlimpiada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OlimpiadaCompras.Requests
{
    public abstract class HttpProdutoPedidoOrcamentos
    {
        public static async Task<List<ProdutoPedidoOrcamento>> GetAll(string token)
        {
            List<ProdutoPedidoOrcamento> produtoPedidoOrcamentos = new List<ProdutoPedidoOrcamento>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtoPedidoOrcamento");
                    if (response.IsSuccessStatusCode)
                    {

                        var produtoPedidoOrcamentosString = await response.Content.ReadAsStringAsync();
                        produtoPedidoOrcamentos = new JavaScriptSerializer().Deserialize<List<ProdutoPedidoOrcamento>>(produtoPedidoOrcamentosString);
                        return produtoPedidoOrcamentos;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Erro ao conectar com a api");
                return null;
            }

        }

        public static async Task<ProdutoPedidoOrcamento> GetProdutoPedidoOrcamentoById(long id, string token)
        {
            ProdutoPedidoOrcamento produtoPedidoOrcamento = new ProdutoPedidoOrcamento();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtoPedidoOrcamento/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoPedidoOrcamentosString = await response.Content.ReadAsStringAsync();
                        produtoPedidoOrcamento = new JavaScriptSerializer().Deserialize<ProdutoPedidoOrcamento>(produtoPedidoOrcamentosString);
                        return produtoPedidoOrcamento;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Erro ao conectar com a api");
                return null;
            }
        }

        public static async Task<ProdutoPedidoOrcamento> Create(ProdutoPedidoOrcamento produtoPedidoOrcamento, string token)
        {
            ProdutoPedidoOrcamento produtoPedidoOrcamentoCriado = new ProdutoPedidoOrcamento();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(produtoPedidoOrcamento);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/produtoPedidoOrcamento", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoPedidoOrcamentosString = await response.Content.ReadAsStringAsync();
                        produtoPedidoOrcamentoCriado = new JavaScriptSerializer().Deserialize<ProdutoPedidoOrcamento>(produtoPedidoOrcamentosString);
                        return produtoPedidoOrcamentoCriado;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<ProdutoPedidoOrcamento> Update(ProdutoPedidoOrcamento produtoPedidoOrcamento, long id, string token)
        {
            ProdutoPedidoOrcamento produtoPedidoOrcamentoEditado = new ProdutoPedidoOrcamento();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(produtoPedidoOrcamento);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/produtoPedidoOrcamento/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var produtoPedidoOrcamentosString = await response.Content.ReadAsStringAsync();
                        produtoPedidoOrcamentoEditado = new JavaScriptSerializer().Deserialize<ProdutoPedidoOrcamento>(produtoPedidoOrcamentosString);
                        return produtoPedidoOrcamentoEditado;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<List<ProdutoPedidoOrcamento>> GetSolicitacao(long idSolicitacao, string token, string route)
        {
            List<ProdutoPedidoOrcamento> produtoPedidoOrcamentos = new List<ProdutoPedidoOrcamento>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtoPedidoOrcamento/{route}/{idSolicitacao}");
                    if (response.IsSuccessStatusCode)
                    {

                        var produtoPedidoOrcamentosString = await response.Content.ReadAsStringAsync();
                        produtoPedidoOrcamentos = new JavaScriptSerializer().Deserialize<List<ProdutoPedidoOrcamento>>(produtoPedidoOrcamentosString);
                        return produtoPedidoOrcamentos;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro ao conectar com a api " + e.Message);
                return null;
            }

        }
    }
}
