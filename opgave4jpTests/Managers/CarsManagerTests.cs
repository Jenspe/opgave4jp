using Microsoft.VisualStudio.TestTools.UnitTesting;
using opgave4jp.Managers;
using opgave4jp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave4jp.Managers.Tests
{
    [TestClass()]
    public class CarsManagerTests
    {
        private CarsManager _manager;

        [TestInitialize]
        public void Inti()
        {
            _manager = new CarsManager();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_manager.GetAll(null, 1000));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_manager.GetById(1));
            Assert.IsNull(_manager.GetById(0));
            string _expectedModel;
            Assert.AreEqual(_expectedModel = "Hyundai", _manager.GetById(1).Model);
            int _expectedPrice;
            Assert.AreEqual(_expectedPrice = 300, _manager.GetById(1).Price);
        }

        [TestMethod()]
        public void AddAndDeleteCarTest()
        {
            //Reads the count before adding so we can compare it to the number after adding
            int beforeAddCount = _manager.GetAll().Count;
            //creates a variable with the Id we assign, should be overridden when the manager add the Car
            int defaultId = 0;
            //Creates a testCar to be added
            Car newCar = new Car(defaultId, "TestCar", 300, "TestPlate");
            //Adding the Car, and storing the result in a variable
            Car addResult = _manager.AddCar(newCar);
            //stores the newly assigned Id
            int newID = addResult.Id;
            //Checking that the manager assigns a new ID
            Assert.AreNotEqual(defaultId, newID);
            //Checking that the count of the list is now 1 more than before
            Assert.AreEqual(beforeAddCount + 1, _manager.GetAll().Count);

            //checks that the ID of the deleted Car is the same that we asked to be deleted
            Car deletedCar = _manager.Delete(newID);
            //checks that the count is now the same as when we began before adding and deleting
            Assert.AreEqual(beforeAddCount, _manager.GetAll().Count);

            //checks that if we ask to delete an Car with an Id that doesn't exist, that it returns null
            Assert.IsNull(_manager.Delete(400));
        }

    }
}