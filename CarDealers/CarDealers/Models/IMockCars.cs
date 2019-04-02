using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealers.Models
{
    public interface IMockCars
    {
        IQueryable<car> Cars{get;}
        car Save(car car);
        void Delete(car car);
        void Dispose();
    }
}
