using System;
using Logit;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            Logger logger = new Logger();

            logger.Log(Severity.Debug, "This is a syncronous debug message1");
            logger.Log(Severity.Warning, "This is a syncronous debug message2");
            logger.Log(Severity.Critical, "This is a syncronous debug message3");
            logger.Log(Severity.Information, "This is a syncronous debug message4");
            logger.Log(Severity.Debug, "This is a syncronous debug message5");
            logger.Log(Severity.Debug, "This is a syncronous debug message6");
            logger.Log(Severity.Warning, "This is a syncronous debug message7");
            logger.Log(Severity.Debug, "This is a syncronous debug message8");
            logger.Log(Severity.Debug, "This is a syncronous debug message9");
            logger.Log(Severity.Configuration, "This is a syncronous debug message10");


            Console.WriteLine($"Complete");

            Console.ReadLine();

        }
    }
}
