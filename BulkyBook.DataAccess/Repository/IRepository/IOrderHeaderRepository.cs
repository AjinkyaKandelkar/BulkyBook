using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository: IRepository<OrderHeader>
    {
        void Update(OrderHeader Obj);
        void UpdateStatus(int id, string orderstatus, string? paymentstatus=null);

        public void UpdateStripPayment(int id, string SessionId, string PaymentIntent);

        List<OrderHeader> Getall();
    }
}
