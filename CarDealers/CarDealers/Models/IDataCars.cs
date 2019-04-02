 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealers.Models
{
    public class IDataCars : IMockCars
    {
        //db connection
        private DbModel db = new DbModel();
        public IQueryable<car> Cars { get { return db.cars; } }

        public void Delete(car car)
        {
            db.cars.Remove(car);
            db.SaveChanges();
        }

        public car Save(car car)
        {
            if(car.carno == 0)
            {
                db.cars.Add(car);
            }
            else
            {
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return car;

        }
        public void Dispose()
        {
            db.Dispose();
        }

        public car save(car car)
        {
            throw new NotImplementedException();
        }
    }
}