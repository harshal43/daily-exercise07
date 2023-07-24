using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibraryCustomer;

namespace ConAppDailyExercise02
{
    internal class Program
    {
        static string path = @"C:\New folder\Day11\Customer\";
        static string fpath;
        static Customer customer = new Customer();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter name...");
            string name = Console.ReadLine();
            Console.WriteLine("Enter DOB...");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            fpath = path + name + "_" + dob.ToShortDateString()+".txt";

            Console.WriteLine("Enter the following action:\n1. Read Method\n2. Write Method");
            int ch = int.Parse(Console.ReadLine());

            switch(ch){
                case 1:
                    {
                        WriteMethod();
                        break;
                    }
                    case 2:
                    {
                        ReadMethod(); break;
                    }
                    default:
                    {
                        Console.WriteLine("Wrong!!!");
                        break;
                    }
            }
            ReadMethod();

            Console.ReadKey();
        }

        public static void WriteMethod()
        {
            
            try
            {

                Console.WriteLine("Enter customer Id...");
                customer.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter customer Name...");
                customer.Name = Console.ReadLine();
                Console.WriteLine("Enter customer city...");
                customer.City = Console.ReadLine();
                Console.WriteLine("Enter customer address...");
                customer.City = Console.ReadLine();
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(fpath, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, customer);
                Console.WriteLine("Written inside file");
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! "+ex.Message);
            }
        }

        public static void ReadMethod()
        {
            try
            {
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                customer = (Customer)formatter.Deserialize(stream);
                Console.WriteLine("Person Id " + customer.Id);
                Console.WriteLine("Person Name " + customer.Name);
                Console.WriteLine("Person City " + customer.City);
                Console.WriteLine("Person Address " + customer.Address);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                Console.WriteLine("End of program");
                Console.ReadKey();
            }
        }
    }
}
