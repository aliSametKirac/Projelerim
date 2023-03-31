using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using CaseModels;

namespace CaseDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CaseDbContext _db;

        public UnitOfWork(CaseDbContext db)
        {
            _db = db;
            Kullanici = new KullaniciRepository(_db);
            Sirket = new SirketRepository(_db);

            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public IKullaniciRepository Kullanici { get; private set; }
        public ISirketRepository Sirket { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}