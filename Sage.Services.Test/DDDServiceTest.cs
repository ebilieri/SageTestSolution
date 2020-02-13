using Moq;
using System.Diagnostics.CodeAnalysis;
using Sage.Domain.Contracts.IRepositories;
using Sage.Domain.Contracts.IServices;
using Sage.Domain.Entities;
using Xunit;

namespace Sage.Services.Test
{
    [ExcludeFromCodeCoverage]
    public class DDDServiceTest
    {
        //private readonly Mock<IPessoaRepository> _dddRepository;
        //private readonly IPessoaService _serviceMock;

        //public DDDServiceTest()
        //{
        //    _dddRepository = new Mock<IPessoaRepository>();
        //    _serviceMock = new PessoaService(_dddRepository.Object);
        //}

        //[Fact]
        //public void DDDService_GetById_Return_Be_Sucess()
        //{
        //    _dddRepository.Setup(x => x.GetById(1)).Returns(new DDD
        //    {
        //        Id = 1,
        //        Codigo = "011"
        //    });
            
        //    var ddd = _serviceMock.GetById(1);

        //    _dddRepository.Verify(r => r.GetById(
        //        It.Is<int>(v => v == ddd.Id)));
        //}

        //[Fact]
        //public void DDDService_Add_Return_Be_Sucess()
        //{
        //    var ddd = new DDD
        //    {
        //        Id = 1,
        //        Codigo = "011"
        //    };
            
        //    _serviceMock.Add(ddd);

        //    _dddRepository.Verify(r => r.Add(
        //        It.Is<DDD>(v => v.Codigo == ddd.Codigo)));

        //}
    }
}
