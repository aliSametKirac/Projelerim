using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using CaseModels;

namespace CaseDataAccess.Repository
{
    public class SirketRepository : Repository<Sirket>, ISirketRepository
    {
        private CaseDbContext _db;

        public SirketRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Sirket obj)
        {
            _db.Sirkets.Update(obj);
        }
    }
}