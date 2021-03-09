using Newtonsoft.Json;
using OlimpiadaCompras.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                        solicitacaoCompras = JsonConvert.DeserializeObject<List<SolicitacaoCompra>>(solicitacaoComprasString);
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
                        solicitacaoCompra = JsonConvert.DeserializeObject<SolicitacaoCompra>(solicitacaoComprasString);
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
                    var parseJson = JsonConvert.SerializeObject(solicitacaoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var solicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        solicitacaoCompraCriado = JsonConvert.DeserializeObject<SolicitacaoCompra>(solicitacaoComprasString);
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
                    var parseJson = JsonConvert.SerializeObject(solicitacaoCompra);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var solicitacaoComprasString = await response.Content.ReadAsStringAsync();
                        solicitacaoCompraEditado = JsonConvert.DeserializeObject<SolicitacaoCompra>(solicitacaoComprasString);
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

        public static async Task<bool> AnexarNotaFiscal(string fileName, long id, string token)
        {
            try
            {
                using (var formContent = new MultipartFormDataContent())
                {
                    formContent.Headers.ContentType.MediaType = "multipart/form-data";
                    try
                    {
                        FileStream fileStream = File.OpenRead(fileName);
                        formContent.Add(new StreamContent(fileStream), "arquivo", fileName.Split('\\').Last());
                    }
                    catch (Exception)
                    {
                        fileName = "null";
                    }
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                        var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{ConstantesProjeto.URL_BASE}/api/SolicitacaoCompra/notaFiscal/" + id)
                        {
                            Content = formContent,
                        };
                        var response = await client.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return false;
            }

        }
        public static async Task<byte[]> DownloadNotaFiscal(string fileName, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/solicitacaoCompra/download?arquivo={fileName}");
                    if (response.IsSuccessStatusCode)
                    {
                        var file = await response.Content.ReadAsByteArrayAsync();
                        return file;
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
