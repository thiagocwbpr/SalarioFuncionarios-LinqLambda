using System;
using System.IO;
using System.Collections.Generic;
using SalarioFuncionarios_LinqLambda.Entities;
using System.Linq;
using System.Globalization;

namespace SalarioFuncionarios_LinqLambda {
    internal class Program {
        static void Main(string[] args) {

            string path = @"C:\Apps C#\Employees.txt";

            List<Employee> employees = new List<Employee>();
            try {
            Console.Write("Enter Salary - R$: ");
            double SalaryInfo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("");

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] line = sr.ReadLine().Split(',');
                    string name = line[0];
                    string email = line[1];
                    double salary = double.Parse(line[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }
            var SalaryConsult = employees.Where(p => p.Salary >= SalaryInfo).Select(p => new { Nome = p.Name, p.Email, p.Salary }).DefaultIfEmpty();

            Console.WriteLine("Name and Email whose salary is 'more' than R$: 2000.00\n");

            foreach (var x in SalaryConsult) {
                Console.WriteLine(x);
            }
            Console.WriteLine("");
            var SumSalary = employees.Where(p => p.Salary >= SalaryInfo).Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people in the search: R$: " + SumSalary.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (Exception e) {
                Console.WriteLine("A error was reported!");
                Console.WriteLine(e);
            }
        }
    }
}
