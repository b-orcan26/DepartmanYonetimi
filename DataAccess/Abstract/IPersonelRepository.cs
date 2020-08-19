using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPersonelRepository : IRepository<Personel>
    {
        List<Personel> PersonelsWithDepatman();
    }
}
