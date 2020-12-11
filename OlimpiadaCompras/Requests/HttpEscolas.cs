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
    public abstract class HttpResponsavels
    {
        public static async Task<List<Responsavel>> GetAllResponsavels(string token)
        {
            List<Responsavel> responsaveis = new List<Responsavel>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/responsaveis");
                    if (response.IsSuccessStatusCode)
                    {

                        var responsaveisString = await response.Content.ReadAsStringAsync();
                        responsaveis = new JavaScriptSerializer().Deserialize<List<Responsavel>>(responsaveisString);
                        return responsaveis;
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

        public static async Task<Responsavel> GetResponsavelById(long id, string token)
        {
            Responsavel responsavel = new Responsavel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/responsaveis/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responsaveisString = await response.Content.ReadAsStringAsync();
                        responsavel = new JavaScriptSerializer().Deserialize<Responsavel>(responsaveisString);
                        return responsavel;
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
        public static async Task<List<Responsavel>> GetResponsavelsBySearch(string filtro, string token)
        {
            List<Responsavel> responsaveis = new List<Responsavel>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/responsaveis/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responsaveisString = await response.Content.ReadAsStringAsync();
                        responsaveis = new JavaScriptSerializer().Deserialize<List<Responsavel>>(responsaveisString);
                        return responsaveis;
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
        public static async Task<Responsavel> Create(Responsavel responsavel, string token)
        {
            Responsavel responsavelCriado = new Responsavel();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(responsavel);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/responsaveis", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responsaveisString = await response.Content.ReadAsStringAsync();
                        responsavelCriado = new JavaScriptSerializer().Deserialize<Responsavel>(responsaveisString);
                        return responsavelCriado;
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
        public static async Task<Responsavel> Update(Responsavel responsavel, long id, string token)
        {
            Responsavel responsavelEditado = new Responsavel();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(responsavel);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/responsaveis/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responsaveisString = await response.Content.ReadAsStringAsync();
                        responsavelEditado = new JavaScriptSerializer().Deserialize<Responsavel>(responsaveisString);
                        return responsavelEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/responsaveis/{id}");
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
