using ACLtest.Models;
using Newtonsoft.Json;
using System.Text;

namespace ACLtest.Anticorrupcao
{
    public class CadastroPessoaClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _host = "https://localhost:7260/api";

        public CadastroPessoaClient()
        {
            _httpClient = new HttpClient() { };
        }
        public async Task<List<CadastroPessoaViewModel>> Pesquisa(string cpfCnpjNome)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_host}/CadastroPessoa/Pesquisa?cpfCnpjNome=" + cpfCnpjNome);
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<CadastroPessoaViewModel>>(jsonResult);

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<CadastroPessoaViewModel>> Post(CadastroPessoaViewModel value)
        {
            var content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_host}/CadastroPessoa", content);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CadastroPessoaViewModel>>(jsonResult);
            return data;
        }

        public async Task<CadastroPessoaViewModel> Edit(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_host}/CadastroPessoa/editar?id=" + id);
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CadastroPessoaViewModel>(jsonResult);

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<string> Delete(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_host}/CadastroPessoa/delete?id=" + id);
            response.EnsureSuccessStatusCode();
            return null;
        }



    }
}
