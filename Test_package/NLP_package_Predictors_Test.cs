namespace Test_package;
using NLP_package;
[TestClass]
public class Predictor_Test
{
    static IPredictor predictor = new Predictor();

    [TestMethod]
    public void TestMethod_Predict()
    {
        Maps map = new Maps();

        string text = "привет";
        var hiflag = predictor.predict(text, "C:\\Users\\maxim\\Documents\\GitHub\\Azumi_bot\\NLP_package\\Models\\himodel.zip", map.himap);
        var thflag = predictor.predict(text, "C:\\Users\\maxim\\Documents\\GitHub\\Azumi_bot\\NLP_package\\Models\\thmodel.zip", map.thmap);
        var businessflag = predictor.predict(text, "C:\\Users\\maxim\\Documents\\GitHub\\Azumi_bot\\NLP_package\\Models\\businessmodel.zip", map.businessmap);
        var trashflag = predictor.predict(text, "C:\\Users\\maxim\\Documents\\GitHub\\Azumi_bot\\NLP_package\\Models\\trashmodel.zip", map.trashmap);
    }
}