using AppCEP.Model;
using AppCEP.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = Cep.Text.Trim();
            if(isValidCEP(cep))
            {
                try
                {
                    Endereco end = ServiceCEP.BuscaEnderecoViaCEP(cep);
                    if (end.cep == null)
                    {
                        Resultado.Text = "CEP não existe";
                    }
                    else
                    {
                        Resultado.Text = string.Format("Endereço: {2} de {3} {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro critico", ex.Message, "OK");
                }
            }
            else
            {
                Resultado.Text = "CEP Inválido";
            }
        }

        private bool isValidCEP(string cep)
        {
            if (cep.Length != 8) return false;
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP)) return false;
            return true;
        }
    }
}
