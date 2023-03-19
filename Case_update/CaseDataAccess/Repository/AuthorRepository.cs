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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private CaseDbContext _db;

        public AuthorRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Author obj)
        {
            _db.Authors.Update(obj);
        }
    }
}