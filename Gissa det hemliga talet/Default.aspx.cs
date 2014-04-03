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
        public SecretNumber secretnumber {
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

            if (secretnumber == null)
            {
                this.secretnumber = new SecretNumber();
            }
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
                    var newguess = secretnumber.MakeGuess(guess);

                    if (Outcome.Correct == newguess)
                    {
                        Result.Text += String.Format("RÄTT! Det hemliga talet var {0} och du klarade det på {1} drag!", secretnumber.Number, secretnumber.Count);
                    }

                    if (Outcome.Low == newguess)
                    {
                        Result.Text += String.Format("För lågt! ");
                    }

                    if (Outcome.High == newguess)
                    {
                        Result.Text += String.Format("För högt! ");
                    }

                    if (!secretnumber.CanMakeGuess && secretnumber.Outcome != Outcome.Correct)
                    {
                        Result.Text += String.Format("Du har inga gissningar kvar! Det hemliga talet var {0}.", secretnumber.Number);
                        SendButton.Enabled = false;
                        NewRandomButton.Enabled = true;
                    }

                    string previous = String.Join(", ", secretnumber.PreviousGuesses);
                    PastGuesses.Text = String.Format("Du har gissat på {0}", previous);
                    PlaceHolder.Visible = true;
                }
            }
        }

        protected void NewRandomButton_Click(object sender, EventArgs e)
        {
            secretnumber.Initialize();
        }
    }
}