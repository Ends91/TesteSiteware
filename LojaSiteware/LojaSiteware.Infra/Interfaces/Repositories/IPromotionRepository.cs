using LojaSiteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaSiteware.Infra.Data.Interfaces.Repositories
{
    public interface IPromotionRepository
    {
        IEnumerable<Promotion> ListPromotions();
    }
}
