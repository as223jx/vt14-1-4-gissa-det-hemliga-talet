using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gissa_det_hemliga_talet.Model;

namespace Gissa_det_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber Secretnumber {
            get
            {
                return Session["SecretNumber"] as SecretNumber;
            }

            set
            {
                Session["SecretNumber"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GuessBox.Focus();
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int guess = int.Parse(GuessBox.Text);

                if (guess < 1 || guess > 100)
                {
                    throw new ArgumentOutOfRangeException("Fel! Du måste ange ett tal mellan 1-100!");
                }

                else
                {
                    var makeGuess = new SecretNumber();
                    makeGuess.Outcome = makeGuess.MakeGuess(guess);

                    if (makeGuess.Outcome == Outcome.NoMoreGuesses)
                    {

                    }

                    if (makeGuess.Outcome == Outcome.Correct)
                    {

                    }

                    if (makeGuess.Outcome == Outcome.Low || makeGuess.Outcome == Outcome.High)
                    {
                        PastGuesses.Text = String.Format("{0}", guess);
                    }
                }
            }
        }
    }
}