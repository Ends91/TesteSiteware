using LojaSiteware.Domain.Entities;
using LojaSiteware.UI.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSiteware.Infra.Data.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product CreateProduct(ProductDTO product);
        Product DeleteProduct(int id);
        Product UpdateProduct(int id, ProductDTO product);
    }
}
