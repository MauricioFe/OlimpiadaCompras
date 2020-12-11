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
    public abstract class HttpTipoCompras
    {
        public static async Task<List<TipoCompra>> GetAllTipoCompras(string token)
        {
            List<TipoCompra> tipoCompras = new List<TipoCompra>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/tipoCompras");
                    if (response.IsSuccessStatusCode)
                    {

                        var tipoComprasString = await response.Content.ReadAsStringAsync();
                        tipoCompras = new JavaScriptSerializer().Deserialize<List<TipoCompra>>(tipoComprasString);
                        return tipoCompras;
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

        public static async Task<TipoCompra> GetTipoCompraById(long id, string token)
        {
            TipoCompra tipoCompra = new TipoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/tipoCompras/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var tipoComprasString = await response.Content.ReadAsStringAsync();
                        tipoCompra = new JavaScriptSerializer().Deserialize<TipoCompra>(tipoComprasString);
                        return tipoCompra;
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
        public static async Task<List<TipoCompra>> GetTipoComprasBySearch(string filtro, string token)
        {
            List<TipoCompra> tipoCompras = new List<TipoCompra>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/tipoCompras/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var tipoComprasString = await response.Content.ReadAsStringAsync();
                        tipoCompras = new JavaScriptSerializer().Deserialize<List<TipoCompra>>(tipoComprasString);
                        return tipoCompras;
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
        public static async Task<TipoCompra> Create(TipoCompra tipoCompra, string token)
        {
            TipoCompra tipoCompraCriado = new TipoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(tipoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/tipoCompras", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var tipoComprasString = await response.Content.ReadAsStringAsync();
                        tipoCompraCriado = new JavaScriptSerializer().Deserialize<TipoCompra>(tipoComprasString);
                        return tipoCompraCriado;
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
        public static async Task<TipoCompra> Update(TipoCompra tipoCompra, long id, string token)
        {
            TipoCompra tipoCompraEditado = new TipoCompra();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(tipoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/tipoCompras/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var tipoComprasString = await response.Content.ReadAsStringAsync();
                        tipoCompraEditado = new JavaScriptSerializer().Deserialize<TipoCompra>(tipoComprasString);
                        return tipoCompraEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/tipoCompras/{id}");
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

    }
}
