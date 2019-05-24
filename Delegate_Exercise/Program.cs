using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    internal class Delegate_Exercise
    {
        public static string readfile = "C:\\Users\\madhu\\Documents\\DIPLOMA\\C#-WED\\WK10-DelegatesTry2\\Dip-Seminar-Delegates-Lambda-Linq_Exercises\\Files\\data.csv";
        public static string writefile = "C:\\Users\\madhu\\Documents\\DIPLOMA\\C#-WED\\WK10-DelegatesTry2\\Dip-Seminar-Delegates-Lambda-Linq_Exercises\\Files\\processed_data.csv";
        public static string newwritefile = "C:\\Users\\madhu\\Documents\\DIPLOMA\\C#-WED\\WK10-DelegatesTry2\\Dip-Seminar-Delegates-Lambda-Linq_Exercises\\Files\\new_processed_data.csv";
              
        public static List<List<string>> StripHash(List<List<string>> data)
        {            
            for (int i = 0; i < data.Count; i++)
            {                
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].Replace("#", String.Empty);
                }
            }
            return data;
        }

        public static List<List<string>> Capitalize(List<List<string>> data)
        {            
            for (int i = 0; i < data.Count; i++)
            {                
                for (int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].ToUpper();
                }
            }
            return data;
        }

        public static void Main(string[] args)
        {
            FileHandler fh = new FileHandler();
            CsvHandler csvhandler = new CsvHandler();
            DataParser dp = new DataParser();

            Func<List<List<string>>, List<List<string>>> genericDelegate = new Func<List<List<string>>, List<List<string>>>(dp.StripWhiteSpace);
            genericDelegate += dp.StripQuotes;
            genericDelegate += StripHash;
            csvhandler.ProcessCsv(readfile, writefile, genericDelegate);

            Func<List<List<string>>, List<List<string>>> parserDelegate = new Func<List<List<string>>, List<List<string>>>(dp.StripWhiteSpace);
            parserDelegate += dp.StripQuotes;
            parserDelegate += StripHash;
            parserDelegate += Capitalize;
            csvhandler.ProcessCsv(readfile, newwritefile, parserDelegate);

        }
    }
}

