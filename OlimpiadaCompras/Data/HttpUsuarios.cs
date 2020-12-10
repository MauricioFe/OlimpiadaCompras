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
    public class HttpUsuarios
    {
        public async Task<List<Usuario>> GetAllUsuarios(Usuario usuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"");
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

    }
}
