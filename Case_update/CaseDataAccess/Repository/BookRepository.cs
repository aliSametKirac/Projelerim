using CaseDataAccess.Data;
using CaseDataAccess.Repository.IRepository;
using CaseModels;

namespace CaseDataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private CaseDbContext _db;

        public BookRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book obj)
        {
            _db.Books.Add(obj);
        }
    }
}