namespace Test_package;
using Bot_package;

[TestClass]
public class Bot_package_Test
{
    [TestMethod]
    public void MessageMonitorDiscord_Test()
    {   
        string input_string = string.Empty;
        IMonitor mmd = new MessageMonitorDiscord(input_string);
    }
}