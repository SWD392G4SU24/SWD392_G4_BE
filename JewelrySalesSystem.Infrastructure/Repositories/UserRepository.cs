using AutoMapper;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity, UserEntity, ApplicationDbContext>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext,mapper)
        {
            _context = dbContext;
        }
        public async Task<UserEntity> FindByEmailAsync(string email)
        {
            return await _context.Set<UserEntity>().FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(UserEntity user)
        {
            await _context.Set<UserEntity>().AddAsync(user);
        }
        public string GeneratePassword()
        {
            var characters = "qwertyuiopasdfghjklzxcvbnm1234567890!@#$%";

            var random = new Random();

            StringBuilder sb = new StringBuilder();
            while (sb.Length < 7)
            {

                // Get a random index
                var index = random.Next(characters.Length);

                // Get character at index
                var character = characters[index];

                // Append to string builder
                sb.Append(character);
            }

            return sb.ToString();
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
