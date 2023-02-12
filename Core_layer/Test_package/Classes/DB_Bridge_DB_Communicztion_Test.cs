using DB_package;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_package
{
    [TestClass]
    public class DBCommunicztion_Test: ITester
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
            Dictionary<int, string> dict = bridge.get_data("SELECT * FROM answer_sets.hianswer");
        }

        [TestMethod]
        public void TestMethod_get_token()
        {
            string str = bridge.get_token("select token from assistant_sets.tokens where botname = \'Azumi\' and platformname = \'Telegram\'");
        }
    }
}