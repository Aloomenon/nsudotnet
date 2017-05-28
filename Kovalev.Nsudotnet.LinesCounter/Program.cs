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
        public LinesCounter(string[] args)
        {
            try
            {
                foreach (string extension in args)
                {
                    GetLinesCountFromFiles(Directory.EnumerateFiles(Directory.GetCurrentDirectory(), extension, SearchOption.AllDirectories));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot get files. {0}", ex);
            }
        }

        private void GetLinesCountFromFiles(IEnumerable<String> files)
        {
            foreach (var file in files)
            {
                using (StreamReader streamReader = new StreamReader(file))
                {
                    bool skip = false;
                    
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        
                        int counter = 0;
                        bool isComment = false;
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (!skip)
                            {
                                if (line[i] == '/' && i < line.Length - 1)
                                {
                                    switch (line[i + 1])
                                    {
                                        case '/':
                                            isComment = true;
                                            break;
                                        case '*':
                                            skip = true;
                                            break;
                                        default:
                                            counter++;
                                            break;
                                    }
                                    i++;
                                }
                                else if (line[i] != '\t' && line[i] != ' ' && line[i] != '\n')
                                {
                                    counter++;
                                }
                                
                            }
                            else if (line[i] == '*' && i < line.Length - 1)
                            {
                                if (line[i + 1] == '/')
                                {
                                    skip = false;
                                    i++;
                                }
                                
                            }
                        }
                        if (counter != 0 && !isComment)
                        {
                            _linesCounter++;
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
