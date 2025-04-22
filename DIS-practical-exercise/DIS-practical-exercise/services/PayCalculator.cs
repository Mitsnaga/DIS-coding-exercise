using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using DIS_practical_exercise.models;
using Microsoft.VisualBasic;

namespace DIS_practical_exercise.services
{
    public class PayCalculator
    {
        public static List<PaySummary> Summarize_Pay_Info(List<TimeCard> timecards, List<RateTable> rateTable)
        {

            List<PaySummary> Result = [];

            // grouping by the following fields to create unique keys
            var groups = timecards.GroupBy(x => new
            {
                x.Employee_Name,
                x.Employee_Number,
                x.Earnings_Code,
                x.Job_Worked,
                x.Dept_Worked
            });

            // Looping through the groups
            foreach (var group in groups)
            {

                decimal totalHours = 0;
                decimal finalPay = 0;

                // Looping through the groups with multiple records
                // the group key can have different signatures for the same person
                // if the payCodeRule is different for example
                foreach (var record in group)
                {
                    // calculating the total hours for each employee
                    totalHours += record.Hours;

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

                    // Checking which rate is higher (base or effective)
                    decimal maxRate = Math.Max(record.Rate, Rate);

                    // Converting the multiplyer wording in to numbers
                    decimal payCodeRule = 0;
                    switch (record.Earnings_Code)
                    {
                        case "Regular":
                            payCodeRule = 1.0m;
                            break;
                        case "Overtime":
                            payCodeRule = 1.5m;
                            break;
                        case "Double time":
                            payCodeRule = 2.0m;
                            break;
                    }

                    finalPay += record.Hours * maxRate * payCodeRule;

                }

                // Generating the pay summary output
                Result.Add(new PaySummary
                {
                    Employee_Name = group.Key.Employee_Name,
                    Employee_Number = group.Key.Employee_Number,
                    Earnings_Code = group.Key.Earnings_Code,
                    Total_Hours = totalHours,
                    Total_Pay_Amount = finalPay,
                    Rate_of_Pay = finalPay / totalHours,
                    Job = group.Key.Job_Worked,
                    Dept = group.Key.Dept_Worked
                });
            }

            return Result;
        }

    }
}

