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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private CaseDbContext _db;

        public ProductRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}