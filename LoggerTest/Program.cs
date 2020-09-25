using System;

namespace LoggerTest
{
    public class Logger
    {
        private static Logger instance = null;

        private Logger()
        {

        }

        public void writeToConsole(String output)
        {
            Console.WriteLine(output);

        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.Instance;
            logger.writeToConsole("Hello World");
        }
    }

}
