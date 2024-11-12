using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository.IRepository;
using Laptopy.Repository;

namespace Laptopy.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}