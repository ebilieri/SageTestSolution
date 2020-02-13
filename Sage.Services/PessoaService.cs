using Sage.Domain.Contracts.IRepositories;
using Sage.Domain.Contracts.IServices;
using Sage.Domain.Entities;

namespace Sage.Services
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        public PessoaService(IBaseRepository<Pessoa> baseRepository) : base(baseRepository)
        {
        }
    }
}
