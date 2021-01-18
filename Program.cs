using System;
using System.Data.SqlClient;
using static System.Console;
namespace ProjAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //--DataReaderExaple();
            Contact contact = new Contact { Name = "Mayur", Age = 35 };

            ContactWriter contactWriter = new ContactWriter(contact);
            contactWriter.Write();
        }
        private static void DataReaderExaple()
        {
            string ConString = @"Data Source=MySQLServerName;Initial Catalog=MyDB;User ID=sa;Password=pwd";

            
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select top 100000 col1 from tbl", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string str =  rdr["col1"].ToString();
                        Console.WriteLine(str);
                    }
                }

                Console.Read();
            }

        }
    }


}
