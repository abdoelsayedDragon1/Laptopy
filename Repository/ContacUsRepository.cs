using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository.IRepository;

namespace Laptopy.Repository
{
    public class ContacUsRepository : Repository<ContactUs>, IContacUsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ContacUsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
