using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class DepartmanRepository : Repository<Departman>, IDepartmanRepository
    {
        

        public DepartmanRepository(DatabaseContext _db) : base(_db)
        {
           
        }
        public List<Departman> DepartmanWithPersonels()
        {
            return db.departmans.Include(x => x.personels).ToList();
        }
    }
}
