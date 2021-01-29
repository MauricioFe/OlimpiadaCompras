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
    public static class HttpEmail
    {
        public static async Task<bool> EnviarEmail(EmailModel data, long idSolicitacao, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var json = new JavaScriptSerializer().Serialize(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{ConstantesProjeto.URL_BASE}/api/enviarEmail/{idSolicitacao}", content);
                    if (response.IsSuccessStatusCode)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
