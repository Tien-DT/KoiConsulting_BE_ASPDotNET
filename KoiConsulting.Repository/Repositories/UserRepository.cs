using KoiConsulting.Repository.Base;
using KoiConsulting.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiConsulting.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(KoiConsultingContext context) => _context = context;

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await _context.Users.FirstAsync(e => e.Id == id);

            return result;
        }
    }
}
