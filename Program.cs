namespace RockPaperScissorsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Rock = "Rock";
            const string Paper = "Paper";
            const string Scissors = "Scissors";

            Console.WriteLine("Welcome to my simple console game called: ROCK, PAPER, SCISSORS!");

            bool playAgain = true;

            while (playAgain)
            {
                int playerScore = 0;
                int computerScore = 0;

                while (playerScore < 3 && computerScore < 3)
                {
                    string playerMove = GetPlayerMove();
                    string computerMove = GetComputerMove();

                    Console.WriteLine($"The opponent chose: {computerMove}");

                    int roundResult = DetermineWinner(playerMove, computerMove);

                    if (roundResult == 1)
                    {
                        playerScore++;
                        Console.WriteLine("You Win this round!");
                    }
                    else if (roundResult == -1)
                    {
                        computerScore++;
                        Console.WriteLine("You Lose this round!");
                    }
                    else
                    {
                        Console.WriteLine("This round was a Draw.");
                    }

                    Console.WriteLine($"\nScore: You [{playerScore}] - [{computerScore}] Computer\n");
                }

                Console.WriteLine(playerScore == 3
                    ? "Congratulations! You won the game!"
                    : "The computer won the game. Better luck next time!");

                // Ask the player if they want to play again (with proper validation)
                playAgain = AskToPlayAgain();
            }

            Console.WriteLine("\nThanks for playing! Goodbye!");
        }

        static string GetPlayerMove()
        {
            while (true)
            {
                Console.WriteLine("\nChoose: [R]ock, [P]aper, [S]cissors");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "r" || input == "rock") return "Rock";
                if (input == "p" || input == "paper") return "Paper";
                if (input == "s" || input == "scissors") return "Scissors";

                Console.WriteLine("Invalid Input! Please enter R, P, or S.");
            }
        }

        static string GetComputerMove()
        {
            Random random = new Random();
            int choice = random.Next(1, 4);
            return choice switch
            {
                1 => "Rock",
                2 => "Paper",
                _ => "Scissors",
            };
        }

        static int DetermineWinner(string player, string computer)
        {
            if (player == computer) return 0; // Draw
            if ((player == "Rock" && computer == "Scissors") ||
                (player == "Paper" && computer == "Rock") ||
                (player == "Scissors" && computer == "Paper"))
            {
                return 1; // Player wins
            }
            return -1; // Computer wins
        }

        static bool AskToPlayAgain()
        {
            while (true)
            {
                Console.WriteLine("\nDo you want to play again? (Y/N)\n");
                string response = Console.ReadLine().Trim().ToLower();

                if (response == "y" || response == "yes") return true;
                if (response == "n" || response == "no") return false;

                Console.WriteLine("Invalid input! Please enter Y or N.");
            }
        }
    }
}
