using ConProWeb.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ConProWeb.Pages
{
    public class IndexCode : ComponentBase
    {
        protected bool _exibirJanelaToken = false;

        protected bool _exibirJanelaSucesso = false;
        protected bool _exibirJanelaFalha = false;

        protected string _token = string.Empty;
        protected string _mensagemJanela = string.Empty;

        protected void AoClicarBotaoAtualizarListagemProjetos()
        {
            //if ( _caixaToken == null )
            //{
            //    _caixaToken = new CaixaTokenAutenticacao();
            //}

            //_caixaToken.Exibir();
            _exibirJanelaToken = !_exibirJanelaToken;
        }

        protected void ExibirJanelaTokem()
        {
            _exibirJanelaToken = true;
        }

        protected void OcultarJanelaToken()
        {
            _exibirJanelaToken = false;
        }

        protected async void ConfirmarInformacaoToken()
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri( @"localhost:5000" );
            HttpResponseMessage respota = await http.PostAsJsonAsync( "api/BuscarListaAtualizadasProjetosGitHub", _token );

            if ( respota.IsSuccessStatusCode )
            {
                _mensagemJanela = "Projetos atualizados.";
                _exibirJanelaSucesso = true;
            }
            else
            {
                _mensagemJanela = "Ocorreu um erro.";
                _exibirJanelaFalha = true;
            }

            _exibirJanelaSucesso = false;
            _exibirJanelaFalha = false;
        }

        protected void CancelarInformacaoToken()
        {
            _token = string.Empty;
            OcultarJanelaToken();
        }
    }
}