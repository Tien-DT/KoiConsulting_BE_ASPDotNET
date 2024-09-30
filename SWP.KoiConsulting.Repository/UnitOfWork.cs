using SWP.KoiConsulting.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP.KoiConsulting.Repository;

public class UnitOfWork : IDisposable
{
    private KoiConsultingContext _context;
    private GenericRepository<User> _user;
    private GenericRepository<Post> _post;

    public UnitOfWork(KoiConsultingContext context)
    {
        _context = context;
    }

    public  GenericRepository<Post> Posts
    {
        get
        {
            if(this._post == null)
            {
                this._post = new GenericRepository<Post>(_context);
            }
            return _post;
        }
    }

    public GenericRepository<User> Users
    {
        get
        {
            if (this._user == null)
            {
                this._user = new GenericRepository<User>(_context);
            }
            return _user;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
