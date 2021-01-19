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
    public abstract class HttpEscolas
    {
        public static async Task<List<Escola>> GetAllEscolas(string token)
        {
            List<Escola> escolas = new List<Escola>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/escolas");
                    if (response.IsSuccessStatusCode)
                    {

                        var escolasString = await response.Content.ReadAsStringAsync();
                        escolas = new JavaScriptSerializer().Deserialize<List<Escola>>(escolasString);
                        return escolas;
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

        public static async Task<Escola> GetEscolaById(long id, string token)
        {
            Escola escola = new Escola();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/escolas/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var escolasString = await response.Content.ReadAsStringAsync();
                        escola = new JavaScriptSerializer().Deserialize<Escola>(escolasString);
                        return escola;
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
        public static async Task<List<Escola>> GetEscolasBySearch(string filtro, string token)
        {
            List<Escola> escolas = new List<Escola>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/escolas/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var escolasString = await response.Content.ReadAsStringAsync();
                        escolas = new JavaScriptSerializer().Deserialize<List<Escola>>(escolasString);
                        return escolas;
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
        public static async Task<Escola> Create(Escola escola, string token)
        {
            Escola escolaCriado = new Escola();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(escola);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/escolas", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var escolasString = await response.Content.ReadAsStringAsync();
                        escolaCriado = new JavaScriptSerializer().Deserialize<Escola>(escolasString);
                        return escolaCriado;
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
        public static async Task<Escola> Update(Escola escola, long id, string token)
        {
            Escola escolaEditado = new Escola();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(escola);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/escolas/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var escolasString = await response.Content.ReadAsStringAsync();
                        escolaEditado = new JavaScriptSerializer().Deserialize<Escola>(escolasString);
                        return escolaEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/escolas/{id}");
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
