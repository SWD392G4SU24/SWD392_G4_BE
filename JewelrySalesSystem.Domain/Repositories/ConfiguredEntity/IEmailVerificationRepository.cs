using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Entities.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories.ConfiguredEntity
{
    public interface IEmailVerificationRepository : IEFRepository<EmailVerification, EmailVerification>
    {
    }
}
