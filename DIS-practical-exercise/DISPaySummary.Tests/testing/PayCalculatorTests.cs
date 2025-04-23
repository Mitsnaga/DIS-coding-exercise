using System;
using System.Collections.Generic;
using Xunit;
using DIS_practical_exercise.models;
using DIS_practical_exercise.services;

namespace DISPaySummary.Tests
{
    public class PayCalculatorTests
    {
        // Normal scenario - One record of overtime and regular time
        [Fact]
        public void SummarizePayInfo_CorrectSummary_KyleJames()
        {
            var timecards = new List<TimeCard>
            {
                new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 1), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },
                new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 6), Earnings_Code = "Overtime", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 }
            };

            var rateTable = new List<RateTable>
            {
                new() { Job = "Laborer", Dept = "001", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 18.75m }
            };

            var result = PayCalculator.Summarize_Pay_Info(timecards, rateTable);

            Assert.Equal(2, result.Count);

            var regular = result.Find(r => r.Earnings_Code == "Regular");
            Assert.Equal(8, regular.Total_Hours);
            Assert.Equal(150.00m, regular.Total_Pay_Amount);

            var overtime = result.Find(r => r.Earnings_Code == "Overtime");
            Assert.Equal(8, overtime.Total_Hours);
            Assert.Equal(225.00m, overtime.Total_Pay_Amount);
        }

        // Scenario where the effective rate is Higher
        [Fact]
        public void SummarizePayInfo_HigherRate()
        {
            var timecards = new List<TimeCard>
            {
                new() { Employee_Name = "Test User", Employee_Number = "000001", Date_Worked = new DateTime(2023, 1, 1), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 10, Rate = 20.0m, Bonus = 0 }
            };

            var rateTable = new List<RateTable>
            {
                new() { Job = "Laborer", Dept = "001", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 18.75m }
            };

            var result = PayCalculator.Summarize_Pay_Info(timecards, rateTable);
            var summary = result[0];

            Assert.Equal(10, summary.Total_Hours);
            Assert.Equal(200.00m, summary.Total_Pay_Amount);
            Assert.Equal(20.00m, summary.Rate_of_Pay);
        }

        // Scenario where the employee has a bonus to be added to the final pay
        [Fact]
        public void SummarizePayInfo_AddBonus()
        {
            var timecards = new List<TimeCard>
            {
                new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 5), Earnings_Code = "Overtime", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 5, Rate = 17.75m, Bonus = 125 }
            };

            var rateTable = new List<RateTable>
            {
                new() { Job = "Foreman", Dept = "003", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 15.60m }
            };

            var result = PayCalculator.Summarize_Pay_Info(timecards, rateTable);
            var summary = result[0];

            Assert.Equal(5, summary.Total_Hours);
            Assert.Equal((17.75m * 1.5m * 5) + 125, summary.Total_Pay_Amount);
        }
    }
}
