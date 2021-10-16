using System;
using System.Collections.Generic;
using System.Linq;

namespace Kmart.Business
{
    public class Service
    {
        public string GetLongestIncreasingSubsequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input parameter cannot be null, empty or white spaces", nameof(input));
            }

            var tokens = input.Split(' ');

            if (tokens.Any(t => !int.TryParse(t, out int result)))
            {
                throw new ArgumentException("One or more values in input are not valid integer", nameof(input));
            }

            var allLists = new List<List<int>>();
            var values = input.Split(' ').Select(v => Convert.ToInt32(v)).ToList();

            for (int i = 0; i < values.Count; i++)
            {
                if (i == 0)
                {
                    allLists.Add(new List<int> { values[i] });
                }
                else
                {
                    if (values[i] > values[i - 1])
                    {
                        allLists.Last().Add(values[i]);
                    }
                    else
                    {
                        allLists.Add(new List<int> { values[i] });
                    }
                }
            }

            var longestList = allLists.OrderByDescending(l => l.Count).FirstOrDefault() ?? new List<int>();

            return string.Join(" ", longestList);
        }
    }
}
