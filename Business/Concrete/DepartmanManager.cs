using Business.Abstract;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepartmanManager : IDepartmanService
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmanManager()
        {
            unitOfWork = new UnitOfWork(new DatabaseContext());
        }

        public bool AddData(Departman entity)
        {
            return unitOfWork.Departmanlar.AddData(entity);
        }

        public List<Departman> AllData()
        {
            return unitOfWork.Departmanlar.AllData();
        }

        public bool DeleteData(int id)
        {
            return unitOfWork.Departmanlar.DeleteData(id);
        }

        public List<Departman> DepartmanWithPersonels()
        {
            return unitOfWork.Departmanlar.DepartmanWithPersonels();
        }

        public Departman GetDataById(int id)
        {
            if (id > 1)
            {
                return unitOfWork.Departmanlar.GetDataById(id);
            }
           
                throw new Exception("id 1'den kucuk olamaz");
            
        }

        public bool UpdateData(Departman entity)
        {
            return unitOfWork.Departmanlar.UpdateData(entity);
        }
    }
}
