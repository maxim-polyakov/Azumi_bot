using System;
using Npgsql;

namespace DB_Bridge
{
    public interface IDB_Communication
    {
        void insert_to();
        void get_data();
        bool checkcommands();
    }
    
    public class DB_Communication:IDB_Communication
    {

        static string Host = "localhost";
        static string User = "postgres";
        static string DBname = "MisaMemory";
        static string Password = "postgres";
        static string Port = "5432";

        public void insert_to()
        {
            string connString =
                String.Format("Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            
            using (var conn = new NpgsqlConnection(connString))
            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM train_sets.all_set_thanks", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                    
                }
            }
        }

        public void get_data()
        {
            
        }

        public bool checkcommands()
        {
            return false;
        }
    }
}