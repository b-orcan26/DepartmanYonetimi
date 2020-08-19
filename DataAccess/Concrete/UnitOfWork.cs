using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext db;

        public IPersonelRepository Personeller { get; }

        public IDepartmanRepository Departmanlar { get; }

        public UnitOfWork(DatabaseContext _db)
        {
            db = _db;
            Personeller = new PersonelRepository(_db);
            Departmanlar = new DepartmanRepository(_db);
        }
        public int Save()
        {
            return db.SaveChanges();
        }

        public void Rollback()
        {
            db.Dispose();
        }

    }
}
