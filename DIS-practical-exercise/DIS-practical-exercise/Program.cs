using DIS_practical_exercise.models;
using DIS_practical_exercise.services;

var timecards = new List<TimeCard>
{
    // Kyle James
    new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 1), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },
    new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 2), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },
    new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 3), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },
    new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 4), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },
    new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 5), Earnings_Code = "Regular", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },
    new() { Employee_Name = "Kyle James", Employee_Number = "110011", Date_Worked = new DateTime(2023, 1, 6), Earnings_Code = "Overtime", Job_Worked = "Laborer", Dept_Worked = "001", Hours = 8, Rate = 15.5m, Bonus = 0 },

    // Jane Smith
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 1), Earnings_Code = "Regular", Job_Worked = "Scrapper", Dept_Worked = "002", Hours = 10, Rate = 17.65m, Bonus = 0 },
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 2), Earnings_Code = "Regular", Job_Worked = "Scrapper", Dept_Worked = "002", Hours = 10, Rate = 17.65m, Bonus = 0 },
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 3), Earnings_Code = "Regular", Job_Worked = "Scrapper", Dept_Worked = "002", Hours = 10, Rate = 17.65m, Bonus = 0 },
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 4), Earnings_Code = "Regular", Job_Worked = "Scrapper", Dept_Worked = "004", Hours = 10, Rate = 17.65m, Bonus = 0 },
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 5), Earnings_Code = "Overtime", Job_Worked = "Scrapper", Dept_Worked = "004", Hours = 6, Rate = 17.65m, Bonus = 0 },
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 6), Earnings_Code = "Overtime", Job_Worked = "Scrapper", Dept_Worked = "004", Hours = 6, Rate = 17.65m, Bonus = 0 },
    new() { Employee_Name = "Jane Smith", Employee_Number = "120987", Date_Worked = new DateTime(2023, 1, 7), Earnings_Code = "Double time", Job_Worked = "Scrapper", Dept_Worked = "004", Hours = 5, Rate = 17.65m, Bonus = 0 },

    // Amy Penn
    new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 1), Earnings_Code = "Regular", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 8, Rate = 17.75m, Bonus = 0 },
    new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 2), Earnings_Code = "Regular", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 12, Rate = 17.75m, Bonus = 0 },
    new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 3), Earnings_Code = "Regular", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 10, Rate = 17.75m, Bonus = 0 },
    new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 4), Earnings_Code = "Regular", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 10, Rate = 17.75m, Bonus = 0 },
    new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 5), Earnings_Code = "Overtime", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 5, Rate = 17.75m, Bonus = 125 },
    new() { Employee_Name = "Amy Penn", Employee_Number = "100002", Date_Worked = new DateTime(2023, 1, 6), Earnings_Code = "Overtime", Job_Worked = "Foreman", Dept_Worked = "003", Hours = 5, Rate = 17.75m, Bonus = 175 },

};

var rateTable = new List<RateTable>
{
    new() { Job = "Laborer", Dept = "001", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 18.75m },
    new() { Job = "Laborer", Dept = "002", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 17.85m },

    new() { Job = "Scrapper", Dept = "001", Effective_Start = new DateTime(2022, 1, 3), Effective_End = new DateTime(2023, 1, 3), Hourly_Rate = 19.45m },
    new() { Job = "Scrapper", Dept = "001", Effective_Start = new DateTime(2023, 1, 4), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 20.45m },

    new() { Job = "Scrapper", Dept = "002", Effective_Start = new DateTime(2022, 1, 3), Effective_End = new DateTime(2023, 1, 3), Hourly_Rate = 20.55m },
    new() { Job = "Scrapper", Dept = "002", Effective_Start = new DateTime(2023, 1, 4), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 21.60m },

    new() { Job = "Scrapper", Dept = "003", Effective_Start = new DateTime(2022, 1, 3), Effective_End = new DateTime(2023, 1, 3), Hourly_Rate = 22.15m },
    new() { Job = "Scrapper", Dept = "003", Effective_Start = new DateTime(2023, 1, 4), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 24.15m },

    new() { Job = "Foreman", Dept = "001", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 13.55m },
    new() { Job = "Foreman", Dept = "002", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 14.50m },
    new() { Job = "Foreman", Dept = "003", Effective_Start = new DateTime(2023, 1, 1), Effective_End = new DateTime(2024, 1, 1), Hourly_Rate = 15.60m },
};

var summaries = PayCalculator.Summarize_Pay_Info(timecards, rateTable);

foreach (var s in summaries)
{
    Console.WriteLine($"Name: {s.Employee_Name}, Earnings Code: {s.Earnings_Code}, Hours: {s.Total_Hours}, Pay: {s.Total_Pay_Amount:C}, Rate: {s.Rate_of_Pay:C}");
}