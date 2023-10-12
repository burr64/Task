using Microsoft.EntityFrameworkCore;
using Task.DAL.Data;
using Task.DAL.Entities;

namespace Task.DAL.Interfaces;

public class OrdersRepository : IRepository<Orders>
{
    private readonly ApplicationDbContext _context;

    public OrdersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Orders> GetAll()
    {
        return _context.Orders.ToList();
    }

    public Orders Get(int id)
    {
        return _context.Orders.FirstOrDefault(m => m.Id == id);
    }

    public IEnumerable<Orders> Find(Func<Orders, bool> predicate)
    {
        return _context.Orders.Where(predicate);
    }

    public void Create(Orders orders)
    {
        _context.Add(orders);
        _context.SaveChanges();
    }

    public void Update(Orders orders)
    {
        _context.Update(orders);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var orders = _context.Orders.Find(id);
        if (orders != null)
        {
            _context.Orders.Remove(orders);
            _context.SaveChanges();
        }
    }
}