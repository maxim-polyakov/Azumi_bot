using Bot_package;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_package
{
    [TestClass]
    public class Monitor_Test: ITester
    {
        [TestMethod]
        public void TestMethod_TelegramMonitor()
        {
            IMonitor mon = new MessageMonitorTelegram("тут?");
            mon.monitor();
        }

        [TestMethod]
        public void TestMethod_TelegramDiscord()
        {
            IMonitor mon = new MessageMonitorDiscord("привет как дела?");
            mon.monitor();
        }
    }
}