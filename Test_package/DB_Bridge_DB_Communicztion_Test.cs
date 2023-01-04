namespace Test_package;
using NLP_package;
using DB_Bridge;
using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.Data.Analysis;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

[TestClass]
public class DBCommunicztion_Test
{
    static IDB_Communication bridge = new DB_Communication();

    [TestMethod]
    public void TestMethod_insert_to()
    {
        bridge.insert_to("привет", "messtorage.storage");
    }

    [TestMethod]
    public void TestMethod_get_data()
    {
        string select = "select * FROM train_sets.all_set_thanks" +
           " union all " +
           "select * FROM train_sets.all_set_none" +
           " union all " +
           "select * FROM train_sets.all_set_hi" +
           " union all " +
           "select * FROM train_sets.all_set_business" +
           " union all " +
           "select * FROM train_sets.all_set_weather" +
           " order by agendaid asc";

        DataFrame df = bridge.get_data(select);
    }
}