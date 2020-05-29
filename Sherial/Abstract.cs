using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Sherial
{
   public abstract class Abstract 
    {
        protected string username;
        protected string password;
        protected string email;
        protected double mobno;
        
        public abstract void login();
        public abstract void timeschedule();
    }
    interface regi
    {
         void registration();
         //void itimeschedule();
    }
    public partial class Customer : Abstract,regi
    {
        //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
        public void registration()
        {
            abc:
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand com = new SqlCommand("insert into Registration(uname,mobno,Email,Password) values(@uname,@mobno,@Email,@Password)", con);
                Console.WriteLine("Registration:--");
                Console.WriteLine("Enter Ur Name: ");
                username = Console.ReadLine();
                Console.WriteLine("Enter Ur Mobile No.: ");
                mobno = Convert.ToDouble(Console.ReadLine());
                string mobile = Convert.ToString(mobno);
                if (mobile.Length == 9)
                {
                    com.Parameters.AddWithValue("@mobno", mobno);
                }
                else
                {
                    Console.WriteLine("Mobile must have 10 digits..");
                    goto abc;
                    
                }
                Console.WriteLine("Enter Email: ");
                Email = Console.ReadLine();
                if (Email.Contains("@") && Email.EndsWith(".com"))
                {
                    com.Parameters.AddWithValue("@Email", email);
                }
                else
                {
                    Console.WriteLine("Insert correct email id..");
                    goto abc;
                }
                Console.WriteLine("Enter Password: ");
                Password = Console.ReadLine();
                com.Parameters.AddWithValue("@uname", username);
                com.Parameters.AddWithValue("@Password", password);
                int i = com.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Successful..");
                }
                else
                {
                    Console.WriteLine("There is some problem...");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
       
    }

}
