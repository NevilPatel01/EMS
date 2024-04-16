using System;
using System.IO;
using System.Linq;

class Lab1
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Sort by Employee Name (Ascending)");
            Console.WriteLine("2. Sort by Employee Number (Ascending)");
            Console.WriteLine("3. Sort by Employee Pay Rate (Descending)");
            Console.WriteLine("4. Sort by Employee Hours (Descending)");
            Console.WriteLine("5. Sort by Employee Gross Pay (Descending)");
            Console.WriteLine("6. Exit");
            Console.Write("Choose any option from above (1-6): ");
            string inp = Console.ReadLine();

            if (int.TryParse(inp, out int choose))
            {
                switch (choose)
                {
                    case 1:
                        SortEmployee("name");
                        break;
                    case 2:
                        SortEmployee("number");
                        break;
                    case 3:
                        SortEmployee("rate");
                        break;
                    case 4:
                        SortEmployee("hours");
                        break;
                    case 5:
                        SortEmployee("gross");
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Enter an integer from 1 to 6");
            }
        }
    }

    static void SortEmployee(string detailType)
    {
        Employee[] employees = ReadDataEmployees();

        if (employees != null)
        {
            switch (detailType)
            {
                case "name":
                    employees = employees.Where(emp => emp != null).OrderBy(emp => emp.Name).ToArray();
                    break;
                case "number":
                    employees = employees.Where(emp => emp != null).OrderBy(emp => emp.Number).ToArray();
                    break;
                case "rate":
                    employees = employees.Where(emp => emp != null).OrderByDescending(emp => emp.Rate).ToArray();
                    break;
                case "hours":
                    employees = employees.Where(emp => emp != null).OrderByDescending(emp => emp.Hours).ToArray();
                    break;
                case "gross":
                    employees = employees.Where(emp => emp != null).OrderByDescending(emp => emp.Gross).ToArray();
                    break;
                default:
                    Console.WriteLine("Invalid sorting criterion.");
                    return;
            }

            Console.WriteLine($"Employees sorted by {detailType} (ascending/descending):");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Name\t\tEmployee Number\t\tPay Rate\tHours Worked\tGross Pay");

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}\t\t{employee.Number}\t\t{employee.Rate:C}\t\t{employee.Hours:F1}\t\t{employee.Gross:C}");
            }
        }
    }

    static Employee[] ReadDataEmployees()
    {
        string filePath = "N:\\Mohawk College\\Semester 3\\DOTNET\\Assignment1\\Assignment1\\employees.txt";
        try
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                var employees = new Employee[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');

                    if (data.Length == 4)
                    {
                        string name = data[0].Trim();
                        if (int.TryParse(data[1], out int employeeNumber) &&
                            decimal.TryParse(data[2], out decimal payRate) &&
                            double.TryParse(data[3], out double hoursWorked))
                        {
                            employees[i] = new Employee(name, employeeNumber, payRate, hoursWorked);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data on line {i + 1}. Skipping this entry.");
                    }
                }

                return employees;
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An IO error occurred while reading the file: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }

        return null;
    }
}
