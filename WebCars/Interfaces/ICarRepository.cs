using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCars.Models;

namespace WebCars.Interfaces
{
    public interface ICarRepository
    {
        IQueryable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        bool Update(Car car);
        void Delete(Car car);
    }
}
