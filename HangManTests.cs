﻿using NUnit.Framework;

namespace HangMan.Tests
    {
    public class HangManTests
        {
        public Game Game { get; set; }
        [Test]
        public void PlayerWins ()
            {
            Game = new Game();
            GivenListOfLettersandRetries(new string[] { "AI" }, 0);
            var result = WhenPlayerGuessesWords(new char[] { 'A', 'I' });
            Assert.AreEqual(Outcomes.PlayerWins, result);
            }

        [Test]
        public void PlayerGuessesARightLetter ()
            {
            Game = new Game();
            GivenListOfLettersandRetries(new string[] { "AI" }, 0);
            var result = WhenPlayerGuessesWords(new char[] { 'G', 'H', 'L', 'A' });
            Assert.AreEqual(Outcomes.PlayerContinues, result);
            Assert.AreEqual(3, Game.TotalTries);
            }

        [Test]
        public void PlayerGuessesAllTheRightLetterWithNineAttemptsAndNoRepeatedWords ()
            {
            Game = new Game();
            GivenListOfLettersandRetries(new string[] { "AI" }, 0);
            var result = WhenPlayerGuessesWords(new char[] { 'A', 'M', 'N', 'P', 'K', 'F', 'O', 'L', 'I' });
            Assert.AreEqual(Outcomes.PlayerWins, result);
            Assert.AreEqual(8, Game.TotalTries);
            }

        [Test]
        public void PlayerGuessesOneRightLetterWithTenAttemptsAndLosesWithNoRepeatedWords ()
            {
            Game = new Game();
            GivenListOfLettersandRetries(new string[] { "AI" }, 0);
            var result = WhenPlayerGuessesWords(new char[] { 'A', 'M', 'N', 'P', 'K', 'F', 'O', 'L', 'Q', 'D' });
            Assert.AreEqual(Outcomes.PlayerLooses, result);
            Assert.AreEqual(9, Game.TotalTries);
            }

        private object WhenPlayerGuessesWords ( char[] letters )
            {
            return Game.PlayerGuessesAWord(letters);
            }

        private void GivenListOfLettersandRetries ( string[] name, int totalTries )
            {
            Game.MovieName = string.Join("", name).Trim();
            Game.TotalTries = totalTries;
            }
        }
    }
