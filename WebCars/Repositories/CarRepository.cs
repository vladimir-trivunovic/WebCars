using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCars.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebCars.Models;

namespace WebCars.Repositories
{
    public class CarRepository : IDisposable, ICarRepository
    {
        private DataContext _dataContext;

        public CarRepository(DataContext dataContext)
        {
            _dataContext = dataContext;

            if (_dataContext.Cars.Count() == 0)
            {
                _dataContext.Cars.Add(new Car { YearOfProduction = 2008, Engine = "1.4 benzin", Color = "crna", ManufacturerId = 1 });
                _dataContext.SaveChanges();
            }
        }


        //----------------------------- GET --------------------------------------------------

        public IQueryable<Car> GetAll()
        {
            return _dataContext.Cars;
        }



        public Car GetById(int id)
        {
            return _dataContext.Cars.Include(c => c.Manufacturer).SingleOrDefault(c => c.Id == id);
        }


        //----------------------------- CUD --------------------------------------------------

        public void Add(Car car)
        {
            _dataContext.Cars.Add(car);
            _dataContext.SaveChanges();
        }



        public void Delete(Car car)
        {
            _dataContext.Cars.Remove(car);
            _dataContext.SaveChanges();
        }



        public bool Update(Car car)
        {
            _dataContext.Entry(car).State = EntityState.Modified;

            try
            {
                _dataContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }



        //----------------------------- Dispose --------------------------------------------------

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
