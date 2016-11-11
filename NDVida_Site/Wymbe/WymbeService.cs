using NDVida_Site.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NDVida_Site.Wymbe
{
    public class WymbeService
    {

        readonly bool IsHTTPS = (ConfigurationManager.AppSettings["IsHTTPS"] != null && ConfigurationManager.AppSettings["IsHTTPS"] == "S" ? true : false);
        
        readonly string baseUri = ConfigurationManager.AppSettings["WymbeServiceBaseUrl"];


        private ApplicationDbContext db = new ApplicationDbContext();

        private string GetGroup(string codigoCampanha)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                if (!IsHTTPS)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                string groupId = client.GetAsync(@"api/group/" + codigoCampanha)
                                 .Result
                                 .Content
                                 .ReadAsAsync<string>()
                                 .Result;
                
                return groupId;
            }
        }

        public bool CheckEmailExists(string email)
        {
            using (HttpClient client = new HttpClient())
            //using (HttpClient client = new HttpClient(new WymbeLoggingHandler(new HttpClientHandler())))
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (!IsHTTPS)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                string userId = client.GetAsync(@"api/user/" + email)
                                 .Result
                                 .Content
                                 .ReadAsStringAsync()
                                 .Result;

                return !string.IsNullOrEmpty(userId) && !userId.ToUpper().Contains("NOT FOUND");
            }
        }

        public void RegisterUser(WymbeUser novoUsuario, string codigoEmpresa)
        {
            // Recupera codigo da campanha
            var codigoCampanha = db.Campanhas.FirstOrDefault(c => c.Ativo == true && c.Empresa.Codigo.ToUpper() == codigoEmpresa.ToUpper()).Codigo;
            novoUsuario.data.U_GROUP = GetGroup(codigoCampanha);

            using (HttpClient client = new HttpClient())
            //using (HttpClient client = new HttpClient(new WymbeLoggingHandler(new HttpClientHandler())))
            {

                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (!IsHTTPS)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                var resultado = client.PostAsJsonAsync(@"api/register", novoUsuario)
                                .Result
                                .Content
                                .ReadAsStringAsync()
                                .Result;

            }
        }

        public string SignInUser(WymbeLoginPostData postData)
        {
            string resultado;
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (!IsHTTPS)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                resultado = client.PostAsJsonAsync(@"api/sso/login", postData)
                            .Result
                            .Content
                            .ReadAsStringAsync()
                            .Result;

                resultado = resultado.Replace("\n", "");

            }

            return resultado;
        }
    }    
}
