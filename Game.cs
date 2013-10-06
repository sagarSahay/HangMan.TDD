using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan.Tests
    {
    public class Game
        {
        public int TotalTries { get; set; }
        public List<char> CorrectGuessedLetters = new List<char>();
        public List<char> InCorrectGuessedLetters = new List<char>();

        public string MovieName
            {
            get;
            set;
            }

        public Outcomes PlayerGuessesAWord ( char[] movieName )
            {
            //if (MovieName == string.Join("", movieName) && TotalTries <= 10)
            //    {
            //    return Outcomes.PlayerWins;
            //    }
            //else
            //    {


            //    }
            if (TotalTries <= 9)
                {
                foreach (char s in movieName)
                    {
                    if (MovieName.ToCharArray().Any(x => x == s))
                        {
                        if (!CorrectGuessedLetters.Any(y => y == s))
                            {
                            CorrectGuessedLetters.Add(s);
                            TotalTries = TotalTries + 1;
                            }

                        IEnumerable<char> diff = MovieName.Distinct().ToList().Except(CorrectGuessedLetters);
                        if (diff.Count() == 0 && TotalTries <= 9)
                            {
                            return Outcomes.PlayerWins;
                            }
                        }
                    else
                        {
                        if (!InCorrectGuessedLetters.Any(y => y == s))
                            {
                            InCorrectGuessedLetters.Add(s);
                            TotalTries = TotalTries + 1;
                            }

                        }
                    if (TotalTries >= 9)
                        {
                        return Outcomes.PlayerLooses;
                        }
                    }

                return Outcomes.PlayerContinues;
                }
            else
                {
                return Outcomes.PlayerLooses;
                }
            }
        }
    }
