using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using CaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CaseDbContext _db;

        public UnitOfWork(CaseDbContext db)
        {
            _db = db;
            OrderDetail = new OrderDetailRepository(_db);
            Order = new OrderRepository(_db);
            Product = new ProductRepository(_db);
        }

        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IProductRepository Product { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}