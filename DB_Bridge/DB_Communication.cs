using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Microsoft.Data.Analysis;

namespace DB_Bridge
{

    public class DB_Communication : IDB_Communication
    {
        public void insert_to(string insert, string tablename)
        {
            try
            {
                var insertSql = "insert into " + tablename +
                    " () " + "values";
                var cs = "Host=localhost;Username=postgres;Password=postgres;Database=MisaMemory";
                var conn = new NpgsqlConnection(cs);
                conn.Open();
                var cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = insertSql;
                NpgsqlDataReader dr = cmd.ExecuteReader();
            }
            catch
            {

            }

        }
        public DataFrame get_data(string select)
        {
            int id = 1;
            var conection = new Connections();
            var cs = conection.cs;
            var conn = new NpgsqlConnection(cs);
            conn.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = select;
            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr = cmd.ExecuteReader();

            SentimentData sd = new SentimentData();
            sd.id = new PrimitiveDataFrameColumn<int>("id", 0);
            sd.text = new StringDataFrameColumn("text", 0);
            sd.agenda = new StringDataFrameColumn("agenda", 0);
            sd.agendaid = new BooleanDataFrameColumn("agendaid", 0);
            sd.hi = new BooleanDataFrameColumn("hi", 0);
            sd.business = new BooleanDataFrameColumn("business", 0);
            sd.weather = new BooleanDataFrameColumn("weather", 0);
            sd.thanks = new BooleanDataFrameColumn("thanks", 0);
            sd.emotionid = new BooleanDataFrameColumn("emotionid", 0);
            sd.trash = new BooleanDataFrameColumn("trash", 0);
           
            while (dr.Read())
            {
                sd.id.Append(id);
                sd.text.Append(dr[0].ToString());
                sd.agenda.Append(dr[1].ToString());
                sd.agendaid.Append(Convert.ToBoolean(Int32.Parse(dr[2].ToString())));
                sd.hi.Append(Convert.ToBoolean(Int32.Parse(dr[3].ToString())));
                sd.business.Append(Convert.ToBoolean(Int32.Parse(dr[4].ToString())));
                sd.weather.Append(Convert.ToBoolean(Int32.Parse(dr[5].ToString())));
                sd.thanks.Append(Convert.ToBoolean(Int32.Parse(dr[6].ToString())));
                sd.emotionid.Append(Convert.ToBoolean(Int32.Parse(dr[7].ToString())));
                sd.trash.Append(Convert.ToBoolean(Int32.Parse(dr[8].ToString())));
                id++;
            }

            DataFrameColumn[] columns =
            {
                    sd.id,
                    sd.text,
                    sd.agenda,
                    sd.hi,
                    sd.business,
                    sd.weather,
                    sd.thanks,
                    sd.emotionid,
                    sd.trash
            };

            DataFrame df = new DataFrame(columns);
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