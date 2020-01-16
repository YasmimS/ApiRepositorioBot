using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Net;


namespace ApiRepositorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        
        public static void enviaRequisicaoGet(){
            var requisicaoWeb = WebRequest.CreateHttp("https://api.github.com/takenet");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                var post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());

                Console.WriteLine(post.Id + " " + post.title + " " + post.body);
                streamDados.Close();
                resposta.Close();
            }

        }

         public static void EnviaRequisicaoPOST()
        {
            string dadosPOST = "title=repositoriosAntigosC#";
            dadosPOST = dadosPOST + "&body=Envio de post";
            dadosPOST = dadosPOST + "&idRepo=1";

            var dados = Encoding.UTF8.GetBytes(dadosPOST);

            var requisicaoWeb = WebRequest.CreateHttp("https://api.github.com/takenet");

            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.ContentLength = dados.Length;
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            //precisamos escrever os dados post para o stream
            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(dados, 0, dados.Length);
                stream.Close();
            }
        
         }

    }
}
