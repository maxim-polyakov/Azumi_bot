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
    public class MessageMonitorDiscord : MessageMonitor
    {
        
        public override string monitor(string content)
        {
            MessageMonitor.bridge.insert_to(content, "messtorage.storage");

            string outputmessage = string.Empty;
            
            List<string> messagelist = this.neurodesc(content);

            foreach (string mesage in messagelist)
            {
                outputmessage += mesage;
            }     

            return outputmessage;
        }

    }
}