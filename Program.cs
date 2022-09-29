// Lindsay Garner
// cse210 Tic Tac Toe Game

using System;

namespace TicTacToe
{
  class Program
  {
    static void Main(string[] args)
    {
        bool winner = false;
        string turn = "X";
        // Process of the game
        List<string> board = CreateBoard();
        DisplayBoard(board);
        int TurnsTaken = 0;
                
        while (!winner)
        {
            // Step 1: Display Board
            
            // Step 2: Get Input & Validate it
            string choice = GetInput(turn);

            // Step 3: Edit Board
            EditBoard(choice, board, turn);
            DisplayBoard(board);

            // Step 4: Check Winner
            winner = CheckingWinner(board, TurnsTaken, turn);
            
            // Step 5: Get turn from TurnManager
            turn = TurnManager(turn);
            TurnsTaken += 1;
            
        }

        Console.WriteLine("Good Game!");
        
    }

    static List<string> CreateBoard()
    {
        List<string> board = new List<string> {"1","2","3","4","5","6","7","8","9"};

        return board;
    }

    static void DisplayBoard(List<string> board)
    {
        Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        Console.WriteLine("");
    }

    static string TurnManager(string turn)
    {
        if(turn == "X")
        {
            turn = "O";
        }

        else if (turn == "O")
        {
            turn = "X";
        }

        else
        {
            Console.WriteLine("error");
        }

        return turn;

        
    }

    static string GetInput(string turn)
    {
        // Get input
        string choice = "";
        if(turn == "X")
        {
            Console.Write("X's turn to choose a square (1-9): ");
            choice = Console.ReadLine();
            
        }
        else if(turn == "O")
        {
            Console.Write("O's turn to choose a square (1-9): ");
            choice = Console.ReadLine();
        } 
        
        else 
        {
          choice = "error";   
        }
        return choice;
        
    }
    static void EditBoard(string choice, List<string> board, string PlayerTurn)
    {  
       int edits = int.Parse(choice) - 1;
       board[edits] = PlayerTurn;  
    }

    static bool CheckingWinner(List<string> board, int TurnCount, string PlayerTurn)
    {
        bool winner = false;
        if ((board[0] == PlayerTurn && board[1] == PlayerTurn && board[2] == PlayerTurn)
        ||(board[3] == PlayerTurn && board[4] == PlayerTurn && board[5] == PlayerTurn)
        ||(board[6] == PlayerTurn && board[7] == PlayerTurn && board[8] == PlayerTurn)
        ||(board[0] == PlayerTurn && board[3] == PlayerTurn && board[6] == PlayerTurn)
        ||(board[1] == PlayerTurn && board[4] == PlayerTurn && board[7] == PlayerTurn)
        ||(board[2] == PlayerTurn && board[5] == PlayerTurn && board[8] == PlayerTurn)
        ||(board[2] == PlayerTurn && board[4] == PlayerTurn && board[6] == PlayerTurn)
        ||(board[0] == PlayerTurn && board[4] == PlayerTurn && board[8] == PlayerTurn))
        {
            winner = true;
        }
  
        else if (TurnCount > 9)
        {
            winner = true;
        }

        return winner;
        
    }

  }
}