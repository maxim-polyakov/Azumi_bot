using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Microsoft.Data.Analysis;

namespace DB_Bridge
{
    public interface IDB_Communication
    {
        void insert_to();
        DataFrame get_data(string select);
        bool checkcommands(string input_string);
    }

    public class DB_Communication : IDB_Communication
    {


        public void insert_to()
        {

        }

        public DataFrame get_data(string select)
        {
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=MisaMemory";
            var conn = new NpgsqlConnection(cs);
            conn.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = select;
            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr = cmd.ExecuteReader();

            PrimitiveDataFrameColumn<int> idx = new PrimitiveDataFrameColumn<int>("id", 0);
            StringDataFrameColumn text = new StringDataFrameColumn("text", 0);
            StringDataFrameColumn agenda = new StringDataFrameColumn("agenda", 0);
            Int32DataFrameColumn agendaid = new Int32DataFrameColumn("agendaid", 0);
            Int32DataFrameColumn hi = new Int32DataFrameColumn("hi", 0);
            Int32DataFrameColumn business = new Int32DataFrameColumn("business", 0);
            Int32DataFrameColumn weather = new Int32DataFrameColumn("weather", 0);
            Int32DataFrameColumn thanks = new Int32DataFrameColumn("thanks", 0);
            Int32DataFrameColumn emotionid = new Int32DataFrameColumn("emotionid", 0);
            Int32DataFrameColumn trash = new Int32DataFrameColumn("trash", 0);


            int id = 1;
            while (dr.Read())
            {
                idx.Append(id);
                text.Append(dr[0].ToString());
                agenda.Append(dr[1].ToString());
                agendaid.Append(Int32.Parse(dr[2].ToString()));
                hi.Append(Int32.Parse(dr[3].ToString()));
                business.Append(Int32.Parse(dr[4].ToString()));
                weather.Append(Int32.Parse(dr[5].ToString()));
                thanks.Append(Int32.Parse(dr[6].ToString()));
                emotionid.Append(Int32.Parse(dr[7].ToString()));
                trash.Append(Int32.Parse(dr[8].ToString()));
                id++;
            }

            DataFrame df = new DataFrame(idx, text, agenda, agendaid, hi, business, weather, thanks, emotionid, trash);
            return df;
        }

        public bool checkcommands(string input_string)
        {
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=MisaMemory";
            var conn = new NpgsqlConnection(cs);
            conn.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT text FROM assistant_sets.commands";
            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr = cmd.ExecuteReader();

            PrimitiveDataFrameColumn<int> idx = new PrimitiveDataFrameColumn<int>("id", 0);
            StringDataFrameColumn text = new StringDataFrameColumn("text", 0);

            int id = 1;
            while (dr.Read())
            {
                idx.Append(id);
                text.Append(dr[0].ToString());
                id++;
            }

            DataFrame df = new DataFrame(idx, text);
            Dictionary<int, string> txt = new Dictionary<int, string>();

            for (int i = 0; i < df["text"].Length; i++)
            {
                txt.Add(i, df["text"][i].ToString());
            }
            foreach (var txtvalue in txt.Values)
            {
                if (input_string.Contains(txtvalue))
                {
                    return true;
                }

            }
            return false;
        }
    }
}