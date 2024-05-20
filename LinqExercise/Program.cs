using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers


            var sumOfNumbers = numbers.Sum();

            Console.WriteLine($"Sum:{sumOfNumbers}");


            //TODO: Print the Average of numbers


            var avgOfNumbers = numbers.Average();


            Console.WriteLine($"\nAverage:{avgOfNumbers}");


            //TODO: Order numbers in ascending order and print to the console
            var ascendOrder = numbers.OrderBy(x => x).ToArray();

            Console.WriteLine("\nAcending order:");
            PrintNumbers(ascendOrder);


            //TODO: Order numbers in descending order and print to the console

            var descendOrder = numbers.OrderByDescending(x => x).ToArray();

            Console.WriteLine("\nDescending order:");
            PrintNumbers(descendOrder);


            //TODO: Print to the console only the numbers greater than 6

            var greaterThan6 = numbers.Where(x => x > 6).ToArray();
            Console.WriteLine("\nNumbers greater than 6:");
            PrintNumbers(greaterThan6);

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            var ascendOrderShort = numbers.OrderBy(x => x).ToArray();
            var only4 = ascendOrderShort.Skip(6);
            Console.WriteLine("\n4 items: ");
            foreach (var x in only4)
            {
                Console.WriteLine(x);
            }


            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            var insertAge = numbers.Select((number, index) =>  index == 4? number = 27:number)
                .OrderByDescending(x => x).ToArray();
            Console.WriteLine("\nAge added to list");
            PrintNumbers(insertAge);

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
 Console.WriteLine("\nFirst name starts with S or C:");

            var firstNameCOrS = employees.Where(employee => employee.FirstName.StartsWith('S') || employee.FirstName.StartsWith('C')).OrderBy(employee => employee.FirstName).ToList();

            foreach (var employee in firstNameCOrS)

            {
                Console.WriteLine($"{employee.FullName} Age: {employee.Age}");
            }






            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var olderThan26 = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName).ToList();



            Console.WriteLine("\nOlder Than 26:");
            foreach (var employee in olderThan26)

            {
                Console.WriteLine($"{employee.FullName} Age: {employee.Age}");
            }

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var YOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).ToList();

            Console.WriteLine($"\nTotal years of experience: {YOE.Sum(x => x.YearsOfExperience)}");



            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine($"\nAverage years of experience: {YOE.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()


            employees = employees.Append(new Employee("Kaitlyn", "Thomas", 27, 6)).ToList();

            employees.ForEach(person => Console.WriteLine(person.FullName));

      
            Console.WriteLine();

            Console.ReadLine();
        }
         public static void PrintNumbers(int[] array)
            {

                foreach (var number in array)
                {
                    Console.WriteLine($"{number}");
                }

            }
        
        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
