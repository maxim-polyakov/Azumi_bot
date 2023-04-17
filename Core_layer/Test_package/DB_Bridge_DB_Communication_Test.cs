namespace Test_package;
using NLP_package;
using DB_package;
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
        bridge.insert_to("ïðèâåò", "messtorage.storage");
    }

    [TestMethod]
    public void TestMethod_get_data()
    {
        Dictionary<int,string> dict = bridge.get_data("SELECT * FROM answer_sets.hianswer");
    }
}