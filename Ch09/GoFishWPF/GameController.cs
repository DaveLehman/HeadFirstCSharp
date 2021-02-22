using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace GoFishWPF
{
    public class GameController
    {
        public static Random Random = new Random();

        private GameState gameState;

        public bool GameOver { get { return gameState.GameOver; } }
        public Player HumanPlayer { get { return gameState.HumanPlayer; } }
        public IEnumerable<Player> Opponents { get { return gameState.Opponents; } }

        // Used by constructor, NextRound() and NewGame() so the app can write messages for the player
        // Now that we're doing a WPF app, this is databound to the GameProgress TextBox...
        public string Status { get; private set; }

        // unfortunately console design buried "David has 6 cards and 0 books" in the Status string
        // We need a new property of a string containing "Cindy has a book of Fives"...so that we can
        // populate the Books ListBox. Similarly we need a list of .... representing the cards in 
        // the players' hands for the YourHand ListBox
        public IEnumerable<string> BookStatus { get { return (List<string>)gameState.allBooks; } }
       // public IEnumerable<string> PlayerHand { get { return (List<string>)gameState.HumanPlayer.Hand; } }

        // To create a data-bound object in the Window Resources, need a parameterless constructor
        // Will have to populate it later
        public GameController()
        {
            
        }
        /// <summary>
        /// Constructs a new GameController
        /// </summary>
        /// <param name="humanPlayerName">Name of the human player</param>
        /// <param name="computerPlayerNames">Name of the computer players</param>
        public GameController(string humanPlayerName, IEnumerable<string> computerPlayerNames)
        {
            gameState = new GameState(humanPlayerName, computerPlayerNames, new Deck().Shuffle());
            Status = $"Starting a new game with players {String.Join(", ", gameState.Players)}";

        }

        /// <summary>
        /// Plays the next round, ending the game if everyone ran out of cards
        /// </summary>
        /// <param name="playerToAsk">Which player the human is asking for a card</param>
        /// <param name="valueToAskFor">The value fot eh card the human is asking for</param>
        public void NextRound(Player playerToAsk, Values valueToAskFor)
        {
            Debug.WriteLine("Next round starting");
            Status = gameState.PlayRound(gameState.HumanPlayer, playerToAsk, valueToAskFor, gameState.Stock) + Environment.NewLine;
            ComputerPlayersPlayNextRound();
            Status += string.Join(Environment.NewLine, gameState.Players.Select(player => player.Status));
            Status += $"{Environment.NewLine}The stock has {gameState.Stock.Count()} cards";
            Status += Environment.NewLine + gameState.CheckForWinner();
            Debug.WriteLine("Next round ending");
        }

        // Unit test only test public class members. Can't test this one directly, but we'll know it works
        // if the test for NextRound() passes...
        /// <summary>
        /// All of the computer players that have cards play the next round. If the human is
        /// out of cards, then the deck is depleted and they play out the rest of the game.
        /// </summary>
        private void ComputerPlayersPlayNextRound()
        {
            IEnumerable<Player> computerPlayersWithCards;
            do
            {
                computerPlayersWithCards =
                    gameState
                        .Opponents
                        .Where(player => player.Hand.Count() > 0);
                foreach (Player player in computerPlayersWithCards)
                {
                    var randomPlayer = gameState.RandomPlayer(player);
                    var randomValue = player.RandomValueFromHand();
                    Status += gameState.PlayRound(player, randomPlayer, randomValue, gameState.Stock) + Environment.NewLine;
                }
            } while ((gameState.HumanPlayer.Hand.Count() == 0) && (computerPlayersWithCards.Count() > 0));

        }

        /// <summary>
        /// Starts a new game with the same player names
        /// </summary>
        public void NewGame()
        {
            Status = "Starting a new game";
            gameState = new GameState(gameState.HumanPlayer.Name, gameState.Opponents.Select(player => player.Name), new Deck().Shuffle());
        }

    }


}
