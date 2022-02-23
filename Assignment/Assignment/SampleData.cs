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
            return CsvRows
            .Select(x => x.Split(','))
            .Select(y => y[6]).OrderBy(z => z)
            .Distinct()
            .ToList();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            return string.Join(", ", states);
        }

        // 4.
        public IEnumerable<IPerson> People
        {
            get => CsvRows.Select(x =>
            x.Split(','))
               .OrderBy(state => state[6])
               .ThenBy(city => city[5])
               .ThenBy(zipCode => zipCode[7])
            .Select(
                line => new Person(
                    line[1],
                    line[2],
                    new Address(
                        line[4],
                        line[5],
                        line[6],
                        line[7]),
                    line[3])
            );
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter)
        {
            IEnumerable<IPerson> people = new SampleData().People;

            IEnumerable<(string FirstName, string LastName)> result = people
                .Where(x => filter(x.EmailAddress))
                .Select(name => (first: name.FirstName, last: name.LastName));

            return result;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => people.Select(person => person.Address.State).Distinct().Aggregate((statesList, nextState) => statesList + ", " + nextState);
       
    }
}
