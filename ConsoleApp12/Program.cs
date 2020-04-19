using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp12
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //UnManagedException();
            //DividedByZeroException();
            //ExceptionFilter();
            //CallCustomException();
            //FailFast();
            //DefensiveTest(-100,"jksjdklas.");
        }

        private static void DefensiveTest(int age,string name)
        {
           if(age<0 || age>150)
            {
                throw new Exception("Invalid Age");
            }
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (!regex.IsMatch(name))
                throw new Exception("Name is Invalid");
        }

        private static void ExceptionFilter()
        {
            int a = 7;
            bool even = a % 2 == 0;
            try
            {
               var temp= a / 0;
            }
            catch (Exception e)when (even)
            {

                Console.WriteLine($"{a} is even!  "+e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine($"{a} is odd! " +e.Message);

            }
        }

        private static void UnManagedException()
        {
            var file = File.ReadAllLines("2.txt");
            try
            {
                foreach (var item in file)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void CallCustomException()
        {
            try
            {
                Console.Write("Enter UserName: ");
                var student = new Student
                {
                    StudentId = 1,
                    UserName = Console.ReadLine()
                };
                ValidateUsername(student);
                Console.WriteLine($"Hooray! your username {student.UserName} is valid");
            }
            catch (UserNameException exp)
            {
                Console.Write(exp.InnerException);
                Console.WriteLine(exp.Message);
            }
        }

        public static void ValidateUsername(Student student)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (!regex.IsMatch(student.UserName))
                throw new UserNameException(student.UserName);
        }

        private static void FailFast()
        {
            string message = "Terminated by Rebwar because of nothing!!";
            try
            {
                Environment.FailFast(message);
            }
            finally
            {
                Console.WriteLine("OOps");
            }
        }   

        private static void DividedByZeroException()
        {
            double a, b, c;
            Console.Write("Enter First Number:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Second Number:");
            b = Convert.ToDouble(Console.ReadLine());

            try
            {
                c = a / b;
                Console.WriteLine($"{a} Divided by {b}={c}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Error:{e.Message}");
            }
            finally
            {
                Console.WriteLine("Hi There , anyway execution ");
            }
        }
    }
}
