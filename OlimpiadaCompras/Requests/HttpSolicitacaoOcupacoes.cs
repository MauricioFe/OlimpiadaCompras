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
    public abstract class HttpSolicitacaoOcupacoes
    {
        public static async Task<List<OcupacaoSolicitacaoCompra>> GetAll(string token)
        {
            List<OcupacaoSolicitacaoCompra> ocupacaoSolicitacaoCompras = new List<OcupacaoSolicitacaoCompra>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra");
                    if (response.IsSuccessStatusCode)
                    {

                        var ocupacaoSolicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        ocupacaoSolicitacaoCompras = new JavaScriptSerializer().Deserialize<List<OcupacaoSolicitacaoCompra>>(ocupacaoSolicitacaoComprasString);
                        return ocupacaoSolicitacaoCompras;
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

        public static async Task<OcupacaoSolicitacaoCompra> GetOcupacaoSolicitacaoCompraById(long ocupacaoId, long solicitacaoId, string token)
        {
            OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompra = new OcupacaoSolicitacaoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra/{ocupacaoId}/{solicitacaoId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacaoSolicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        ocupacaoSolicitacaoCompra = new JavaScriptSerializer().Deserialize<OcupacaoSolicitacaoCompra>(ocupacaoSolicitacaoComprasString);
                        return ocupacaoSolicitacaoCompra;
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
        public static async Task<List<OcupacaoSolicitacaoCompra>> GetOcupacaoSolicitacaoComprasBySearch(string filtro, string token)
        {
            List<OcupacaoSolicitacaoCompra> ocupacaoSolicitacaoCompras = new List<OcupacaoSolicitacaoCompra>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacaoSolicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        ocupacaoSolicitacaoCompras = new JavaScriptSerializer().Deserialize<List<OcupacaoSolicitacaoCompra>>(ocupacaoSolicitacaoComprasString);
                        return ocupacaoSolicitacaoCompras;
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
        public static async Task<OcupacaoSolicitacaoCompra> Create(OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompra, string token)
        {
            OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompraCriado = new OcupacaoSolicitacaoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(ocupacaoSolicitacaoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacaoSolicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        ocupacaoSolicitacaoCompraCriado = new JavaScriptSerializer().Deserialize<OcupacaoSolicitacaoCompra>(ocupacaoSolicitacaoComprasString);
                        return ocupacaoSolicitacaoCompraCriado;
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
        public static async Task<OcupacaoSolicitacaoCompra> Update(OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompra, long ocupacaoId, long solicitacaoId, string token)
        {
            OcupacaoSolicitacaoCompra ocupacaoSolicitacaoCompraEditado = new OcupacaoSolicitacaoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(ocupacaoSolicitacaoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra/{ocupacaoId}/{solicitacaoId}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacaoSolicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        ocupacaoSolicitacaoCompraEditado = new JavaScriptSerializer().Deserialize<OcupacaoSolicitacaoCompra>(ocupacaoSolicitacaoComprasString);
                        return ocupacaoSolicitacaoCompraEditado;
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
        public static async Task<bool> Delete(long ocupacaoId, long solicitacaoId, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra/{ocupacaoId}/{solicitacaoId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return false;
            }

        }
        public static async Task<List<OcupacaoSolicitacaoCompra>> GetSolicitacao(long id, string token)
        {
            List<OcupacaoSolicitacaoCompra> ocupacaoSolicitacaoCompras = new List<OcupacaoSolicitacaoCompra>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacaoSolicitacaoCompra/solicitacao/{id}");
                    if (response.IsSuccessStatusCode)
                    {

                        var ocupacaoSolicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        ocupacaoSolicitacaoCompras = new JavaScriptSerializer().Deserialize<List<OcupacaoSolicitacaoCompra>>(ocupacaoSolicitacaoComprasString);
                        return ocupacaoSolicitacaoCompras;
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
    }
}
