using ApiSGCOlimpiada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OlimpiadaCompras.Data
{
    public abstract class HttpUsuarios
    {
        public static async Task<List<Usuario>> GetAllUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios");
                    var usuariosString = await response.Content.ReadAsStringAsync();
                    usuarios = new JavaScriptSerializer().Deserialize<List<Usuario>>(usuariosString);
                    return usuarios;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Erro ao conectar com a api");
                return null;
            }

        }

        public static async Task<Usuario> GetUsuarioById(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/{id}");
                    var usuariosString = await response.Content.ReadAsStringAsync();
                    usuario = new JavaScriptSerializer().Deserialize<Usuario>(usuariosString);
                    return usuario;
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
                    var parseJson = new JavaScriptSerializer().Serialize(usuario);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/login", content);
                    var usuariosString = await response.Content.ReadAsStringAsync();
                    usuarioLogado = new JavaScriptSerializer().Deserialize<Usuario>(usuariosString);
                    return usuarioLogado;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<Usuario> Create(Usuario usuario)
        {
            Usuario usuarioCriado = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(usuario);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios", content);
                    var usuariosString = await response.Content.ReadAsStringAsync();
                    usuarioCriado = new JavaScriptSerializer().Deserialize<Usuario>(usuariosString);
                    return usuarioCriado;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<Usuario> Update(Usuario usuario, int id)
        {
            Usuario usuarioEditado = new Usuario();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = new JavaScriptSerializer().Serialize(usuario);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/{id}", content);
                    var usuariosString = await response.Content.ReadAsStringAsync();
                    usuarioEditado = new JavaScriptSerializer().Deserialize<Usuario>(usuariosString);
                    return usuarioEditado;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<bool> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/usuarios/{id}");
                    var result = await response.Content.ReadAsStringAsync();
                    return true;
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
