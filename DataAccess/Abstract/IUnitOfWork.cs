using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IPersonelRepository Personeller { get; }
        IDepartmanRepository Departmanlar { get; }

        int Save();

        void Rollback();
    }
}
