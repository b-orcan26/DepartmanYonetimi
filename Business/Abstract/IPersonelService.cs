using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonelService : IService<Personel>
    {
        List<Personel> PersonelsWithDepatman();
    }
}
