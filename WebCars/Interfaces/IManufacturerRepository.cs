using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCars.Models;

namespace WebCars.Interfaces
{
    public interface IManufacturerRepository
    {
        IQueryable<Manufacturer> GetAll();
        Manufacturer GetById(int id);
        void Add(Manufacturer manufacturer);
        bool Update(Manufacturer manufacturer);
        void Delete(Manufacturer manufacturer);
    }
}
