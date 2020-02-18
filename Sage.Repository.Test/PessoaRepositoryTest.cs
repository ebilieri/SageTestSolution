using Sage.Domain.Contracts.IRepositories;
using Sage.Domain.Entities;
using Sage.Repository.Repositories;
using Sage.Repository.Test.Contexto;
using System.Collections.Generic;
using Xunit;

namespace Sage.Repository.Test
{
    public class DDDRepositoryTest
    {
        private readonly IPessoaRepository _dddRepository;

        public DDDRepositoryTest()
        {
            _dddRepository = new PessoaRepository(RepositoryDataContext.InstanceContext());
        }

        [Fact]
        public void Pessoa_Save_Changes_Is_Called()
        {
            var pessoa = new Pessoa
            {
                Id = 1,
                Nome = "Maira",
                Sobrenome = "Silva",
                Email = "silva@gmail.com",
                Rg = "1234568",
                Cpf = "012548978",
                EstadoCivil = Domain.Enums.EstadoCivilEnum.Casado,
                EnderecosPessoas = new List<Endereco>
                {
                    new Endereco
                    {
                        CEP = "126647",
                        Estado = "PR",
                        Cidade = "Curitiba",
                        Logradouro = "Rua 123",
                        Numero = 0,
                        Complemento = "AP 96",
                        TipoEndereco = Domain.Enums.TipoEnderecoEnum.Residencial,
                        PessoaId = 1
                    }
                }
            };

            _dddRepository.Add(pessoa);

            var retorno = _dddRepository.GetById(1);

            //Assert  
            Assert.NotNull(retorno);
            Assert.IsAssignableFrom<Pessoa>(retorno);
        }
    }
}
