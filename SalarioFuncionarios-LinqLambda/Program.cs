using System;
using System.IO;

namespace SalarioFuncionarios_LinqLambda {
    internal class Program {
        static void Main(string[] args) {

            string path = @"C:\Apps C#\Employees.txt";

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] line = sr.ReadLine().Split(',');
                    string name = line[0];
                    string email = line[1];
                    double salary = double.Parse(line[2]);
                }
            }
        }
    }
}
