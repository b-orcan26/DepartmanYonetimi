using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext db;
        public DbSet<T> table;

        public Repository(DatabaseContext _db)
        {
            db = _db;
            table = db.Set<T>();
        }

        public bool AddData(T entity)
        {
            table.Add(entity);
            return Save();
        }

        public bool DeleteData(int id)
        {
            var data = GetDataById(id);
            table.Remove(data);
            return Save();
        }

        public List<T> AllData()
        {
            return table.ToList();
        }

        public T GetDataById(int id)
        {
            return table.Find(id);
        }

        public bool UpdateData(T entity)
        {
            table.Update(entity);
            return Save();
        }

        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
