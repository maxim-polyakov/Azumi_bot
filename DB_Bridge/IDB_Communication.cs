using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace DB_Bridge
{
    public interface IDB_Communication
    {
        void insert_to();
        DataSet get_data(string select);
        bool checkcommands();
    }
    
    public class DB_Communication:IDB_Communication
    {


        public void insert_to()
        {
           
        }

        public DataSet get_data(string select)
        {
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=MisaMemory";
            var conn = new NpgsqlConnection(cs);
            conn.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = select;
            cmd.ExecuteNonQuery();

            NpgsqlDataReader dr = cmd.ExecuteReader();
            DataSet DS = new DataSet("DS");
            DataTable DT = new DataTable("DT");
            DS.Tables.Add(DT);
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true;
            idColumn.AllowDBNull = false;
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 1;
            idColumn.AutoIncrementStep = 1;

            DataColumn textColumn = new DataColumn("text", Type.GetType("System.String"));
            DataColumn agendaColumn = new DataColumn("agenda", Type.GetType("System.String"));
            DataColumn agendaidColumn = new DataColumn("agendaid", Type.GetType("System.String"));
            DataColumn hiColumn = new DataColumn("hi", Type.GetType("System.String"));
            DataColumn businessColumn = new DataColumn("business", Type.GetType("System.String"));
            DataColumn weatherColumn = new DataColumn("weather", Type.GetType("System.String"));
            DataColumn thanksColumn = new DataColumn("thanks", Type.GetType("System.String"));
            DataColumn emotionidColumn = new DataColumn("emotionid", Type.GetType("System.String"));

            DT.Columns.Add(idColumn);
            DT.Columns.Add(textColumn);
            DT.Columns.Add(agendaColumn);
            DT.Columns.Add(agendaidColumn);
            DT.Columns.Add(hiColumn);
            DT.Columns.Add(businessColumn);
            DT.Columns.Add(weatherColumn);
            DT.Columns.Add(thanksColumn);
            DT.Columns.Add(emotionidColumn);
            int id = 1;
            while (dr.Read())
            {
                DT.Rows.Add(id, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                id++;
            }

            return DS;
        }

        public bool checkcommands()
        {
            return false;
        }
    }
}