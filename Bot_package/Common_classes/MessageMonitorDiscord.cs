using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using NLP_package;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.FileProviders;
using DB_Bridge;
namespace Bot_package
{
    public class MessageMonitorDiscord :MessageMonitor
    {
        public MessageMonitorDiscord(string content)
        {
            this.content = content;
        }
        public override string monitor()
        {
            return base.monitor();
        }
    }
}