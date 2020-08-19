using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class PersonelRepository : Repository<Personel>, IPersonelRepository
    {
        

        public PersonelRepository(DatabaseContext _db) : base(_db) 
        {
         
        }

        public List<Personel> PersonelsWithDepatman()
        {
            return db.personels.Include(x => x.Departman).ToList();
        }
    }
}
