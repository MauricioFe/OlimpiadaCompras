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
    public abstract class HttpSolicitacaoCompras
    {
        public static async Task<List<SolicitacaoCompra>> GetAll(string token)
        {
            List<SolicitacaoCompra> solicitacaoCompras = new List<SolicitacaoCompra>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra");
                    if (response.IsSuccessStatusCode)
                    {

                        var solicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        solicitacaoCompras = new JavaScriptSerializer().Deserialize<List<SolicitacaoCompra>>(solicitacaoComprasString);
                        return solicitacaoCompras;
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

        public static async Task<SolicitacaoCompra> GetSolicitacaoCompraById(long id, string token)
        {
            SolicitacaoCompra solicitacaoCompra = new SolicitacaoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var solicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        solicitacaoCompra = new JavaScriptSerializer().Deserialize<SolicitacaoCompra>(solicitacaoComprasString);
                        return solicitacaoCompra;
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
        
        public static async Task<SolicitacaoCompra> Create(SolicitacaoCompra solicitacaoCompra, string token)
        {
            SolicitacaoCompra solicitacaoCompraCriado = new SolicitacaoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(solicitacaoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var solicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        solicitacaoCompraCriado = new JavaScriptSerializer().Deserialize<SolicitacaoCompra>(solicitacaoComprasString);
                        return solicitacaoCompraCriado;
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
        public static async Task<SolicitacaoCompra> Update(SolicitacaoCompra solicitacaoCompra, long id, string token)
        {
            SolicitacaoCompra solicitacaoCompraEditado = new SolicitacaoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(solicitacaoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var solicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        solicitacaoCompraEditado = new JavaScriptSerializer().Deserialize<SolicitacaoCompra>(solicitacaoComprasString);
                        return solicitacaoCompraEditado;
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
        public static async Task<bool> Delete(long id, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra/{id}");
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

        //public static async Task<bool> AnexarNotaFiscal()

    }
}
