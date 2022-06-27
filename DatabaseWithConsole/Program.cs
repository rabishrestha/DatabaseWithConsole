using MySql.Data.MySqlClient;
using System;

namespace MySQLConnectionExample
{
    class Program
    {
        //your MySQL connection string
        static string connStr = "server=localhost;user=mbm;password=mbm;database=mbm;port=3306;";

        static void Main(string[] args)
        {
            DisplayOptions();
        }

        public static void DisplayOptions()
        {
            Console.WriteLine("\n\nEnter your option\n 1 : Add Data\n " +
                "2 : List Data\n 0 : Quit");
            int c = 2;
            try
            {
                c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Write("Enter full name (string) :\t");
                        string full_name = Console.ReadLine();
                        Console.Write("Enter Contact No (string) :\t");
                        string contact = Console.ReadLine();
                        Console.Write("Enter Email (string) :\t");
                        string email = Console.ReadLine();
                        var sql2 = "INSERT INTO address_book (id, full_name, contact_no, email) " +
                        $"VALUES (null, '{full_name}', '{contact}', '{email}')";
                        WriteToDatabase(sql2);
                        break;
                    case 2:
                        var sql = "SELECT * FROM address_book";
                        ReadFromDatabase(sql);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please enter numbers between 1 to 3 only");
            }
        }
        public static void ReadFromDatabase(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2] + " -- " + rdr[3]);
                }
                rdr.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            //Console.WriteLine("Connection Closed. Press any key to exit...");
            DisplayOptions();
        }

        public static void WriteToDatabase(string sql)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted successfully.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            //Console.WriteLine("Connection Closed. Press any key to exit...");
            DisplayOptions();
        }
    }

   
}