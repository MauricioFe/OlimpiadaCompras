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
    public abstract class HttpAcompanhamento
    {
        public static async Task<List<Acompanhamento>> GetAll(string token)
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/acompanhamento");
                    if (response.IsSuccessStatusCode)
                    {
                        var acompanhamentoStr = await response.Content.ReadAsStringAsync();
                        acompanhamentos = JsonConvert.DeserializeObject<List<Acompanhamento>>(acompanhamentoStr);
                        return acompanhamentos;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com a api " + ex.Message);
                return null;
            }
        }
        public static async Task<List<Acompanhamento>> GetSolicitacaoAcompanhamento(string token)
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/acompanhamento/solicitacao");
                    if (response.IsSuccessStatusCode)
                    {
                        var acompanhamentoStr = await response.Content.ReadAsStringAsync();
                        acompanhamentos = JsonConvert.DeserializeObject<List<Acompanhamento>>(acompanhamentoStr);
                        return acompanhamentos;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com a api " + ex.Message);
                return null;
            }
        }

        public static async Task<List<Acompanhamento>> GetSolicitacaoAcompanhamentoPendente(string token)
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/acompanhamento/solicitacao/pendente");
                    if (response.IsSuccessStatusCode)
                    {
                        var acompanhamentoStr = await response.Content.ReadAsStringAsync();
                        acompanhamentos = JsonConvert.DeserializeObject<List<Acompanhamento>>(acompanhamentoStr);
                        return acompanhamentos;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com a api " + ex.Message);
                return null;
            }
        }

        public static async Task<Acompanhamento> GetBySolicitacaoId(long id, string token)
        {
            Acompanhamento acompanhamento = new Acompanhamento();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/acompanhamento/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var acompanhamentoStr = await response.Content.ReadAsStringAsync();
                        acompanhamento = JsonConvert.DeserializeObject<Acompanhamento>(acompanhamentoStr);
                        return acompanhamento;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com a api " + ex.Message);
                return null;
            }
        }
        public static async Task<Acompanhamento> Create(Acompanhamento acompanhamento, string token)
        {
            Acompanhamento acompanhamentoCriado = new Acompanhamento();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(acompanhamento);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/acompanhamento", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var acompanhamentoStr = await response.Content.ReadAsStringAsync();
                        acompanhamentoCriado = JsonConvert.DeserializeObject<Acompanhamento>(acompanhamentoStr);
                        return acompanhamentoCriado;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com a api "+ex.Message);
                return null;
            }
        }
        public static async Task<Acompanhamento> Update(Acompanhamento acompanhamento, long id,string token)
        {
            Acompanhamento acompanhamentoCriado = new Acompanhamento();
            try
            {
                using (var client = new HttpClient())
                {
                    var parseJson = JsonConvert.SerializeObject(acompanhamento);
                    var content = new StringContent(parseJson, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/acompanhamento/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var acompanhamentoStr = await response.Content.ReadAsStringAsync();
                        acompanhamentoCriado = JsonConvert.DeserializeObject<Acompanhamento>(acompanhamentoStr);
                        return acompanhamentoCriado;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com a api " + ex.Message);
                return null;
            }
        }
    }
}
