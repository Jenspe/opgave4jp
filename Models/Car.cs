using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opgave4jp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string LicensePlate { get; set; }

        public Car()
        {
        }

        //public string Model
        //{
        //    get => _model;
        //    set
        //    {
        //        if (value == null) throw new ArgumentNullException(nameof(value));
        //        if (value.Length < 4) throw new ArgumentException(message: "Model name must be at least 4 characters long");
        //        _model = value;
        //    }
        //}

        //public int Price
        //{
        //    get => _price;
        //    set
        //    {
        //        if (value < 0) throw new ArgumentOutOfRangeException(paramName: "Price", value, message: "We gotta make a profit, look at that price");
        //        _price = value;
        //    }

        //}

        //public string LicensePlate
        //{
        //    get => _licensePlate;
        //    set
        //    {
        //        if (value == null) throw new ArgumentNullException(nameof(value));
        //        if (value.Length < 2 || value.Length < 7) throw new ArgumentOutOfRangeException(nameof(value));
        //        _licensePlate = value;
        //    }
        //}

        public Car(int id, string model, int price, string licensePlate)
        {
            Id = id;
            Model = model;
            Price = price;
            LicensePlate = licensePlate;
        }

        public override string ToString()
        {
            return $"Id:{Id} Model:{Model} Price:{Price} LicensePlate:{LicensePlate}";
        }


    }
}
