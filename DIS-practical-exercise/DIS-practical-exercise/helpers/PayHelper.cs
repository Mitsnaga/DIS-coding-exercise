using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIS_practical_exercise.models;

namespace DIS_practical_exercise.helpers
{
    public class PayHelper
    {

        public static decimal GetMaxRate(TimeCard record, List<RateTable> rateTable)
        {
            // Getting the latest hourly rate for each employee
            // Depending on the type of job, department and 
            // Checking if they fall into the effective time range
            var Rate = rateTable.Where(r =>
            r.Dept == record.Dept_Worked &&
            r.Job == record.Job_Worked &&
            r.Effective_End >= record.Date_Worked &&
            r.Effective_Start <= record.Date_Worked)
            .OrderByDescending(r => r.Effective_Start)
            .FirstOrDefault()?.Hourly_Rate ?? 0;

            // Returning whichever rate is higher (base or effective)
            return Math.Max(record.Rate, Rate);

        }

        // Pay calculation for one record
        public static decimal CalculatePay(decimal hours, decimal maxRate, decimal payCodeRule, decimal bonus)
        {
            return (hours * maxRate * payCodeRule) + bonus;
        }
    }
}