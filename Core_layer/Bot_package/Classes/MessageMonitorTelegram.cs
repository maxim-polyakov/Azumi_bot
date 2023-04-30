namespace Bot_package
{
    public class MessageMonitorTelegram : Monitor
    {
        public MessageMonitorTelegram(string content)
        {
            base.content = content;
        }
        public string monitor() => base.monitor();
    }
}
