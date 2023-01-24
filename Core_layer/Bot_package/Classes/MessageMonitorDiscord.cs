namespace Bot_package
{
    public class MessageMonitorDiscord : Monitor
    {
        public MessageMonitorDiscord(string content)
        {
            base.content = content;
        }
        public string monitor() => base.monitor();
    }
}