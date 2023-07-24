using ClassLibraryCustomer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnitTestDailyExercise
{
    [TestClass]
    public class CustomerTestClass
    {
        private Customer customer;
        [TestInitialize]
        public void Setup()
        {
            customer = new Customer()
            { Id = 43, Name = "harshal" };

        }

        [TestMethod]
        public void TestSerilization()
        {
            IFormatter formatter = new BinaryFormatter();
            string filepath = "C:\\New folder\\Day11\\Customer\\harsh_30-07-2000";
            using(FileStream fs=new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, customer);
            }

            using(FileStream fs=new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                Customer desCustoemr=(Customer)formatter.Deserialize(fs);
                Assert.AreEqual(customer.Id, desCustoemr.Id);
                Assert.AreEqual(customer.Name, desCustoemr.Name);
            }
        }
    }
}
