using System;
using System.Globalization;
using System.Text;

namespace Progtest05
{
    public class TestDataGenerator
    {
        private DateTime _maxDateSoFar = new DateTime(1800, 1, 1);
        private Random _random = new Random();

        public String GetNewReview()
        {
            return " + " + GetNewDate() + " " + _random.Next(1, 4097) + " " +
                   GetRandomString(_random.Next(2, 64)) + "\n";
        }

        private string GetRandomString(int wordSize)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append((char)(_random.NextDouble() * (90 - 65) + 65));
            for (int j = 0; j < wordSize; j++)
            {
                stringBuilder.Append((char)(_random.NextDouble() * (122 - 97) + 97));
            }

            return stringBuilder.ToString();
        }

        private string GetNewDate()
        {
            if (_maxDateSoFar > new DateTime(2999, 12, 1))
                return new DateTime(2999, 12, 31).ToString("yyyy-M-dd");

            _maxDateSoFar = _maxDateSoFar.AddDays(_random.Next(0, 5) * _random.Next(0, 5));
            return _maxDateSoFar.ToString("yyyy-M-dd");
        }

        public string GetNewQuery()
        {
            return " # " + _random.Next(1, (int)(Int32.MaxValue * 0.75)) + "\n";
        }
    }
}