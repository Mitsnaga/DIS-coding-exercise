using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIS_practical_exercise.models
{
    public class RateTable
    {
        public string Job { get; set; }
        public string Dept { get; set; }
        public DateTime Effective_Start { get; set; }
        public DateTime Effective_End { get; set; }
        public decimal Hourly_Rate { get; set; }
    }
}