using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ACLtest.Models
{
    public class CadastroViewModel
    {
        public PesquisaViewModel Pesquisa { get; set; }
        public CadastroPessoaViewModel Cadastro { get; set; }
        public List<CadastroPessoaViewModel> List { get; set; }

        public CadastroViewModel()
        {
            List = new List<CadastroPessoaViewModel> { };
            Pesquisa = new PesquisaViewModel();
        }
    }

    public class PesquisaViewModel
    {
        [Display(Name = "Cpf / Cnpj ou Nome")]
        public string? Nome { get; set; }
    }
}
