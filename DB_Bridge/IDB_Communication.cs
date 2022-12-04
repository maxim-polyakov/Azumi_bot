using System;
using System.Collections.Generic;
using Npgsql;

namespace DB_Bridge
{
    public interface IDB_Communication
    {
        void insert_to();
        List<List<string>> get_data();
        bool checkcommands();
    }
    
    public class DB_Communication:IDB_Communication
    {


        public void insert_to()
        {
           
        }

        public List<List<string>> get_data(string select)
        {
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=MisaMemory";

            var conn = new NpgsqlConnection(cs);
            conn.Open();

            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = select;

            cmd.ExecuteNonQuery();

            List<string> df_text = new List<string>();
            List<string> df_label = new List<string>();

            NpgsqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                df_text.Add(dr[0].ToString());
                df_label.Add(dr[1].ToString());

            }

            List<List<string>> df = new List<List<string>>();
            df.Add(df_text);
            df.Add(df_label);

            return df;
        }

        public bool checkcommands()
        {
            return false;
        }
    }
}