using System;
using LogitForFramework;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();


            for (int i = 0; i < 100; i++)
            {
                watch.Restart();
                watch.Start();
                Log.Append(Severity.Configuration, $"This is a syncronous debug message{i}");
                watch.Stop();
                Console.WriteLine("log " + watch.ElapsedTicks.ToString()); 
            }




            //for (int i = 0; i < 10; i++)
            //{
            //    Log.Append(Severity.Debug, "This is a syncronous debug message1");
            //    Log.Append(Severity.Warning, "This is a syncronous debug message2");
            //    Log.Append(Severity.Critical, "This is a syncronous debug message3");
            //    Log.Append(Severity.Information, "This is a syncronous debug message4");
            //    Log.Append(Severity.Debug, "This is a syncronous debug message5");
            //    Log.Append(Severity.Debug, "This is a syncronous debug message6");
            //    Log.Append(Severity.Warning, "This is a syncronous debug message7");
            //    Log.Append(Severity.Debug, "This is a syncronous debug message8");
            //    Log.Append(Severity.Debug, "This is a syncronous debug message9");
            //}


            Console.WriteLine($"Complete");

            Console.ReadLine();

        }
    }
}
