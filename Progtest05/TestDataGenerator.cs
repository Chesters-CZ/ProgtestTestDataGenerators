using System;
using System.Text;

namespace Progtest05
{
    public class TestDataGenerator
    {
        private DateTime _maxDateSoFar = new DateTime(1800, 1, 1);
        private Random _random = new Random();

        public String GetNewTestData()
        {
            return GetNewDate() + " " + _random.Next(1, Int32.MaxValue / 2) + " " +
                   GetRandomString(_random.Next(2, 64)) + "\n";
        }

        private string GetRandomString(int wordSize)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            stringBuilder.Append((char)(random.NextDouble() * (90 - 65) + 65));
            for (int j = 0; j < wordSize; j++)
            {
                stringBuilder.Append((char)(random.NextDouble() * (122 - 97) + 97));
            }

            return stringBuilder.ToString();
        }

        private string GetNewDate()
        {
            if (_maxDateSoFar > new DateTime(2999, 12, 1))
                return new DateTime(2999, 12, 31).ToString();
            
            _maxDateSoFar = _maxDateSoFar.AddDays(_random.Next(0, 5) * _random.Next(0, 5));
            return _maxDateSoFar.ToShortDateString();
        }
    }
}