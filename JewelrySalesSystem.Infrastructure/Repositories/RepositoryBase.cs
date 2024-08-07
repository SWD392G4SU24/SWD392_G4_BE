﻿using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories
{
    public class RepositoryBase<TDomain, TPersistence, TDbContext> : IEFRepository<TDomain, TPersistence>
       where TDbContext : DbContext, IUnitOfWork
       where TPersistence : class, TDomain
       where TDomain : class
    {
        private readonly TDbContext _dbContext;
        private readonly IMapper _mapper;
        public RepositoryBase(TDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        protected virtual DbSet<TPersistence> GetSet()
        {
            return _dbContext.Set<TPersistence>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual void Add(TDomain entity)
        {
            GetSet().Add((TPersistence)entity);
        }

        public virtual void Remove(TDomain entity)
        {
            GetSet().Remove((TPersistence)entity);
        }

        public virtual void Update(TDomain entity)
        {
            GetSet().Update((TPersistence)entity);
        }

        protected virtual IQueryable<TPersistence> CreateQuery()
        {
            return GetSet();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TPersistence, bool>> filterExpression
            , CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).AnyAsync(cancellationToken);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TPersistence, bool>> filterExpression
            , CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).CountAsync(cancellationToken);
        }

        public virtual async Task<List<TDomain>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await QueryInternal(x => true).ToListAsync<TDomain>(cancellationToken);
        }
        public virtual async Task<List<TDomain>> FindAllAsync(
           Expression<Func<TPersistence, bool>> filterExpression,
           CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).ToListAsync<TDomain>(cancellationToken);
        }
        public virtual async Task<List<TDomain>> FindAllAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression, queryOptions).ToListAsync<TDomain>(cancellationToken);
        }
        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(x => true);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }
        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            int pageNo,
            int pageSize,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(queryOptions);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }

        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(filterExpression);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }
        public virtual async Task<TDomain?> FindAsync(Expression<Func<TPersistence, bool>> filterExpression
            , CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).SingleOrDefaultAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<TDomain?> FindAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression, queryOptions).SingleOrDefaultAsync<TDomain>(cancellationToken);
        }

        protected virtual IQueryable<TPersistence> QueryInternal(Expression<Func<TPersistence, bool>>? filterExpression)
        {
            var queryable = CreateQuery();
            if (filterExpression != null)
            {
                queryable = queryable.Where(filterExpression);
            }
            return queryable;
        }
        protected virtual IQueryable<TResult> QueryInternal<TResult>(
            Expression<Func<TPersistence, bool>> filterExpression,
            Func<IQueryable<TPersistence>, IQueryable<TResult>> queryOptions)
        {
            var queryable = CreateQuery();
            queryable = queryable.Where(filterExpression);
            var result = queryOptions(queryable);
            return result;
        }
        protected virtual IQueryable<TPersistence> QueryInternal(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions)
        {
            var queryable = CreateQuery();
            if (queryOptions != null)
            {
                queryable = queryOptions(queryable);
            }
            return queryable;
        }

        public async Task<Dictionary<TKey, TValue>> FindAllToDictionaryAsync<TKey, TValue>(
            Expression<Func<TPersistence, bool>> filterExpression,
            Expression<Func<TPersistence, TKey>> keySelector,
            Expression<Func<TPersistence, TValue>> valueSelector,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TPersistence> query = _dbContext.Set<TPersistence>().Where(filterExpression);
            return await query.ToDictionaryAsync(keySelector.Compile(), valueSelector.Compile(), cancellationToken);
        }

    }
}
