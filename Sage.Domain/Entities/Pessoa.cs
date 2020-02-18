using Sage.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sage.Domain.Entities
{
   public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome  { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }

        public EstadoCivilEnum EstadoCivil { get; set; }

        public virtual ICollection<Endereco> EnderecosPessoas { get; set; }
        
    }
}
