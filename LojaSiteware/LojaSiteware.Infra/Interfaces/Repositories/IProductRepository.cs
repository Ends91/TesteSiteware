using LojaSiteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSiteware.Infra.Data.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> ListProducts();
        public Product CreateProduct(Product product);
        public Product DeleteProduct(int id);
        public Product UpdateProduct(int id, Product product);
    }
}
