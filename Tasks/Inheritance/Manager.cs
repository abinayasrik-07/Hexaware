using System;
using Tasks.Inheritance;

namespace Tasks
{

    public class Manager : Employee
    {
         public decimal OnsiteAllowance;
        public decimal Bonus;

        public override decimal ComputeSalary()
        {
            return Salary + OnsiteAllowance + Bonus;
        }
    }
}
