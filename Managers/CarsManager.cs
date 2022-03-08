using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using opgave4jp.Models;

namespace opgave4jp.Managers
{
    public class CarsManager
    {
        private static int _nextId = 1;
        //Creates the list of Cars and fills it with 3 Cars to begin with
        //The 3 Cars is only for testing purposes
        private static readonly List<Car> Data = new List<Car>
        {
            new Car {Id = _nextId++, Model = "Hyundai", Price = 300, LicensePlate = "heyo"},
            new Car {Id = _nextId++, Model = "SharpMobil", Price = 100, LicensePlate ="heyo2"},
            new Car {Id = _nextId++, Model = "Opel", Price = 120, LicensePlate ="h222"},
            new Car {Id = _nextId++, Model = "CMobil", Price = 50, LicensePlate ="heyo3"}
        };

        //Returns all Cars in the List, in a new List
        public List<Car> GetAll(string substring = null, int maxPrice = 1000)
        {
            List<Car> result = new List<Car>(Data);
            if (!string.IsNullOrEmpty(substring))
            {
                result = Data.FindAll(car => car.Model.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }

            if (maxPrice != null)
            {
                result = result.FindAll(c => c.Price >= maxPrice);
            }

            return result;
        }

        //Returns a specific Car from the list
        //return null if the id is not found
        public Car GetById(int id)
        {
            return Data.Find(car => car.Id == id);
        }

        //Adds a new Car to the list, and assigns it the next id
        //returns the newly added Car
        public Car AddCar(Car newCar)
        {
            newCar.Id = _nextId++;
            Data.Add(newCar);
            return newCar;
        }

        //Deletes the Car from the list with the specific Id
        //Returns null of no Car has the Id
        public Car Delete(int id)
        {
            Car Car = Data.Find(Car1 => Car1.Id == id);
            if (Car == null) return null;
            Data.Remove(Car);
            return Car;
        }

    }
}
