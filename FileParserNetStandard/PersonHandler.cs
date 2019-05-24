using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;

namespace FileParserNetStandard {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {
            People = new List<Person>();
            for (int i = 1; i < people.Count; i++)
            {
                People.Add(new Person(int.Parse(people[i].First()), people[i].Skip(1).First(), people[i].Skip(2).First(), new DateTime(long.Parse(people[i].Skip(3).First()))));
            }
            //People = people.Skip(1).Select((ppl, index) => new Person(
            //int.Parse(ppl[0]), ppl[1], ppl[2], new DateTime(long.Parse(ppl[3])))).ToList();

        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {
            return People.OrderBy(x => x.Dob).TakeWhile(x => People.Min(people => people.Dob.Date) == x.Dob.Date).ToList();
            //return new List<Person>(); //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            string result = People.Where(x => x.Id == id).First().ToString();
            Console.WriteLine(new DateTime(long.Parse("636292800000000000")));
            Console.WriteLine(result);
            return result;  //-- return result here
            //return "result";  //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            List<Person> result = new List<Person>();
            result = People.OrderBy(x => x.Surname).ToList();
            return result;
            //return new List<Person>();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            int result = 0;
            if (!caseSensitive)
            {
                result = People.Where(x => x.Surname.ToLower().StartsWith(searchTerm.ToLower())).Count();
            }
            else
            {
                result = People.Where(x => x.Surname.StartsWith(searchTerm)).Count();
            }
            return result;
            //return 0;  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();
            var ppl = People.GroupBy(p => p.Dob).Select(g => new { Dob = g.Key, Count = g.Count()}).OrderBy(p => p.Dob);
            Console.WriteLine(ppl);
            foreach (var d in ppl)
            {
                result.Add(d.Dob.ToString() + '\t' + d.Count);
            }
            return result;

            //return result;  //-- return result here
        }
    }
}