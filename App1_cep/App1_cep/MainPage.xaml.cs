using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_cep.Service;
using App1_cep.Model;

namespace App1_cep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            buttonSearch.Clicked += SearchCEP;
        }

        private void SearchCEP(object sender, EventArgs args) {
            string cepToSearch = cep.Text.Trim();

            //verifica CEP válido
            if (IsValidCEP(cepToSearch))
            {
                try 
                {
                    Address address = SendCepService.SearchAdressForCEP(cepToSearch);

                    if(address != null)
                    {
                        result.Text = string.Format("Endereço: {0} {1} {2} {3}", address.Localidade, address.UF, address.Logradouro, address.Bairro);

                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP não encontrado", "OK");
                    }
                    
                }
                catch (Exception e) 
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }

                
            }

        }

        private bool IsValidCEP(string verifyCep)
        {
            int newCep = 0;
            
            if (verifyCep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres", "OK");
                return false;     
            }

                        
            if(!int.TryParse(verifyCep, out newCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter apenas números", "OK");
                return false;
            }
            return true;
        }
    }
}
