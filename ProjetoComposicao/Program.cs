using System;
using System.Globalization;
using ProjetoComposicao.Entities.Enums;
using ProjetoComposicao.Entities;


namespace ProjetoComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter Worker Data:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior/): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine();
            Console.Write("Quantos contratos para esse trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Entre com o mês e ano, para calcular o ganho (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income " + month + "/" + year + " : $ " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
