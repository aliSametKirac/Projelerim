using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;

namespace CaseDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CaseDbContext _db;

        public UnitOfWork(CaseDbContext db)
        {
            _db = db;
            Author = new AuthorRepository(_db);
            Book = new BookRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public IAuthorRepository Author { get; set; }
        public IBookRepository Book { get; set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}