using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLP_package;


namespace Test_package
{
    [TestClass]
    public class GPT_Test
    {

        private static IGpt gpt = new Gpt();

        [TestMethod]
        public void TestMethod_generate() {

            var input = "привет";
            var str = gpt.generate(input);
        }
    }
}
