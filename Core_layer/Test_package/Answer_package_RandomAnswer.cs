namespace Test_package;
using NLP_package;
using DB_Bridge;
using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.Data.Analysis;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using Answer_package;

[TestClass]
public class RandomAnswer_Test
{
    static RandomAnswer rndAnsw = new RandomAnswer();

    [TestMethod]
    public void TestMethod_answer()
    {
        rndAnsw.answer();
    }
}