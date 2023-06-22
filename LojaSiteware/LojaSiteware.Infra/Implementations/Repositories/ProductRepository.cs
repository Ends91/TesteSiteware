using LojaSiteware.Domain.Entities;
using LojaSiteware.Infra.Data.Configuration;
using LojaSiteware.Infra.Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaSiteware.Infra.Data.Implementations.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly LojaSitewareContext _context;

        public ProductRepository(LojaSitewareContext context)
        {
            _context = context;
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            
            if(product.Promotion.Description != null)
                _context.Promotions.Add(product.Promotion);
            
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return null;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> ListProducts()
        {
            return _context.Products.Include(x => x.Promotion).AsNoTracking().ToList();
        }

        public Product UpdateProduct(int id, Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault(x => x.Id == id);

            if(product == null)
                return null;

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            _context.Entry(productToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return productToUpdate;
        }
    }
}
