using LojaSiteware.Domain.Entities;
using LojaSiteware.Infra.Data.Interfaces.Repositories;
using LojaSiteware.Infra.Data.Interfaces.Services;
using LojaSiteware.UI.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSiteware.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product CreateProduct(ProductDTO product)
        {
            return _productRepository.CreateProduct(new Product { Name = product.Name, Price = product.Price, Promotion = new Promotion { Description = product.PromotionDescription } });
        }

        public Product DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.ListProducts();
        }

        public Product UpdateProduct(int id, ProductDTO product)
        {
            return _productRepository.UpdateProduct(id, new Product { Id = id, Name = product.Name, Price = product.Price });
        }
    }
}
