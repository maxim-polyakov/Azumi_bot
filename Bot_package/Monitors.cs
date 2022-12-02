using System;

namespace Bot_package
{
    public interface IMonitor
    {
       String monitor();
    }

    public abstract class Monitor
    {
        public abstract String monitor();
    }

    public class MessageMonitor:Monitor
    {
        public override String monitor()
        {
            return "";
        }
    }

    public class MessageMonitorTelegram : MessageMonitor
    {
        public override String monitor()
        {
            return "";
        }
    }

    public class MessageMonitorDiscord : MessageMonitor
    {
        public override String monitor()
        {
            return "";
        }

    }
}