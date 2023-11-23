using System;
using System.Globalization;
using System.Text;

namespace Progtest05
{
    public class TestDataGenerator
    {
        private DateTime _maxDateSoFar = new DateTime(1800, 1, 1);
        private Random _random = new Random();
        private int _maxReviewRating = 0;
        private int _reviewCount = 0;

        public String GetNewReview()
        {
            int score = _random.Next(1, 4097);
            if (score > _maxReviewRating)
                _maxReviewRating = score;
            _reviewCount++;
            return "+ " + GetNewDate() + " " + score + " " +
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
            return "# " + _random.Next(1,
                (int)(_maxReviewRating * _reviewCount * (_random.NextDouble() + _random.NextDouble()))) % Int32.MaxValue + "\n";
        }
    }
}