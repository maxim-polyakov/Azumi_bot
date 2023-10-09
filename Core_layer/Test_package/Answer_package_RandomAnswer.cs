namespace Test_package;
using Answer_package;

[TestClass]
public class RandomAnswer_Test {
    static RandomAnswer rndAnsw = new RandomAnswer();

    [TestMethod]
    public void TestMethod_answer() {
        rndAnsw.answer();
    }
}