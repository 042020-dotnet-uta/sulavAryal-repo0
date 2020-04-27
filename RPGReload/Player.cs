using System;
using System.Collections.Generic;
using System.Text;

namespace RPGReload
{
   
    #region PlayerClass
    public class Player
    {
        //Set player names
        private string playerName;
        public string Name
        {
            get { return playerName; }
            set { playerName = value; }
        }
    }
    #endregion
    #region Round Class 
    class Round
    {
        //Declaration of winner
        //Player 1 choice
        //Player 2 choice
        private Player winner;
        public Player Winner { get => winner;  set => winner = value;  }
        public string playerOneChoice;
        public string playerTwoChoice;
    }
    #endregion
    #region Game Class
    class Game
    {
        //List of rounds to be stored
        // store each player
        public List<Round> rounds;
        public Player P1 { get; set; }
        public Player P2 { get; set; }
    }
    #endregion
    #region Generate Random Numbers
    class GenerateRandomNumber
    {
        string[] rockPaperScis = { "rock", "paper", "scissors" };
        private int playerRand;
        Random rand = new Random();
        //Randomly select rock/paper/scissors
        //Returns a random hand
        public string ChooseHand()
        {
            // create an array of strings that will hold the values of "Rock", "Paper", "Scissors" to compare and decide winne

        }
    }
    #endregion
    #region Run Game
    class RunGame 
    {
        //Instantiate players
        public Player p1 = new Player();
        public Player p2 = new Player();
        //the functionality needed to run the game
    }
    #endregion
}

/* 
OutLine::
  Classes:
      PlayerInfo
          Player name
          Player Wins
      Generate Random Numbers
      Game
      Main Class
      Rounds
*/