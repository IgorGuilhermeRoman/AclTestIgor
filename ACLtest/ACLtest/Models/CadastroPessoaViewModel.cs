using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ACLtest.Models
{
    public class CadastroPessoaViewModel
    { 
        public string? Id { get; set; }
        public string? Nome { get; set; }
        [Display(Name = "Cpf / Cnpj")]
        public string? CpfCnpj { get; set; }
        [Display(Name = "Profissão")]
        public string? Profissao { get; set; }
        public string? Email { get; set; }
        public string? Rua { get; set; }
        [Display(Name = "Número")]
        public int? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }
        public string? Atividade { get; set; }
        [Display(Name = "Situação")]
        public string? Situacao { get; set; }
        public string? Site { get; set; }  
        public string? Complemento { get; set; }
    }


}
