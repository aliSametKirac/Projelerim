using CaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository.IRepository
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        void Update(Kullanici obj);
    }
}
