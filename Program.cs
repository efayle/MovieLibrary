using System;
using NLog.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieLibraryAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program Started");

            logger.Info("Program Ended");
        }
    }
}
