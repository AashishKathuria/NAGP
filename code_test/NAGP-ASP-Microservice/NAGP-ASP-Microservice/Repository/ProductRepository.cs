using Microsoft.EntityFrameworkCore;
using NAGP_ASP_Microservice.DBContexts;
using NAGP_ASP_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAGP_ASP_Microservice.Repository
{
  
        public class ProductRepository : IProductRepository
    {
            private readonly ProductContext _dbContext;

            public ProductRepository(ProductContext dbContext)
            {
                _dbContext = dbContext;
            }
          
            public Product GetProductByID(int productId)
            {
                return _dbContext.Product.Find(productId);
            }

            public IEnumerable<Product> GetProducts()
            {
                return _dbContext.Product.ToList();
            }

          
        
    }
}
