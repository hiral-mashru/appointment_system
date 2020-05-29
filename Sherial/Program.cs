using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sherial
{
    class Program
    {
        int n;
        public Program()
        {
            n = 0;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Sherin_Heer sh = new Sherin_Heer();
            Customer c = new Customer();
            Console.WriteLine("*********************WELCOME TO SHERIAL BEAUTY PARLOUR*********************");
            Console.WriteLine("(1) Login");
            Console.WriteLine("(2) Registration");
            Console.WriteLine("Where u wanna go ? Select no.: ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    c.login();
                    break;
                case 2:
                    c.registration();
                    c.login();
                    break;
                default:
                    Console.WriteLine("Choose correct number...");
                    break;
            } 
        }
    }
}
