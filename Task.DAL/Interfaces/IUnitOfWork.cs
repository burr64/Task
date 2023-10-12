using Task.DAL.Entities;

namespace Task.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Users> Users { get;}
    IRepository<Orders> Orders { get;}
    void Save();
}