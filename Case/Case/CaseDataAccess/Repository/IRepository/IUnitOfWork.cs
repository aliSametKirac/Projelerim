using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IKullaniciRepository Kullanici { get; }
        ISirketRepository Sirket { get; }

        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}