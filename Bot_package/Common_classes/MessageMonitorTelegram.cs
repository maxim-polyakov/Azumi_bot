﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
