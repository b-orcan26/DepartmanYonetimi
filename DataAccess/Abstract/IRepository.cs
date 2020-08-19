using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRepository<T> where T:class
    {
        bool AddData(T entity); // ekleme

        List<T> AllData(); // veri cekme

        T GetDataById(int id); // id ile veri cekme

        bool UpdateData(T entity);  // veri güncelleme 

        bool DeleteData(int id);  // veri silme
    }
}
