using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCars.Interfaces;
using WebCars.Models;
using Microsoft.EntityFrameworkCore;

namespace WebCars.Repositories
{
    public class ManufacturerRepository : IDisposable, IManufacturerRepository
    {
        private DataContext _dataContext;

        public ManufacturerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;

            if (_dataContext.Manufacturers.Count() == 0)
            {
                _dataContext.Manufacturers.Add(new Manufacturer { Name = "Seat" });
                _dataContext.SaveChanges();
            }
        }


        //----------------------------- GET --------------------------------------------------

        public IQueryable<Manufacturer> GetAll()
        {
            return _dataContext.Manufacturers;
        }



        public Manufacturer GetById(int id)
        {
            return _dataContext.Manufacturers.Find(id);
        }
        

        //----------------------------- CUD --------------------------------------------------

        public void Add(Manufacturer manufacturer)
        {
            _dataContext.Manufacturers.Add(manufacturer);
            _dataContext.SaveChanges();
        }



        public void Delete(Manufacturer manufacturer)
        {
            _dataContext.Manufacturers.Remove(manufacturer);
            _dataContext.SaveChanges();
        }



        public bool Update(Manufacturer manufacturer)
        {
            _dataContext.Entry(manufacturer).State = EntityState.Modified;

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
