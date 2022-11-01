using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public readonly ApplicationDBContext _db;
        public ShoppingCartRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart cart, int Count)
        {
            cart.Count-= Count;
            return cart.Count;
        }

        public int IncrementCount(ShoppingCart cart, int Count)
        {
            cart.Count+= Count;
            return cart.Count;
        }
    }
}
