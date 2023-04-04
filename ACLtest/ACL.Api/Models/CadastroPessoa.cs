namespace ACL.Api.Models
{
    public class CadastroPessoa
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Profissao { get; set; }
        public string? Email { get; set; }
        public string? Atividade { get; set; }
        public string? Situacao { get; set; }
        public string? Site { get; set; }

        public string? Rua { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }
        public string? Complemento { get; set; }
    }
}
