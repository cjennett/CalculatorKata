using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorKata
{
    public class Calculator
    {
        public int Add(string values)
        {
            if (string.IsNullOrEmpty(values))
                return 0;
            return HasCustomerDelimiter(values) ? SumWithCustomerDelimiter(values) : SumWithDefaultDelimiters(values);
        }

        private static int SumWithDefaultDelimiters(string values)
        {
            var seperators = new[] {',', '\n'};
            return Sum(values, seperators);
        }

        private static int SumWithCustomerDelimiter(string values)
        {
            var strings = values.Split('\n');
            var seperators = Convert.ToChar(strings[0].Substring(2, 1));
            return Sum(strings[1], seperators);
        }

        private static bool HasCustomerDelimiter(string values)
        {
            return values.StartsWith("//");
        }

        private static int Sum(string values, params char[] seperators)
        {
            var splitString = values.Split(seperators);
            CheckForInvalidNumbers(splitString);
            CheckForNegativeNumbers(splitString);

            return splitString.Sum(value => Convert.ToInt32(value));

        }

        private static void CheckForNegativeNumbers(IEnumerable<string> splitString)
        {
            var negativeNumbers = string.Join(" ", splitString.Where(IsNegativeNumber).Select(s => s));
            if(!string.IsNullOrEmpty(negativeNumbers))
                throw new Exception(negativeNumbers.Trim());
        }

        private static void CheckForInvalidNumbers(IEnumerable<string> splitString)
        {
            var invalidNumbers = string.Join(" ", splitString.Where(s => !IsNumber(s)).Select(s => s));
            if (!string.IsNullOrEmpty(invalidNumbers))
                throw new InvalidOperationException(invalidNumbers);
        }

        private static bool IsNegativeNumber(string value)
        {
            return IsNumber(value) && Convert.ToInt32(value) < 0;
        }

        private static bool IsNumber(string value)
        {
            int num;
            return int.TryParse(value, out num);
        }
    }
}
