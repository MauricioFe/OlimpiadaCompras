using Newtonsoft.Json;
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
    public abstract class HttpOcupacaos
    {
        public static async Task<List<Ocupacao>> GetAllOcupacaos(string token)
        {
            List<Ocupacao> ocupacoes = new List<Ocupacao>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacoes");
                    if (response.IsSuccessStatusCode)
                    {

                        var ocupacoesString = await response.Content.ReadAsStringAsync();
                        ocupacoes = JsonConvert.DeserializeObject<List<Ocupacao>>(ocupacoesString);
                        return ocupacoes;
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

        public static async Task<Ocupacao> GetOcupacaoById(long id, string token)
        {
            Ocupacao ocupacao = new Ocupacao();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacoes/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacoesString = await response.Content.ReadAsStringAsync();
                        ocupacao = JsonConvert.DeserializeObject<Ocupacao>(ocupacoesString);
                        return ocupacao;
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
        public static async Task<List<Ocupacao>> GetOcupacaosBySearch(string filtro, string token)
        {
            List<Ocupacao> ocupacoes = new List<Ocupacao>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacoes/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacoesString = await response.Content.ReadAsStringAsync();
                        ocupacoes = JsonConvert.DeserializeObject<List<Ocupacao>>(ocupacoesString);
                        return ocupacoes;
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
        public static async Task<Ocupacao> Create(Ocupacao ocupacao, string token)
        {
            Ocupacao ocupacaoCriado = new Ocupacao();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(ocupacao);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacoes", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacoesString = await response.Content.ReadAsStringAsync();
                        ocupacaoCriado = JsonConvert.DeserializeObject<Ocupacao>(ocupacoesString);
                        return ocupacaoCriado;
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
        public static async Task<Ocupacao> Update(Ocupacao ocupacao, long id, string token)
        {
            Ocupacao ocupacaoEditado = new Ocupacao();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(ocupacao);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacoes/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var ocupacoesString = await response.Content.ReadAsStringAsync();
                        ocupacaoEditado = JsonConvert.DeserializeObject<Ocupacao>(ocupacoesString);
                        return ocupacaoEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/ocupacoes/{id}");
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
