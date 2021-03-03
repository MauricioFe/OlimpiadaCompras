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
    public abstract class HttpProdutos
    {
        public static async Task<List<Produto>> GetAllProdutos(string token)
        {
            List<Produto> produtos = new List<Produto>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtos");
                    if (response.IsSuccessStatusCode)
                    {

                        var produtosString = await response.Content.ReadAsStringAsync();
                        produtos = JsonConvert.DeserializeObject<List<Produto>>(produtosString);
                        return produtos;
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

        public static async Task<Produto> GetProdutoById(long id, string token)
        {
            Produto produto = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtos/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtosString = await response.Content.ReadAsStringAsync();
                        produto = JsonConvert.DeserializeObject<Produto>(produtosString);
                        return produto;
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
        public static async Task<List<Produto>> GetProdutosBySearch(string filtro, string token)
        {
            List<Produto> produtos = new List<Produto>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtos/search?search={filtro}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtosString = await response.Content.ReadAsStringAsync();
                        produtos = JsonConvert.DeserializeObject<List<Produto>>(produtosString);
                        return produtos;
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
        public static async Task<Produto> Create(Produto produto, string token)
        {
            Produto produtoCriado = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/produtos", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var produtosString = await response.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(produtosString);
                        return produtoCriado;
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
        public static async Task<Produto> Update(Produto produto, long id, string token)
        {
            Produto produtoEditado = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/produtos/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var produtosString = await response.Content.ReadAsStringAsync();
                        produtoEditado = JsonConvert.DeserializeObject<Produto>(produtosString);
                        return produtoEditado;
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
                    var response = await client.DeleteAsync($"{ConstantesProjeto.URL_BASE}/api/produtos/{id}");
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

        public static async Task<Produto> GetProdutosByCodigoProtheus(long codigoProtheus, string token)
        {
            Produto produto = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/produtos/{codigoProtheus}");
                    if (response.IsSuccessStatusCode)
                    {
                        var produtosString = await response.Content.ReadAsStringAsync();
                        produto = JsonConvert.DeserializeObject<Produto>(produtosString);
                        return produto;
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
