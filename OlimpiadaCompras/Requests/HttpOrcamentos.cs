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
    public abstract class HttpOrcamentos
    {
        public static async Task<List<Orcamento>> GetAll(string token)
        {
            List<Orcamento> orcamentos = new List<Orcamento>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/orcamentos");
                    if (response.IsSuccessStatusCode)
                    {

                        var orcamentosString = await response.Content.ReadAsStringAsync();
                        orcamentos = JsonConvert.DeserializeObject<List<Orcamento>>(orcamentosString);
                        return orcamentos;
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

        public static async Task<Orcamento> GetOrcamentoById(long id, string token)
        {
            Orcamento orcamento = new Orcamento();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/orcamentos/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var orcamentosString = await response.Content.ReadAsStringAsync();
                        orcamento = JsonConvert.DeserializeObject<Orcamento>(orcamentosString);
                        return orcamento;
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

        public static async Task<Orcamento> Create(Orcamento orcamento, string token)
        {
            Orcamento orcamentoCriado = new Orcamento();
            try
            {
                using (var formContent = new MultipartFormDataContent())
                {
                    formContent.Headers.ContentType.MediaType = "multipart/form-data";
                    try
                    {
                        FileStream fileStream = File.OpenRead(orcamento.Anexo);
                        formContent.Add(new StreamContent(fileStream), "arquivo", orcamento.Anexo.Split('\\').Last());

                    }
                    catch (Exception)
                    {
                        orcamento.Anexo = "null";
                    }
                    formContent.Add(new StringContent(orcamento.Fornecedor), "Fornecedor");
                    formContent.Add(new StringContent(orcamento.FormaPagamento), "FormaPagamento");
                    formContent.Add(new StringContent(orcamento.Cnpj), "Cnpj");
                    formContent.Add(new StringContent(orcamento.ValorTotal.ToString()), "ValorTotal");
                    formContent.Add(new StringContent(orcamento.TotalIpi.ToString()), "TotalIpi");
                    formContent.Add(new StringContent(orcamento.TotalProdutos.ToString()), "TotalProdutos");
                    formContent.Add(new StringContent(orcamento.ValorFrete.ToString()), "ValorFrete");
                    formContent.Add(new StringContent(orcamento.Data.ToString()), "Data");
                    formContent.Add(new StringContent(orcamento.Anexo), "anexo");
                    formContent.Add(new StringContent(orcamento.OrderFlag.ToString()), "OrderFlag");
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                        var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/orcamentos", formContent);
                        if (response.IsSuccessStatusCode)
                        {
                            var orcamentosString = await response.Content.ReadAsStringAsync();
                            orcamentoCriado = JsonConvert.DeserializeObject<Orcamento>(orcamentosString);
                            return orcamentoCriado;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<Orcamento> Update(Orcamento orcamento, long id, string token)
        {
            Orcamento orcamentoEditado = new Orcamento();
            try
            {
                using (var formContent = new MultipartFormDataContent())
                {
                    formContent.Headers.ContentType.MediaType = "multipart/form-data";
                    try
                    {
                        FileStream fileStream = File.OpenRead(orcamento.Anexo);
                        formContent.Add(new StreamContent(fileStream), "arquivo", orcamento.Anexo.Split('\\').Last());

                    }
                    catch (Exception)
                    {
                        orcamento.Anexo = "null";
                    }
                    formContent.Add(new StringContent(orcamento.Fornecedor), "Fornecedor");
                    formContent.Add(new StringContent(orcamento.FormaPagamento), "FormaPagamento");
                    formContent.Add(new StringContent(orcamento.Cnpj), "Cnpj");
                    formContent.Add(new StringContent(orcamento.ValorTotal.ToString()), "ValorTotal");
                    formContent.Add(new StringContent(orcamento.TotalIpi.ToString()), "TotalIpi");
                    formContent.Add(new StringContent(orcamento.TotalProdutos.ToString()), "TotalProdutos");
                    formContent.Add(new StringContent(orcamento.ValorFrete.ToString()), "ValorFrete");
                    formContent.Add(new StringContent(orcamento.Data.ToString()), "Data");
                    formContent.Add(new StringContent(orcamento.Anexo), "anexo");
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                        var response = await client.PutAsync($"{ConstantesProjeto.URL_BASE}/api/orcamentos/{id}", formContent);
                        if (response.IsSuccessStatusCode)
                        {
                            var orcamentosString = await response.Content.ReadAsStringAsync();
                            orcamentoEditado = JsonConvert.DeserializeObject<Orcamento>(orcamentosString);
                            return orcamentoEditado;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao conectar com a api {ex.Message}");
                return null;
            }

        }
        public static async Task<List<Orcamento>> GetByIdSolicitacao(long id, string token)
        {
            List<Orcamento> orcamentos = new List<Orcamento>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/orcamentos/solicitacao/{id}");
                    if (response.IsSuccessStatusCode)
                    {

                        var orcamentosString = await response.Content.ReadAsStringAsync();
                        orcamentos = JsonConvert.DeserializeObject<List<Orcamento>>(orcamentosString);
                        return orcamentos;
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

        public static async Task<byte[]> DownloadPdfOrcamentos(string fileName, string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = await client.GetAsync($"{ConstantesProjeto.URL_BASE}/api/orcamentos/download/{fileName}");
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
