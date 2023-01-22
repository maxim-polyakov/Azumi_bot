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
        string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string text = "привет";

        List<string[]> modelPahths = new List<string[]>();

        modelPahths.Add(Directory.GetFiles(fullPath, "himodel.zip", SearchOption.AllDirectories));
        modelPahths.Add(Directory.GetFiles(fullPath, "thmodel.zip", SearchOption.AllDirectories));
        modelPahths.Add(Directory.GetFiles(fullPath, "businessmodel.zip", SearchOption.AllDirectories));
        modelPahths.Add(Directory.GetFiles(fullPath, "weathermodel.zip", SearchOption.AllDirectories));
        modelPahths.Add(Directory.GetFiles(fullPath, "trashmodel.zip", SearchOption.AllDirectories));

        var hipredict = predictor.predict(text, modelPahths[0][0], map.himap);
        var thpredict = predictor.predict(text, modelPahths[1][0], map.thmap);
        var businesspredict = predictor.predict(text, modelPahths[2][0], map.businessmap);
        var weatherpredict = predictor.predict(text, modelPahths[3][0], map.trashmap);
        var trashpredict = predictor.predict(text, modelPahths[4][0], map.trashmap);

    }
}