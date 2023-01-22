using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NLP_package;
using static System.Net.Mime.MediaTypeNames;

using DB_Bridge;
namespace Bot_package
{
    public class MessageMonitorDiscord : Monitor
    {
        public MessageMonitorDiscord(string content)
        {
            this.content = content;
        }
        public string monitor() => base.monitor();
    }
}