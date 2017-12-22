/******************************************************************
** auth: Frank
** date: 12/22/2017 2:42:47 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("D://Error//" + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt",
                new string[] 
                {
                    "Message:"+e.Message,
                    "Stacktrace:"+e.StackTrace
                });
        }
    }
}
