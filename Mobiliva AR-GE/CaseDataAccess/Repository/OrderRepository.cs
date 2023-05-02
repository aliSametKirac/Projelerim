using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using CaseModels.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository
{
    public class OrderRepository :Repository<Order>, IOrderRepository
    {
        private CaseDbContext _db;

        public OrderRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Order obj)
        {
            _db.Orders.Update(obj);
        }
    }
}
