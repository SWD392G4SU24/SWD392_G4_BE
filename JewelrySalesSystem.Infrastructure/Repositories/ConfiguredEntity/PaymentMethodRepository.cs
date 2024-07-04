using AutoMapper;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity
{
    public class PaymentMethodRepository : RepositoryBase<PaymentMethodEntity, PaymentMethodEntity, ApplicationDbContext>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
