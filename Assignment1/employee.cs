using System;
using System.IO;

class Employee
{
    public string Name { get; set; }
    public int Number { get; set; }
    public decimal Rate { get; set; }
    public double Hours { get; set; }
    public decimal Gross { get; private set; }

    public Employee(string name, int number, decimal rate, double hours)
    {
        Name = name;
        Number = number;
        Rate = rate;
        Hours = hours;
        CalculateGross();
    }

    public decimal GetGross()
    {
        return Gross;
    }

    public double GetHours()
    {
        return Hours;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetNumber()
    {
        return Number;
    }

    public decimal GetRate()
    {
        return Rate;
    }

    public override string ToString()
    {
        return $"{Name,-15} {Number,-10} {Rate,-10:C2} {Hours,-10:F2} {Gross,-10:C2}";
    }

    public void SetHours(double hours)
    {
        Hours = hours;
        CalculateGross();
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetNumber(int number)
    {
        Number = number;
    }

    public void SetRate(decimal rate)
    {
        Rate = rate;
        CalculateGross();
    }

    private void CalculateGross()
    {
        double regularHours = Hours <= 40 ? Hours : 40;
        double overtimeHours = Hours > 40 ? Hours - 40 : 0;
        Gross = (decimal)(regularHours * (double)Rate + overtimeHours * (1.5 * (double)Rate));
    }
}
