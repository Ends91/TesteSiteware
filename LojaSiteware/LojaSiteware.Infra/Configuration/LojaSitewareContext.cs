using LojaSiteware.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSiteware.Infra.Data.Configuration
{
    public class LojaSitewareContext : DbContext
    {
        public LojaSitewareContext(DbContextOptions<LojaSitewareContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
    }
}
