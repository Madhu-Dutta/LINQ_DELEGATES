using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            List<string> lines = new List<string>();
            var data = File.ReadAllLines(filePath);
            for(int i = 0; i < data.Length; i++)
            {
                lines.Add(data[i]);
            }
            return lines;
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {
            //false to override
            StreamWriter sw = new StreamWriter(filePath, false);
            for(int i = 0; i < rows.Count; i++)
            {
                string lines = string.Join(delimeter.ToString(), rows[i]);
                sw.WriteLine(lines);
            }
            sw.Close();

        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter) {
            List<List<string>> result = new List<List<string>>();
            for(int i = 0; i < data.Count; i++)
            {
                result.Add(data[i].Split(delimeter).ToList());
            }
            return result;
            //return new List<List<string>>();  //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {
            List<List<string>> result = new List<List<string>>();
            for(int i = 0; i < data.Count; i++)
            {
                result.Add(data[i].Split(',').ToList());
            }
            return result;
            //return new List<List<string>>();      
            //-- return result here
        }
    }
}