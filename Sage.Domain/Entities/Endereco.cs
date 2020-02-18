using Sage.Domain.Enums;

namespace Sage.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }
        public int PessoaId { get; set; }
    }
}
