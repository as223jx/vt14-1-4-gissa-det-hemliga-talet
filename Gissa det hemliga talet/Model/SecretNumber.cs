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
        public int? Number { get; }
        public Outcome Outcome { get; set; }
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        public void Initialize()
        {
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
            Random random = new Random();
            int number = random.Next(1, 101);
            _number = number;
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

            else
            {
                if (guess == _number)
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
                _previousGuesses.Add(guess);
            }
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxMumberOfGuesses);
            Initialize();
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