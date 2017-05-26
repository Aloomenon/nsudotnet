using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kovalev.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Wrong count of arguments.");
                Console.ReadKey();
            }
            else
            {
                LinesCounter lc = new LinesCounter(args);
                Console.WriteLine(lc.GetLinesCounter());
                Console.ReadKey();
            }
        }
    }

    class LinesCounter
    {
        private int _linesCounter = 0;
        Regex _commentOrEmptyString = new Regex("/{2}|^(\n*\\s*\t*)$");
        Regex _comBlockStarted = new Regex("/[*]");
        Regex _comBlockFinished = new Regex("[*]/"); 
        public LinesCounter(string[] args)
        {
            try
            {
                foreach (string extension in args)
                {
                    
                    GetLinesCountFromFiles(Directory.GetFiles(Directory.GetCurrentDirectory(), extension, SearchOption.AllDirectories));
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot get files. {0}", ex);
            }
        }

        private void GetLinesCountFromFiles(string[] files)
        {
            foreach (var file in files)
            {
                using (StreamReader streamReader = new StreamReader(file))
                {
                    bool skip = false;
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        
                         if (!_commentOrEmptyString.IsMatch(line) && !skip)
                         {
                             if (_comBlockStarted.IsMatch(line))
                             {
                                 skip = true;
                             }
                             else
                             {
                                 _linesCounter++;
                                 //Console.WriteLine(line);
                             }
                         }
                         if (_comBlockFinished.IsMatch(line) && skip)
                         {
                             skip = false;
                         }
                    }
                }
            }
        }

        public int GetLinesCounter()
        {
            return _linesCounter;
        }
    }
}
