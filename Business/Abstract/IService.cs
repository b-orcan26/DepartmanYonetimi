using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T> where T:class
    {
        bool AddData(T entity); 

        List<T> AllData(); 

        T GetDataById(int id); 

        bool UpdateData(T entity);  

        bool DeleteData(int id);  
    }
}
