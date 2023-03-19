using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.Repository
{
    public class ApplicationUserRepository : Repository<CaseDbContext>, IApplicationUserRepository
    {
        private CaseDbContext _db;

        public ApplicationUserRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

    }
}