using KoiConsulting.Repository.Models;
using KoiConsulting.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiConsulting.Repository
{
    public class UnitOfWork
    {
        private KoiConsultingContext _context;
        private UserRepository _userRepository;

        public UnitOfWork() => _context ??= new KoiConsultingContext();

        public UserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }
    }
}
