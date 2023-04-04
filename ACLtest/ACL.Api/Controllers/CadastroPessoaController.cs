using ACL.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ACL.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CadastroPessoaController : ControllerBase
    {
        private static List<CadastroPessoa> _pessoas = new List<CadastroPessoa>();
        private static int count = 2;
        #region paraDebug
        public CadastroPessoaController()
        {
            if (_pessoas.Count == 0)
            {
                _pessoas = new List<CadastroPessoa>
                {
                    new CadastroPessoa
                    {
                        Id = "1",
                        Nome = "João Silva",
                        CpfCnpj = "123.456.789-10",
                        Profissao = "Programador",
                        Email = "joao.silva@exemplo.com",
                        Rua = "Rua das Flores",
                        Numero = 123,
                        Bairro = "Centro",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Cep = "01234-567",
                        Complemento = "",
                        Atividade = "",
                        Situacao = "",
                        Site = ""
                    }
                };
            }
        }
        #endregion


        [HttpGet("pesquisa")]
        public List<CadastroPessoa> Pesquisa(string? cpfCnpjNome)
        {
            if (string.IsNullOrEmpty(cpfCnpjNome))
            {   
                return _pessoas;
            }

            var cadastro = new List<CadastroPessoa>();

            cadastro = _pessoas.Where(c => c.CpfCnpj.Contains(cpfCnpjNome)).ToList();

            if (cadastro.Count == 0)
            {
                cadastro = _pessoas.Where(c => c.Nome.ToUpper().Contains(cpfCnpjNome.ToUpper())).ToList();
            }

            return cadastro;
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] CadastroPessoa value)
        {
            if(!string.IsNullOrEmpty(value.CpfCnpj))
            { 
                if(_pessoas.Where(a => a.Id == value.Id).Count() > 0)
                {
                    var cpfCnpj = Regex.Replace(value.CpfCnpj, @"[-./]", "");

                    var index = _pessoas.FindIndex(a => a.Id == value.Id && a.CpfCnpj == value.CpfCnpj);

                    _pessoas[index].Nome = value.Nome;
                    _pessoas[index].Profissao = value.Profissao;
                    _pessoas[index].Email = value.Email;
                    _pessoas[index].Rua = value.Rua;
                    _pessoas[index].Numero = value.Numero;
                    _pessoas[index].Bairro = value.Bairro;
                    _pessoas[index].Cidade = value.Cidade;
                    _pessoas[index].Estado = value.Estado;
                    _pessoas[index].Cep = value.Cep;
                    _pessoas[index].Complemento = value.Complemento;

                    if (cpfCnpj.Length == 14)
                    {
                        _pessoas[index].Atividade = value.Atividade;
                        _pessoas[index].Situacao = value.Situacao;
                        _pessoas[index].Site = value.Site;
                    }

                }
                else
                {                  
                    value.Id = count.ToString();                    
                    _pessoas.Add(value);
                    count++;
                }
            }
            return Ok(_pessoas);    
        }

        [HttpGet("editar")]
        public CadastroPessoa Editar(string id)
        {
            return _pessoas.Where(c => c.Id == id).FirstOrDefault();
        }

        [HttpDelete("delete")]
        public void Delete(string id)
        {
            _pessoas.RemoveAt(_pessoas.FindIndex(a => a.Id == id));
        }
   
    }
}
