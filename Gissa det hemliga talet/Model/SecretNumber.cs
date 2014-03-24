using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_det_hemliga_talet.Model
{
    public class SecretNumber
    {
        int _number;
        List<int> _previousGuesses;
        const int MaxMumberOfGuesses = 7;

        public bool CanMakeGuess { get; }
        public int Count { get; }
        public int Number { get; }
        public Outcome Outcome { get; set; }
        public IEnumerable<int> PreviousGuesses { get; }

        public void Initialize()
        {
            Random random = new Random();
            int number = random.Next(1, 101);
            _number = number;

            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException("Fel! Du måste ange ett tal mellan 1-100!");
            }

            else if (_previousGuesses.Count == MaxMumberOfGuesses)
            {
                return Outcome.NoMoreGuesses;
            }

            else if (guess == _number)
            {
                return Outcome.Correct;
            }

            else if (guess < _number)
            {
                return Outcome.Low;
            }

            else if (guess > _number)
            {
                return Outcome.High;
            }
        }

        public SecretNumber()
        {
            if (_number == null)
            {
                Initialize();
            }
        }
    }

    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }
}