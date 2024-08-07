﻿using AutoMapper;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity
{
    public class RoleRepository : RepositoryBase<RoleEntity, RoleEntity, ApplicationDbContext>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
        }
        public async Task<RoleEntity> GetByNameAsync(string roleName)
        {
            return await _context.Set<RoleEntity>().FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
