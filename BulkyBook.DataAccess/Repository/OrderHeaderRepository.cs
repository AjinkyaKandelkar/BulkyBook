using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        ApplicationDBContext _db;

        public OrderHeaderRepository( ApplicationDBContext db ):base(db)
        {
            _db = db;
        }

        public List<OrderHeader> Getall()
        {
            return _db.OrderHeaders.ToList();
        }

        public void Update(OrderHeader Obj)
        {
            _db.OrderHeaders.Update( Obj );
        }

        public void UpdateStatus(int id, string orderstatus, string? paymentstatus = null)
        {
            var OrderFromDb = _db.OrderHeaders.FirstOrDefault( o => o.Id == id );
            if( OrderFromDb != null )
            {
                OrderFromDb.OrderStatus = orderstatus;
                if( paymentstatus != null )
                {
                    OrderFromDb.PaymentStatus = paymentstatus;
                   
                }
            }
        }
        public void UpdateStripPayment(int id, string SessionId, string PaymentIntent)
        {
            var OrderFromDb = _db.OrderHeaders.FirstOrDefault(o => o.Id == id);
            OrderFromDb.SessionId =SessionId;
            OrderFromDb.PaymentIntentId =PaymentIntent;
            OrderFromDb.PaymentDate = DateTime.Now;
        }
    }
}
