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
            var objFromDb = _db.Books.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null) 
            { 
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Author = obj.Author;
                objFromDb.Price = obj.Price;
            }
        }
    }
}