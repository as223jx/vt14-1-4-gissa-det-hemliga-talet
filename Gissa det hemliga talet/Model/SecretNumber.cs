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

        public bool CanMakeGuess
        {
            get
            {
                return _previousGuesses.Count < MaxMumberOfGuesses && !_previousGuesses.Contains(_number);
            }
        }

        public int Count
        {
            get
            {
                return _previousGuesses.Count;
            }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }

        public Outcome Outcome { get; private set; }

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

            if (PreviousGuesses.Contains(guess))
            {
                Outcome = Outcome.PreviousGuess;
            }

            else
            {
                if (guess == _number)
                {
                    Outcome = Outcome.Correct;
                }

                else if (guess < _number)
                {
                    Outcome = Outcome.Low;
                }

                else if (guess > _number)
                {
                    Outcome = Outcome.High;
                }
                _previousGuesses.Add(guess);
            }
            return Outcome;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxMumberOfGuesses);
            Initialize();
        }
    }
}