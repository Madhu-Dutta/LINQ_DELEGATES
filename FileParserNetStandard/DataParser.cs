using System.Collections.Generic;
using System.Linq;
using Delegate_Exercise;
using ObjectLibrary;

namespace FileParserNetStandard {
    public class DataParser {       

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {            
            for(int i = 0; i < data.Count; i++)
            {                
                for(int j = 0; j < data[i].Count; j++)
                {
                    data[i][j] = data[i][j].ToString().Replace(" ", string.Empty);
                }               
            }
            System.Console.WriteLine(data[7][0]);
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {           
            for(int i = 0; i < data.Count; i++)
            {                
                for(int j = 0; j < data[i].Count; j++)
                {
                   data[i][j] = data[i][j].Replace("\"", string.Empty);
                }                
            }
            System.Console.WriteLine(data[5][1]);
            return data;
            //return data;
        }

    }
}