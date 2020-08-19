using Business.Abstract;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IUnitOfWork unitOfWork;
        public PersonelManager()
        {
            unitOfWork = new UnitOfWork(new DatabaseContext());
        }
        public bool AddData(Personel entity)
        {
            return unitOfWork.Personeller.AddData(entity);
        }

        public List<Personel> AllData()
        {
            return unitOfWork.Personeller.AllData();
        }

        public bool DeleteData(int id)
        {
            return unitOfWork.Personeller.DeleteData(id);
        }

        public Personel GetDataById(int id)
        {
            return unitOfWork.Personeller.GetDataById(id);
        }

        public List<Personel> PersonelsWithDepatman()
        {
            var liste = unitOfWork.Personeller.PersonelsWithDepatman();
            return liste;
        }

        public bool UpdateData(Personel entity)
        {
            return unitOfWork.Personeller.UpdateData(entity);
        }
    }
}
