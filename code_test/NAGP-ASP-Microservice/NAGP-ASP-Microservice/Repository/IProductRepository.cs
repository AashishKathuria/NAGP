using NAGP_ASP_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAGP_ASP_Microservice.Repository
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

         Product GetProductByID(int ProductId);

    }
}
