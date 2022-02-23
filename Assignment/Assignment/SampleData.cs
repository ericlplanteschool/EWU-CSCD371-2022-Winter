using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv")
                    .Skip(1)
                    .ToList();

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> states = new();
            foreach (var row in CsvRows)
            {
                var columns = row.Split(',');
                states.Add(columns[6]);
            }
            states.Sort();
            return states;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            String allStates = string.Join("", states);
            return allStates;
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                List<Person> people = new();
                foreach (var row in CsvRows)
                {
                    var columns = row.Split(',');
                    Address address = new(columns[4], columns[5], columns[6], columns[7]);
                    people.Add(new Person(columns[1], columns[2], address, columns[3]));
                }
                return people;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            IEnumerable<IPerson> people = People.Where(person => filter(person.EmailAddress));
            List<(string, string)> names = new();
            foreach (Person person in people) names.Add((person.FirstName, person.LastName));
            return names;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            IEnumerable<string> states = people.Select(person => person.Address.State);
            string allStates = states.Aggregate(string.Empty, (statesList, nextState) => $"{statesList}, {nextState}");
            return allStates;
        }
    }
}
