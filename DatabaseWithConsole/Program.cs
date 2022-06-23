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
            var sql = "SELECT * FROM address_book";
            ReadFromDatabase(sql);

            var sql2 = "INSERT INTO address_book (id, full_name, contact_no, email) " +
                "VALUES (null, 'Rohan Shrestha', '123456', 'mail@email.com')";
            WriteToDatabase(sql2);

            //ReadFromDatabase(sql);
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
            Console.WriteLine("Connection Closed. Press any key to exit...");
            Console.ReadKey();
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
            Console.WriteLine("Connection Closed. Press any key to exit...");
            Console.ReadKey();
        }
    }

   
}