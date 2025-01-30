using System;

//Create classes employee and manager. An employee will have attributes such as id , name, salary, dob. 
//A manager extends from an employee he will have additionally properties such as onsite allowance and bonus. 
//Compute the salary of an employee and manager.

namespace Tasks.Inheritance
{
    public class Employee
    {
        public int Id;
        public string? Name;
        public decimal Salary;
        public DateTime Dob;

        public virtual decimal ComputeSalary()
        {
            return Salary;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"DOB: {Dob.ToShortDateString()}");
            Console.WriteLine($"Salary: {ComputeSalary()}");
        }
    }
}
