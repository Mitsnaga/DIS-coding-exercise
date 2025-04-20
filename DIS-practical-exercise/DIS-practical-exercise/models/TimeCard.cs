using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIS_practical_exercise.models
{
    public class TimeCard
    {
        public string Employee_Name { get; set; }
        public string Employee_Number { get; set; }
        public DateTime Date_Worked { get; set; }
        public string Earnings_Code { get; set; }
        public decimal Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal Bonus { get; set; }
    }
}