using LojaSiteware.Domain.Entities;
using LojaSiteware.Infra.Data.Configuration;
using LojaSiteware.Infra.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaSiteware.Infra.Data.Implementations.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly LojaSitewareContext _context;

        public PromotionRepository(LojaSitewareContext context)
        {
            _context = context;
        }

        public IEnumerable<Promotion> ListPromotions()
        {
            return _context.Promotions.ToList();
        }
    }
}
