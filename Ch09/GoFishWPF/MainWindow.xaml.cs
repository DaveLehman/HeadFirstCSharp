using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;

namespace GoFishWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // I need a new Instance of GameController every time I start a new game, so I haven't figured out a way
        // to use a game controller as a static resource with data binding. Therefore we're doing a lot of
        // showing/hiding of controls by hand

        GameController gameController;
        bool debug = true;
        string humanName;
        List<string> computerPlayerNames;
        Player opponentToAsk;
        Values valueToAskFor;
        public MainWindow()
        {
            //gameController = this.Resources["gameController"] as GameController; used with static resource
            InitializeComponent();
            // the get player name and computer opponent names and play button need to be shown
            SetControlVisibilities(true);


        }

        private void MainLoop()
        {
            // When we enter MainLoop, GameOver is false (the Game is not running)
            // the non-game controls are displayed,
            // there is no GameController instance (at least first run), 
            // and player just clicked the Play button
            ValidateNames();
            // now have at least a player and a computer opponent 
            gameController = new GameController(humanName, computerPlayerNames);
            // this control doesn't need updating every round so let's do it once
            PopulateOpponentsAskLB();
            gameController.NewGame();
            SetControlVisibilities(gameController.GameOver);
            GameLoop();
        }

        private void PopulateOpponentsAskLB()
        {
            OpponentsAskLB.Items.Clear();
            //GameController object exists
            foreach(Player opponentPlayer in gameController.Opponents)
            {
                OpponentsAskLB.Items.Add(opponentPlayer);
            }
        }

        private void GameLoop()
        {
            if (debug)
                Debug.WriteLine("Top of game loop");

            // We're loop-driven, not event-driven (except ask for a card)
            // so we have to update the controls at the bottom of the loop
            //while(!gameController.GameOver)
            //{
            //while (gameController.GameOver)
            //{
                
            //}

            UpdateGameControls();
            //}
            if (debug)
                Debug.WriteLine("Bottom of game loop");
        }

        private void UpdateGameControls()
        {
            // Update the controls -- need to update Game Progress, Your Hand, Books
            GameProgressTBox.Text = gameController.Status;
            YourHandLB.Items.Clear();
            foreach (var card in gameController.HumanPlayer.Hand
                .OrderBy(card => card.Suit)
                .OrderBy(card => card.Value))
                YourHandLB.Items.Add(new ListBoxItem().Content = card);
            BooksLB.Items.Clear();
            foreach (var book in gameController.BookStatus)
                BooksLB.Items.Add(new ListBoxItem().Content = book);
        }

        private void EnterGameLoop()
        {
            // Console loop was
            /*while (!gameController.GameOver)
{
    while (!gameController.GameOver)
    {
                            Console.WriteLine("Your hand:");
        foreach (var card in gameController.HumanPlayer.Hand
            .OrderBy(card => card.Suit)
            .OrderBy(card => card.Value))
            Console.WriteLine(card);
        var value = PromptForAValue();
        var player = PromptForAnOpponent();
        gameController.NextRound(player, value);
        Console.WriteLine(gameController.Status);
    } // inner while
    Console.WriteLine("Press Q to quit, or any other key for a new game.");
    if (Console.ReadKey(true).KeyChar.ToString().ToUpper() != "Q")
        gameController.NewGame();

    }
    // play again? If yes, new gameController(GameOver goes false again)
}*/


        }
        private void ValidateNames()
        {
            // need to make sure there is a name for the human and at least one computer opponent
            if (debug)
            {
                Debug.WriteLine("PlayGameBtn click");
                Debug.WriteLine("Contents of ...");
                Debug.WriteLine($"Player: {PlayerNameTBox.Text} length {PlayerNameTBox.Text.Length} ");
                Debug.WriteLine($"OpponentTB0: {OpponentTB0.Text} length {OpponentTB0.Text.Length}");
                Debug.WriteLine($"OpponentTB1: {OpponentTB1.Text} length {OpponentTB1.Text.Length}");
                Debug.WriteLine($"OpponentTB2: {OpponentTB2.Text} length {OpponentTB2.Text.Length}");
                Debug.WriteLine($"OpponentTB3: {OpponentTB3.Text} length {OpponentTB3.Text.Length}");
            }

            humanName = PlayerNameTBox.Text.Trim();
            if (humanName.Length == 0)
                humanName = "Human";
            computerPlayerNames = new List<string>();
            if (OpponentTB0.Text.Trim().Length > 0)
                computerPlayerNames.Add(OpponentTB0.Text.Trim());
            if (OpponentTB1.Text.Trim().Length > 0)
                computerPlayerNames.Add(OpponentTB1.Text.Trim());
            if (OpponentTB2.Text.Trim().Length > 0)
                computerPlayerNames.Add(OpponentTB2.Text.Trim());
            if (OpponentTB3.Text.Trim().Length > 0)
                computerPlayerNames.Add(OpponentTB3.Text.Trim());

        }

        private void SetControlVisibilities(bool gameNotRunning)
        {
            if (debug)
                Debug.WriteLine($"Setting controls parameter {gameNotRunning}");
            if (gameNotRunning)
            {
                // setup items
                PlayGameBtn.Visibility = Visibility.Visible;
                QuitBtn.Visibility = Visibility.Visible;
                PlayerNameLbl.Visibility = Visibility.Visible;
                OpponentListLbl.Visibility = Visibility.Visible;
                PlayerNameLV.Visibility = Visibility.Visible;
                OpponentTB.Visibility = Visibility.Visible;
                // game items

                AskBtn.Visibility = Visibility.Collapsed;
                GameProgressLbl.Visibility = Visibility.Collapsed;
                BooksLbl.Visibility = Visibility.Collapsed;
                HandLbl.Visibility = Visibility.Collapsed;
                AskLbl.Visibility = Visibility.Collapsed;
                GameProgressTBox.Visibility = Visibility.Collapsed;
                BooksLB.Visibility = Visibility.Collapsed;
                YourHandLB.Visibility = Visibility.Collapsed;
                OpponentsAskLB.Visibility = Visibility.Collapsed;

            }
            else
            {
                // setup items buttons, labels, boxes
                PlayGameBtn.Visibility = Visibility.Collapsed;
                QuitBtn.Visibility = Visibility.Collapsed;
                PlayerNameLbl.Visibility = Visibility.Collapsed;
                OpponentListLbl.Visibility = Visibility.Collapsed;
                PlayerNameLV.Visibility = Visibility.Collapsed;
                OpponentTB.Visibility = Visibility.Collapsed;
                // game items buttons labels boxes
                AskBtn.Visibility = Visibility.Visible;
                GameProgressLbl.Visibility = Visibility.Visible;
                BooksLbl.Visibility = Visibility.Visible;
                HandLbl.Visibility = Visibility.Visible;
                AskLbl.Visibility = Visibility.Visible;
                GameProgressTBox.Visibility = Visibility.Visible;
                BooksLB.Visibility = Visibility.Visible;
                YourHandLB.Visibility = Visibility.Visible;
                OpponentsAskLB.Visibility = Visibility.Visible;
            }

        }

        private void InitializeGameController()
        {
            gameController = new GameController("David", new List<String>() { "Brittney", "Cindy", "Betty" });

        }

        private void AskBtn_Click(object sender, RoutedEventArgs e)
        {
            // for the player to ask for a card we have to have an opponent selected and
            // we need to get the value of the card he clicked on this reoutine will
            // return to the loop until we have a valid ask
            bool validCard = false;
            bool validOpponent = false;


            while (!validCard && !validOpponent)
            {
                // Has player selected a card?
                var itemSelected = YourHandLB.SelectedItem;
                if (itemSelected == null)
                {
                    MessageBox.Show("Select a card in your Hand so I know what value to ask for",
                        "Click a Card!", MessageBoxButton.OK);
                        validCard = false;
                }
                else
                {
                    // YourHandLB.SelectedItem is a Card object
                    Card cardSelected = (Card)YourHandLB.SelectedItem;
                    valueToAskFor = cardSelected.Value;
                    validCard = true;
                }
                // has player selected an opponent to ask?
                itemSelected = OpponentsAskLB.SelectedItem;
                if (itemSelected == null)
                {
                    MessageBox.Show("Select an Opponent to ask",
                        "Click an Opponent!", MessageBoxButton.OK);
                    validOpponent = false;
                }
                else
                {
                    opponentToAsk = (Player)itemSelected;
                    validOpponent = true;
                }

            } //end loop
            gameController.NextRound(opponentToAsk, valueToAskFor);
            if (debug)
                Debug.WriteLine($"Leaving AskBtn click");
            UpdateGameControls();
            return;

        } // ask button click

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayGameBtn_Click(object sender, RoutedEventArgs e)
        {
            MainLoop();
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
