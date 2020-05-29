using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Sherial
{
    
    sealed class Sherin_Heer
    {

        public void itimeschedule()
        {
         
            try
            {
                
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\hiral\sem 6\dot net\Sherial\Sherial\sherial.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                
                Console.WriteLine("Do u want to insert ur days? say true or false!!");
                bool choice = Convert.ToBoolean(Console.ReadLine());
                if (true)
                {

                        //Console.WriteLine("On which date do u want to update the time? (hh.mm to hh.mm in this format)");
                        //Console.WriteLine("How many days in this week?");
                        //int days = Convert.ToInt32(Console.ReadLine());
                        ooo:
                        Console.WriteLine("Enter the date when u r free for this week: (dd/mm/yyyy)");
                        string date = Console.ReadLine();
                           /* SqlCommand com = new SqlCommand("insert into Timetable(Date) values(@date)", con);
                            com.Parameters.AddWithValue("@date", date);
                            int j = com.ExecuteNonQuery();
                            if (j > 0)
                            {
                                Console.WriteLine("xx");
                                //Console.WriteLine(date);
                                
                            }*/
                            SqlCommand com2 = new SqlCommand("insert into Timetable(Date,time1,time2,time3,time4,time5,time6,time7,time8) values(@date,@time1,@time2,@time3,@time4,@time5,@time6,@time7,@time8)", con);
                            //var p2 = com2.Parameters.Add("@date", SqlDbType.DateTime);
                            //Console.WriteLine(date);
                            com2.Parameters.AddWithValue("@date",date);
                            //Console.WriteLine(date);
                            string no = "no";
                            com2.Parameters.AddWithValue("@time1", no);
                            com2.Parameters.AddWithValue("@time2", no);
                            com2.Parameters.AddWithValue("@time3", no);
                            com2.Parameters.AddWithValue("@time4", no);
                            com2.Parameters.AddWithValue("@time5", no);
                            com2.Parameters.AddWithValue("@time6", no);
                            com2.Parameters.AddWithValue("@time7", no);
                            com2.Parameters.AddWithValue("@time8", no);
                            int k = com2.ExecuteNonQuery();
                            if (k > 0)
                            {
                                Console.WriteLine("done");
                            }
                            Console.WriteLine("Do u want to add more? say yes or no");
                            string ans = Console.ReadLine();
                            if (ans == "yes")
                            {
                                goto ooo;
                            }
                            else
                            {
                                Console.WriteLine("Go for logout? Press enter");
                                Console.ReadKey();
                                Console.Clear();
                            }

                }
                
                else{
                    Console.WriteLine("U wanna logout? Press Enter");
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
