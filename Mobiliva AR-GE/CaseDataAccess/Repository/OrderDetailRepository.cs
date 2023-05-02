using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using CaseModels.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private CaseDbContext _db;

        public OrderDetailRepository(CaseDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(OrderDetail obj)
        {
            var objFromDb = _db.OrderDetails.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null) 
            {
                objFromDb.UnitPrice = obj.UnitPrice;
                objFromDb.Order = obj.Order;
                objFromDb.Product = obj.Product;
            }
        }
    }
}
