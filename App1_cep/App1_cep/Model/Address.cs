﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App1_cep.Model
{
    class Address
    {

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string IBGE { get; set; }
        public string DDD { get; set; }
        public string Siafi { get; set; }
    }
}
