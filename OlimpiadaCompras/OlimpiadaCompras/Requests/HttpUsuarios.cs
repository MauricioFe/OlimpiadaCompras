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
    public abstract class HttpUsuarios
    {
        public static async Task<List<Usuario>> GetAllUsuarios(string token)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios");
                    if (response.IsSuccessStatusCode)
                    {

                        var usuariosString = await response.Content.ReadAsStringAsync();
                        usuarios = JsonConvert.DeserializeObject<List<Usuario>>(usuariosString);
                        return usuarios;
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

        public static async Task<Usuario> GetUsuarioById(long id, string token)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosString = await response.Content.ReadAsStringAsync();
                        usuario = JsonConvert.DeserializeObject<Usuario>(usuariosString);
                        return usuario;
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
        public static async Task<List<Usuario>> GetUsuariosByNome(string nome, string token)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/search?nome={nome}");
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosString = await response.Content.ReadAsStringAsync();
                        usuarios = JsonConvert.DeserializeObject<List<Usuario>>(usuariosString);
                        return usuarios;
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
        public static async Task<Usuario> Login(Usuario usuario)
        {
            Usuario usuarioLogado = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosString = await response.Content.ReadAsStringAsync();
                        usuarioLogado = JsonConvert.DeserializeObject<Usuario>(usuariosString);
                        return usuarioLogado;
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
        public static async Task<Usuario> Create(Usuario usuario, string token)
        {
            Usuario usuarioCriado = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosString = await response.Content.ReadAsStringAsync();
                        usuarioCriado = JsonConvert.DeserializeObject<Usuario>(usuariosString);
                        return usuarioCriado;
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
        public static async Task<Usuario> Update(Usuario usuario, long id, string token)
        {
            Usuario usuarioEditado = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosString = await response.Content.ReadAsStringAsync();
                        usuarioEditado = JsonConvert.DeserializeObject<Usuario>(usuariosString);
                        return usuarioEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/{id}");
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
