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
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        private CaseDbContext _db;

        public KullaniciRepository(CaseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Kullanici obj)
        {
            var objFromDb = _db.Kullanicis.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Adi = obj.Adi;
                objFromDb.Soyadi = obj.Soyadi;
                objFromDb.EMail = obj.EMail;
                objFromDb.Gorevi = obj.Gorevi;
                objFromDb.Sirket = obj.Sirket;
            }
        }
    }
}