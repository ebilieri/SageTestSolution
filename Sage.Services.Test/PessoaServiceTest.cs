using Moq;
using System.Diagnostics.CodeAnalysis;
using Sage.Domain.Contracts.IRepositories;
using Sage.Domain.Contracts.IServices;
using Sage.Domain.Entities;
using Xunit;
using System.Collections.Generic;

namespace Sage.Services.Test
{
    [ExcludeFromCodeCoverage]
    public class PessoaServiceTest
    {
        private readonly Mock<IPessoaRepository> _pessoaRepository;
        private readonly IPessoaService _serviceMock;

        public PessoaServiceTest()
        {
            _pessoaRepository = new Mock<IPessoaRepository>();
            _serviceMock = new PessoaService(_pessoaRepository.Object);
        }

        [Fact]
        public void PessoaService_GetById_Return_Be_Sucess()
        {
            _pessoaRepository.Setup(x => x.GetById(1)).Returns(new Pessoa
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
            });

            var pessoa = _serviceMock.GetById(1);

            _pessoaRepository.Verify(r => r.GetById(
                It.Is<int>(v => v == pessoa.Id)));
        }

        [Fact]
        public void PessoaService_Add_Return_Be_Sucess()
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

            _serviceMock.Add(pessoa);

            _pessoaRepository.Verify(r => r.Add(
                It.Is<Pessoa>(v => v.Id == pessoa.Id)));

        }
    }
}
