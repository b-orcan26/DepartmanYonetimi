using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepartmanService : IService<Departman>
    {
        List<Departman> DepartmanWithPersonels();
    }
}
