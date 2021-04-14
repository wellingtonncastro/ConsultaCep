using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_cep.Model;
using Newtonsoft.Json;

namespace App1_cep.Service
{
    class SendCepService
    {
        //endereço pra pra busca com parâmetro
        private static string AddressURL = "https://viacep.com.br/ws/{0}/json/";

        public static Address SearchAdressForCEP(string cep)
        {
            string AddressNewURL = string.Format(AddressURL, cep);
            // classe responsavel por consultas na web
            WebClient web = new WebClient();

            string res = web.DownloadString(AddressNewURL);

            Address address = JsonConvert.DeserializeObject<Address>(res);

            if(address.Cep == null)
            {
                return null;
            }
            return address;
        }
    }
}
