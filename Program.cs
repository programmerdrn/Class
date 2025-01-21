using System.Transactions;
using tamrin7.General;
using tamrin7.Models;

namespace tamrin7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Console.WriteLine("Enter Your Name?");
            //Student student = new();
            //student.Name = Console.ReadLine();//Get

            //Console.WriteLine("Enter Your MobileNumber?");
            //student.MobileNumbe = Console.ReadLine();
            ////student.MobileNumbe = "09134568754";//Set


            //Console.WriteLine("Enter Your City?");
            //student.City = Console.ReadLine();

            //Console.WriteLine($" My Name Is : {student.Name} \n My PhoneNumber Is : {student.MobileNumbe} \n My City Is: {student.City}");



            //میتوان بینهایت از کلاس ها استفاده کرد
            //Student student1 = new();
            //Student student2 = new();

            AdminUser adminUser = new AdminUser();

            string ValidUserName = "admin";
            string ValidPassword = "12345";

            do
            {
                Console.WriteLine(CustomMassage.GetUserName);
                string username = Console.ReadLine() ?? string.Empty;

                Console.WriteLine(CustomMassage.GetPassword);
                string password = Console.ReadLine() ?? string.Empty;

                if (username == ValidUserName && password == ValidPassword)
                    break;
                else
                    Console.WriteLine(CustomMassage.PleasEnterValidData);
            }
            while (true);

            ShowWarWellcomeMassage();

            Student student = new Student();
            //Console.WriteLine("Pleas Enter Your FirstName?");
            //
            do
            {
                Console.WriteLine(CustomMassage.GetFirstName);
                student.FirstName = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(student.FirstName))
                    break;
                else
                    Console.WriteLine("Pleas Enter Valid FirstName:");
            }
            while (true);

        }
        static bool IsValidMobileNumber(string mobileNumber)
        {
            //chek number
            if (string.IsNullOrEmpty(mobileNumber))
            {
                return false;
            }
            if (mobileNumber.Length == 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void ShowWarWellcomeMassage(string name = null)
        {
            Console.WriteLine($"Wellcome {name}....");
        }
    }

}
