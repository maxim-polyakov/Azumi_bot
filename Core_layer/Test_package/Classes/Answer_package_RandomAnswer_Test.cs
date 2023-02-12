using Answer_package;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_package
{   
    [TestClass]
    public class RandomAnswer_Test:ITester
    {
        static RandomAnswer rndAnsw = new RandomAnswer();

        [TestMethod]
        public void TestMethod_answer()
        {
            rndAnsw.answer();
        }
    }
}