using System;
using System.Text;
using System.IO;

namespace Task1CSharp
{
    public static class Log
    {
        private const string LOG_PATH = "../../log.txt";

        public static void Message(string msg)
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
