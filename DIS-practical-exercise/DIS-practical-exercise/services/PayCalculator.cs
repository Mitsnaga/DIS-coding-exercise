using DIS_practical_exercise.models;
using DIS_practical_exercise.helpers;

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

                    decimal maxRate = PayHelper.GetMaxRate(record, rateTable);

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

                    decimal pay = PayHelper.CalculatePay(record.Hours, maxRate, payCodeRule, record.Bonus);
                    finalPay += pay;

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

