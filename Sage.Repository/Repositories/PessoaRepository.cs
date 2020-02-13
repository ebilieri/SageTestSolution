using Sage.Domain.Contracts.IRepositories;
using Sage.Domain.Entities;
using Sage.Repository.Context;

namespace Sage.Repository.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(SageContext SageContext) : base(SageContext)
        {
        }
    }
}
