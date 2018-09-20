using System;
using System.Text;
using System.IO;

namespace Task1CSharp
{
    public static class Log
    {
        private const string LOG_PATH = "../../log.txt";
        private static object o = new object();

        public static void Message(string msg)
        {
            lock (o)
            {
                string logMsg = $"{DateTime.Now.ToLongTimeString()} -> {msg}";
                using (StreamWriter sw = new StreamWriter(LOG_PATH, true, Encoding.Default))
                {
                    sw.WriteLine(logMsg);
                }
                
                Console.WriteLine(logMsg);
            }
        }
    }
}
