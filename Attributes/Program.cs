using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Customer customer = new Customer {Id=1,FirstName="Ahmet",Age=35 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }
    [ToTable("Customers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }

    }

    class CustomerDal
    {
        [Obsolete("Dont use this method instead use AddNew Method")]
        public void Add(Customer customer)
        {
            Console.WriteLine($"ID : {customer.Id}\nFirstname : {customer.FirstName}\nLastname :{customer.LastName}\nAge : {customer.Age}");
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine($"ID : {customer.Id}\nFirstname : {customer.FirstName}\nLastname :{customer.LastName}\nAge : {customer.Age}");
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class RequiredPropertyAttribute:Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class)]
    class ToTableAttribute : Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tablename)
        {
            _tableName = tablename;
        }
    }

}
