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
    public abstract class HttpGrupos
    {
        public static async Task<List<Grupo>> GetAllGrupos(string token)
        {
            List<Grupo> grupos = new List<Grupo>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/grupos");
                    if (response.IsSuccessStatusCode)
                    {

                        var gruposString = await response.Content.ReadAsStringAsync();
                        grupos = new JavaScriptSerializer().Deserialize<List<Grupo>>(gruposString);
                        return grupos;
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

        public static async Task<Grupo> GetGrupoById(long id, string token)
        {
            Grupo grupo = new Grupo();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/grupos/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var gruposString = await response.Content.ReadAsStringAsync();
                        grupo = new JavaScriptSerializer().Deserialize<Grupo>(gruposString);
                        return grupo;
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
        public static async Task<List<Grupo>> GetGruposBySearch(string filtro, string token)
        {
            List<Grupo> grupos = new List<Grupo>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/grupos/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var gruposString = await response.Content.ReadAsStringAsync();
                        grupos = new JavaScriptSerializer().Deserialize<List<Grupo>>(gruposString);
                        return grupos;
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
        public static async Task<Grupo> Create(Grupo grupo, string token)
        {
            Grupo grupoCriado = new Grupo();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(grupo);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/grupos", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var gruposString = await response.Content.ReadAsStringAsync();
                        grupoCriado = new JavaScriptSerializer().Deserialize<Grupo>(gruposString);
                        return grupoCriado;
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
        public static async Task<Grupo> Update(Grupo grupo, long id, string token)
        {
            Grupo grupoEditado = new Grupo();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(grupo);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/grupos/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var gruposString = await response.Content.ReadAsStringAsync();
                        grupoEditado = new JavaScriptSerializer().Deserialize<Grupo>(gruposString);
                        return grupoEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/grupos/{id}");
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
