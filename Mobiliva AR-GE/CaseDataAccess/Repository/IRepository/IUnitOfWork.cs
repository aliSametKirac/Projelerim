using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrderDetailRepository OrderDetail { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }

        void Save();
    }
}
