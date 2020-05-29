using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Sherial
{
    public partial class Customer:Abstract
    {
        
        public int id = 0;
        public override void login()
        {

            try
            {
                abcd :
                Sherin_Heer sh = new Sherin_Heer();
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand com = new SqlCommand("select count(*) from Registration where Email=@email and Password=@Password", con);

                Console.WriteLine("Login:--");
                Console.WriteLine("Enter Email: ");
                email = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                password = Console.ReadLine();
                com.Parameters.AddWithValue("@email", email);
                com.Parameters.AddWithValue("@Password", password);
                int result = (int)com.ExecuteScalar();

                if (result > 0)
                {
                    //Console.WriteLine("", id);
                    fetch_id();
                    Console.WriteLine("Successfully logged in...");
                    Console.WriteLine("Where u want to go?");
                    Console.WriteLine("1. Time Schedule");
                    Console.WriteLine("2. Logout");
                    int j = Convert.ToInt32(Console.ReadLine());
                    switch (j)
                    {
                        case 1:
                            if (email == "admin@gmail.com" && password == "admin")
                            {
                                sh.itimeschedule();
                            }
                            else
                            {
                                timeschedule();
                                booking();
                            }
                            break;
                        case 2:
                            logout();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("U havnt registered yet..Or enter the correct email and password.. Try again...");
                    goto abcd;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /*public void fetch_id()
        {
            
            SqlConnection con5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
            con5.Open();
            SqlCommand com5 = new SqlCommand("select id from Registration where Email=@email", con5);
                //com2.Parameters.AddWithValue("@id", id);
                com5.Parameters.AddWithValue("@email",email);
                
                    //Console.WriteLine("", id);
                    SqlDataReader reader = com5.ExecuteReader();
                   

                    while (reader.Read())
                    {
                        
                        Console.WriteLine("ur usr_id: {0}",reader.GetValue(0));
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                   
        }*/
        
        public override void timeschedule()
        {
            Console.WriteLine("U can go on these days in this week: ");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
            
            SqlCommand com = new SqlCommand("select Date,time1,time2,time3,time4,time5,time6,time7,time8 from Timetable",con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("            9-10am  10-11am  11-12noon  4-5pm  5-6pm  6-7pm  7-8pm  8-9pm");
                Console.WriteLine(rdr.GetString(0) + "     " + rdr.GetString(1) + "     " + rdr.GetString(2) + "     " + rdr.GetString(3) + "          " + rdr.GetString(4) + "     " + rdr.GetString(5) + "     " + rdr.GetString(6) + "     " + rdr.GetString(7) + "     " + rdr.GetString(8));
            }
            con.Close();
        }
        public void booking()
        {
            Customer c = new Customer();
            string mail;
            Console.WriteLine("Please provide your email ID");
            mail = Console.ReadLine();
            Console.WriteLine(c.fetch_id1(mail));
            Console.WriteLine("On which date u wanna come?");
            string date = Console.ReadLine();
            SqlConnection con2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
            con2.Open();
            //SqlCommand com3 = new SqlCommand("insert into Timetable(U_id) values(@id) where Date=@Date",con2);
            //com3.Parameters.AddWithValue("@Date",date);

            //com3.Parameters.AddWithValue("@id", c.fetch_id1(mail));
            //com3.ExecuteNonQuery();
            Console.WriteLine("");
            Console.WriteLine("Schedule of {0} : ", date);
            SqlCommand com2 = new SqlCommand("select time1,time2,time3,time4,time5,time6,time7,time8 from Timetable where Date=@date", con2);
            
            com2.Parameters.AddWithValue("@date",date);
            SqlDataReader rdr2 = com2.ExecuteReader();
            while (rdr2.Read())
            {
                Console.WriteLine("time1     time2     time3     time4     time5     time6     time7     time8");
                Console.WriteLine("9-10am  10-11am  11-12noon  4-5pm  5-6pm  6-7pm  7-8pm  8-9pm");
                Console.WriteLine(rdr2.GetString(0) + "     " + rdr2.GetString(1) + "     " + rdr2.GetString(2) + "     " + rdr2.GetString(3) + "          " + rdr2.GetString(4) + "     " + rdr2.GetString(5) + "     " + rdr2.GetString(6) + "     " + rdr2.GetString(7));

                //Console.ReadKey();
            }
            rdr2.Close();
            Console.WriteLine("Give ur time(timen in this format): ");
            string time = Console.ReadLine();

            Console.ReadKey();
            Console.WriteLine(c.fetch_id1(mail));
            SqlCommand com9 = new SqlCommand("update Timetable set " + time + " = 'yes',U_id = '" + c.fetch_id1(mail) + "'  where Date = @date", con2);
            com9.Parameters.AddWithValue("@date",date);
            Console.WriteLine(c.fetch_id1(mail)+"whooooooo");
            //com9.Parameters.AddWithValue("@id", c.fetch_id1(mail));
            com9.ExecuteNonQuery();
            Console.WriteLine("doneee");
            Console.ReadKey();

            Console.ReadKey();
            con2.Close();


            Console.WriteLine("Go for logout? Press enter");
            Console.ReadKey();
            Console.Clear();
        }

        
        public void logout()
        {
            Console.Clear();
        }
        public int fetch_id()
        {
            int ie = 0;
            
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand com = new SqlCommand("select id from Registration where Email=@email", con);
                Console.WriteLine(email);
                com.Parameters.AddWithValue("@email", email);
                
                
                    //Console.WriteLine("", id);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("ur usr_id: {0}", reader.GetValue(0));
                        ie = Convert.ToInt32(reader.GetValue(0));
                        //com.Parameters.AddWithValue("@id", reader.GetValue(0));
                    }

                    Console.WriteLine("feched id");
           
            //Console.WriteLine(ie);
            return ie;
        }

        public int fetch_id1(string mail)
        {
            int ie = 0;

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("select id from Registration where Email=@email", con);
            Console.WriteLine(mail);
            com.Parameters.AddWithValue("@email", mail);


            //Console.WriteLine("", id);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("ur usr_id: {0}", reader.GetValue(0));
                ie = Convert.ToInt32(reader.GetValue(0));
                //com.Parameters.AddWithValue("@id", reader.GetValue(0));
            }



            //Console.WriteLine(ie);
            return ie;
        }
        /*public int i
        {
            get { return i; }
            set { i = value; }
        }*/
    }
}
