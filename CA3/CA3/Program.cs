using System.Numerics;

namespace CA3;

class Program
{
    static void Main(string[] args)
    {
        //setup
        string playerChoice = "y", stickTwist = "";

        //create player and dealer objects
        Player p1 = new Player("Player 1", 0);
        Player Dealer = new Player("Dealer", 0);

        //loop to control gameplay
        while (playerChoice == "y")
        {
            //game title
            Console.WriteLine("\n--- LETS PLAY BLACKJACK !!! ---");
            Console.WriteLine();

            //reset scores if game is on repeat
            p1.Score = 0;
            Dealer.Score = 0;

            //create new Deck object to use DealCard() method
            Deck Deck = new Deck();

            //player 1 plays
            Console.WriteLine("____ {0}'s Turn ____", p1.Name);

            //deal first 2 cards using Deck.DealCard() method
            for (int i = 0; i < 2; i++)
            {
                p1.Score += Deck.DealCard(p1.Score);
            }

            //display player 1 score
            Console.WriteLine("Player 1 score : {0}", p1.Score);

            //ends game short if player 1 is bust
            if (p1.Score <= 21)
            {

                //ask to stick or twist
                Console.Write("Do you want to stick or twist : s/t >> ");
                stickTwist = Console.ReadLine();

                if (stickTwist == "t")
                {
                    while (stickTwist != "s")
                    {
                        //deal card
                        p1.Score += Deck.DealCard(p1.Score);
                        Console.WriteLine("Player 1 score : {0}", p1.Score);

                        //check if score is higher than 21 
                        if (p1.Score > 21)
                            break;
                        //ask again
                        Console.Write("\nDo you want to stick or twist : s/t >> ");
                        stickTwist = Console.ReadLine();
                    }
                }
            }

            //dealer plays only if player 1 is still in the game
            if (p1.Score <= 21)
            {

                Console.WriteLine("\n____ {0}'s Turn ____", Dealer.Name);

                //deal first two cards
                for (int i = 0; i < 2; i++)
                {
                    Dealer.Score += Deck.DealCard(Dealer.Score);
                }

                Console.WriteLine("Dealers Score : {0}\n", Dealer.Score);

                if (Dealer.Score < 17)
                    while (Dealer.Score < 17)
                    {
                        Dealer.Score += Deck.DealCard(Dealer.Score);
                        Console.WriteLine("Dealers Score : {0}", Dealer.Score);
                    }

            }

            //display player bust
            if (p1.Score > 21)
                Console.WriteLine(p1.Name + " BUST!!");
            else if (Dealer.Score > 21)
                Console.WriteLine(Dealer.Name + " BUST!!");

            //calculate and display winner
            GetWinner(p1.Score, Dealer.Score);

            if (p1.Score > Dealer.Score && p1.Score <= 21 || Dealer.Score > 21 && p1.Score < 21)
                RockPaperScissors();

            Console.WriteLine("\n--- GAME OVER ---");
            Console.Write("Do you want to play again: y/n ? >> ");
            playerChoice = Console.ReadLine();

        } //end of gameplay loop

        Console.WriteLine("\n--- Have a Nice Day! ---");
        Console.ReadLine(); //pause

    }  //end of main method


    //method to calculate and display winner
    public static void GetWinner(int p1Score, int dealerScore)
    {
        if (p1Score > dealerScore && p1Score <= 21)
            Console.WriteLine("\nPlayer 1 Wins!!!");

        else if (dealerScore > p1Score && dealerScore <= 21)
            Console.WriteLine("\nDealer Wins!!!");

        else if (p1Score == dealerScore && p1Score <= 21 && dealerScore <= 21)
            Console.WriteLine("\nIts a draw!!!");

        else if (dealerScore > 21 && p1Score < 21)
            Console.WriteLine("\nPlayer 1 Wins!!!");
    }


    //BONUS GAME - Rock, Paper Scissors Game
    //this method uses the same logic as the DealCard() method...
    //...by inputting a random number into an array index
    public static void RockPaperScissors()
    {
        int i;
        string playerChoice = "";

        string[] choices = new string[] { "rock", "paper", "scissors" };

        Random rng = new Random();

        //game is in a do while loop incase a draw happens
        do
        {

            i = rng.Next(0, 3);

            Console.Write("\nEnter your choice: rock, paper or scissors >> ");
            playerChoice = Console.ReadLine();

            Console.WriteLine("Computer throws {0}", choices[i]);

            //the following logic controls the games outcome
            if (choices[i] == "rock" && playerChoice == "scissors")
                Console.WriteLine("\nYou Lose!!");

            else if (playerChoice == "rock" && choices[i] == "scissors")
                Console.WriteLine("\nCongratulations!! You have won 1 million euros!! To collect your prize, head to ATU Sligo and ask for Keith");

            else if (choices[i] == "paper" && playerChoice == "rock")
                Console.WriteLine("\nYou Lose!!");

            else if (playerChoice == "paper" && choices[i] == "rock")
                Console.WriteLine("\nCongratulations!! You have won 1 million euros!! To collect your prize, head to ATU Sligo and ask for Keith");

            else if (choices[i] == "scissors" && playerChoice == "paper")
                Console.WriteLine("\nYou Lose!!");

            else if (playerChoice == "scissors" && choices[i] == "paper")
                Console.WriteLine("\nCongratulations!! You have won 1 million euros!! To collect your prize, head to ATU Sligo and ask for Keith");

            else if (playerChoice == choices[i])
                Console.WriteLine("\nIts a draw -- Play again...");

            else Console.WriteLine("\nIncorrect Choice");

        } while (choices[i] == playerChoice); //repeats game if a draw occurs

    }

}

