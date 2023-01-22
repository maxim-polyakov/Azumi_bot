namespace Bot_package
{
    public class MessageMonitorTelegram : Monitor
    {
        public MessageMonitorTelegram(string content)
        {
            this.content = content;
        }

        public string monitor() => base.monitor();
    }
}
