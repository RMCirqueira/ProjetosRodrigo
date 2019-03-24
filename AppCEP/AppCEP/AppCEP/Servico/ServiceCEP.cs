using AppCEP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppCEP.Servico
{
    public class ServiceCEP
    {
        public static string EnderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            return end;
        }
    }
}
