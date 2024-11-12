﻿using Laptopy.Data;
using Laptopy.Models;
using Laptopy.Repository.IRepository;

namespace Laptopy.Repository
{
    public class ProductImagesRepository : Repository<ProductImages>, IProductImagesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductImagesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
