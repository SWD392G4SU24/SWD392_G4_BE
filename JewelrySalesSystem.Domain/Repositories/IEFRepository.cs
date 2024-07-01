using JewelrySalesSystem.Domain.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories
{
    public interface IEFRepository<TDomain, TPersistance> : IRepository<TDomain>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TDomain?> FindAsync(Expression<Func<TPersistance, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistance, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistance, bool>> filterExpression, int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TPersistance, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TPersistance, bool>> filterExpression, CancellationToken cancellationToken = default);
    }
}
