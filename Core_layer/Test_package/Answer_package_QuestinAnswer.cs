using Answer_package;

namespace Test_package;

[TestClass]
public class Answer_package_QuestinAnswer
{
    [TestMethod]
    public void TestMethod_answer()
    {
        var text = "";
        
        QuestionAnswer rndAnsw = new QuestionAnswer(text);
        
        rndAnsw.answer();
    }
}