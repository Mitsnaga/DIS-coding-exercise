using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIS_practical_exercise.models
{
    public class PaySummary
    {
        public string Employee_Name { get; set; }
        public string Employee_Number { get; set; }
        public string Earnings_Code { get; set; }
        public decimal Total_Hours { get; set; }
        public decimal Total_Pay_Amount { get; set; }
        public decimal Rate_of_Pay { get; set; }
        public string Job { get; set; }
        public string Dept { get; set; }
    }
}