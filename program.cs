using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    // Employee Class
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string fullName, string position, double salary)
        {
            Id = id;
            FullName = fullName;
            Position = position;
            Salary = salary;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id} | Ad: {FullName} | Vəzifə: {Position} | Maaş: {Salary} AZN");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== İŞÇİ İDARƏETMƏ SİSTEMİ =====");
                Console.WriteLine("1. İşçi əlavə et");
                Console.WriteLine("2. Bütün işçiləri göstər");
                Console.WriteLine("3. İşçini sil");
                Console.WriteLine("4. İşçini yenilə");
                Console.WriteLine("5. Axtarış et");
                Console.WriteLine("6. Maaşa görə filter");
                Console.WriteLine("0. Çıxış");

                Console.Write("Seçim et: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ShowAll();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        UpdateEmployee();
                        break;
                    case "5":
                        SearchEmployee();
                        break;
                    case "6":
                        FilterBySalary();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Yanlış seçim!");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.Write("Ad daxil et: ");
            string name = Console.ReadLine();

            Console.Write("Vəzifə daxil et: ");
            string position = Console.ReadLine();

            Console.Write("Maaş daxil et: ");
            if (!double.TryParse(Console.ReadLine(), out double salary))
            {
                Console.WriteLine("Yanlış maaş formatı!");
                return;
            }

            Employee emp = new Employee(idCounter++, name, position, salary);
            employees.Add(emp);

            Console.WriteLine("İşçi uğurla əlavə olundu!");
        }

        static void ShowAll()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Heç bir işçi yoxdur.");
                return;
            }

            foreach (var emp in employees)
            {
                emp.ShowInfo();
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Silmək istədiyin ID-ni daxil et: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Yanlış ID!");
                return;
            }

            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
            {
                Console.WriteLine("İşçi tapılmadı!");
                return;
            }

            employees.Remove(emp);
            Console.WriteLine("İşçi silindi.");
        }

        static void UpdateEmployee()
        {
            Console.Write("Yeniləmək istədiyin ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Yanlış ID!");
                return;
            }

            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
            {
                Console.WriteLine("İşçi tapılmadı!");
                return;
            }

            Console.Write("Yeni ad: ");
            emp.FullName = Console.ReadLine();

            Console.Write("Yeni vəzifə: ");
            emp.Position = Console.ReadLine();

            Console.Write("Yeni maaş: ");
            if (double.TryParse(Console.ReadLine(), out double salary))
                emp.Salary = salary;

            Console.WriteLine("Məlumatlar yeniləndi!");
        }

        static void SearchEmployee()
        {
            Console.Write("Axtarılacaq ad: ");
            string search = Console.ReadLine().ToLower();

            var results = employees.Where(e => e.FullName.ToLower().Contains(search)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("Tapılmadı.");
                return;
            }

            foreach (var emp in results)
            {
                emp.ShowInfo();
            }
        }

        static void FilterBySalary()
        {
            Console.Write("Minimum maaş: ");
            if (!double.TryParse(Console.ReadLine(), out double min))
            {
                Console.WriteLine("Yanlış format!");
                return;
            }

            var results = employees.Where(e => e.Salary >= min).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("Uyğun işçi yoxdur.");
                return;
            }

            foreach (var emp in results)
            {
                emp.ShowInfo();
            }
        }
    }
}
