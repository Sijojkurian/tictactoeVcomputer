using Assignment5SijoJose;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5SijoJose
{
    class TicTacToeBoard
    {
        //create a two dimention array and call it into a function
        private string[,] board;
        public bool isPlayer1Move;
        private string player1, player2;
        private string winner;
        public TicTacToeBoard(string p1)//now we only need player1
        {
            //main datastructure behind the game
            player1 = p1;
            player2 = "computer";
            //declare the constructor
            board = new string[3, 3];
            initializeBoard();
        }

        private void initializeBoard()
        {
            //initialize the value of the board
            //runs loop and sets value in this board
            int iRow, iCol;
            isPlayer1Move = true;
            for (iRow = 0; iRow < 3; iRow++)
            {
                for (iCol = 0; iCol < 3; iCol++)
                {
                    board[iRow, iCol] = "";
                }
            }
        }

        public string[,] GetUpdatedBoard(int row, int col)
        {
            //this returns the current board state with a two dimentional array
            //MAIN FUNCTION that makes changes to the state 
            //this is where most of the action is taking place

            if (row < 0 && col < 0)
            {
                return board;
            }
            if (!IsAllowedMove(row, col))
                throw new Exception("Move is not allowed !");
        //throw exception here
            if (isPlayer1Move == true)
            {
                board[row, col] = "X";
            }
            else
            {
                board[row, col] = "O";
            }

            isPlayer1Move = !isPlayer1Move;
            return board;
        }

       public RowCol GetComputerMove()
        {
            RowCol rc = new RowCol();
            //defensive move to draw
            //add condition for Row
            //SIMILARY HAVE TO ADD CHECKS HERE FOR DIFFERNT COMBInations when diff col and rows are selected

            //aggressive moves Computer trying to win
            for (int iRow=0; iRow <3; iRow++)
            {
                if (board[iRow, 0] == " X")
                {   //check row 1
                    if (board[iRow, 0] == board[iRow, 1])
                    {
                        if (board[iRow, 2] == "")//only if board [0,2 is empty
                        {
                            rc.row = iRow;
                            rc.col = 2;
                            return rc;
                        }
                    }

                }

            }

            //option 2
            for (int iRow = 0; iRow < 3; iRow++)
            {
                if (board[iRow, 0] == "X")
                {
                    if (board[iRow, 0] == board[iRow, 2])
                    {
                        if (board[iRow, 1] == "")
                        {
                            rc.row = iRow;
                            rc.col = 1;
                            return rc;
                        }
                    }

                }

            }

            //option3
            for (int iRow = 1; iRow < 3; iRow++)
            {
                if (board[iRow, 0] == "X")
                {
                    if (board[iRow, 0] == board[iRow, 2])
                    {
                        if (board[iRow, 1] == "")
                        {
                            rc.row = iRow;
                            rc.col = 1;
                            return rc;
                        }
                    }

                }

            }
            //option4
            for (int iRow = 1; iRow < 3; iRow++)
            {
                if (board[iRow, 1] == "X")
                {
                    if (board[iRow, 1] == board[iRow, 2])
                    {
                        if (board[iRow, 0] == "")
                        {
                            rc.row = iRow;
                            rc.col = 0;
                            return rc;
                        }
                    }

                }

            }
            //option 5
            for (int iCol = 0; iCol < 3; iCol++)
            {
                if (board[0, iCol] == "X")
                {
                    if (board[0, iCol] == board[1, iCol])
                    {
                        if (board[2, iCol] == "")
                        {
                            rc.row = 2;
                            rc.col = iCol;
                            return rc;
                        }
                    }

                }

            }
            //option 6
            for (int iCol = 0; iCol < 3; iCol++)
            {
                if (board[0, iCol] == "X")
                {
                    if (board[0, iCol] == board[2, iCol])
                    {
                        if (board[1, iCol] == "")
                        {
                            rc.row = 1;
                            rc.col = iCol;
                            return rc;
                        }
                    }

                }

            }
            //option 7
            for (int iCol = 1; iCol < 3; iCol++)
            {
                if (board[0, iCol] == "X")
                {
                    if (board[0, iCol] == board[2, iCol])
                    {
                        if (board[1, iCol] == "")
                        {
                            rc.row = 1;
                            rc.col = iCol;
                            return rc;
                        }
                    }

                }

            }
            //option 8
            for (int iCol = 1; iCol < 3; iCol++)
            {
                if (board[0, iCol] == "X")
                {
                    if (board[0, iCol] == board[1, iCol])
                    {
                        if (board[2, iCol] == "")
                        {
                            rc.row = 2;
                            rc.col = iCol;
                            return rc;
                        }
                    }

                }

            }

            //option 9
            for (int iCol = 1; iCol < 3; iCol++)
            {
                if (board[1, iCol] == "X")
                {
                    if (board[2, iCol] == board[1, iCol])
                    {
                        if (board[0, iCol] == "")
                        {
                            rc.row = 0;
                            rc.col = iCol;
                            return rc;
                        }
                    }

                }

            }
            //option 10

            for (int iCol = 2; iCol < 3; iCol++)
            {
                if (board[0, iCol] == "X")
                {
                    if (board[0, iCol] == board[2, iCol])
                    {
                        if (board[1, iCol] == "")
                        {
                            rc.row = 1;
                            rc.col = iCol;
                            return rc;
                        }
                    }

                }

            }

            //Take the center board away or try for corners
            if (board[1,1] == "")
            {
                rc.row = 1;
                rc.col = 1;
                return rc;

            }

            //take the corner
            if (board[0, 0] == "")
            {
                rc.row = 0;
                rc.col = 0;
                return rc;

            }
            if (board[0, 2] == "")
            {
                rc.row = 0;
                rc.col = 2;
                return rc;

            }
            if (board[2, 0] == "")
            {
                rc.row = 2;
                rc.col = 0;
                return rc;

            }
            if (board[2, 2] == "")
            {
                rc.row = 2;
                rc.col = 2;
                return rc;

            }

            //center board

            //if we are still at this point, play in whatever cell is available

            for (int iRow = 0; iRow < 3; iRow++)
            {
                for (int iCol = 0; iCol < 3; iCol++)
                {
                    if (board[iRow, iCol] == "")
                    {
                        rc.row = iRow;
                        rc.col = iCol;
                        return rc;
                    }
                }
            }
           

            

            /*if (board[0, 0] != "")
            {   //check row 1
                if (board[0, 0] == board[1, 1])
                {
                    if (board[1, 1] == board[2, 2])
                    {
                        setWinningPlayer();
                        return true;
                    }
                }

            }*/

           
            /*if (board[2, 0] != "")
            {
                //row 3
                if (board[2, 0] == board[2, 1])
                {
                    if (board[2, 1] == board[2, 2])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }

            if (board[0, 1] != "")
            {
                //column2
                if (board[0, 1] == board[1, 1])
                {
                    if (board[1, 1] == board[2, 1])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }
            if (board[0, 2] != "")
            {
                //column 3
                if (board[0, 2] == board[1, 2])
                {
                    if (board[1, 2] == board[2, 2])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }*/


            //This loop checks if no more moves are possible
         
            return rc;//all the erros go away and getupdatedboard returns only ok
        }
        public bool CheckBoard()
        {
            int iRow, iCol;

            //See if any player has won
            //Check each row
            if (board[0, 0] != "")
            {   //check row 1
                if (board[0, 0] == board[0, 1])
                {
                    if (board[0, 1] == board[0, 2])
                    {
                        setWinningPlayer();
                        return true;
                    }
                }
                
            }
            //x pattern
            if (board[0, 0] != "")
            {   //check row 1
                if (board[0, 0] == board[1, 1])
                {
                    if (board[1, 1] == board[2, 2])
                    {
                        setWinningPlayer();
                        return true;
                    }
                }

            }
            if (board[0, 2] != "")
            {   //check row 1
                if (board[0, 2] == board[1, 1])
                {
                    if (board[1, 1] == board[2, 0])
                    {
                        setWinningPlayer();
                        return true;
                    }
                }

            }
            if (board[0 , 0] != "")
            {   //check row 1
                if (board[0, 0] == board[1, 0])
                {
                    if (board[1, 0] == board[2, 0])
                    {
                        setWinningPlayer();
                        return true;
                    }
                }

            }

            /*if (board[0, 0] != "")
            {   //check row 1
                if (board[0, 0] == board[1, 1])
                {
                    if (board[1, 1] == board[2, 2])
                    {
                        setWinningPlayer();
                        return true;
                    }
                }

            }*/

            if (board[1, 0] != "")
            {
                //row 2
                if (board[1, 0] == board[1, 1])
                {
                    if (board[1, 1] == board[1, 2])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }
            if (board[2, 0] != "")
            {
                //row 3
                if (board[2, 0] == board[2, 1])
                {
                    if (board[2, 1] == board[2, 2])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }

            if (board[0, 1] != "")
            {
                //column2
                if (board[0, 1] == board[1, 1])
                {
                    if (board[1, 1] == board[2, 1])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }
            if (board[0, 2] != "")
            {
                //column 3
                if (board[0, 2] == board[1, 2])
                {
                    if (board[1, 2] == board[2, 2])
                    {
                        //newly added
                        setWinningPlayer();
                        return true;
                    }
                }
            }


            //This loop checks if no more moves are possible
            for (iRow = 0; iRow < 3; iRow++)
            {
                for (iCol = 0; iCol < 3; iCol++)
                { 
                    if (board[iRow, iCol] == "")
                        return false;
                }
            }
            //if every board is full, return true    
            return true;
        }
        //create a private function for winning player
        private void setWinningPlayer()
        {
            if (isPlayer1Move)
                winner = player2;
            else
                winner = player1;
        }

        public string getWinningPlayerName()
        {
            return winner;
        }

        //create a function to generate name
        private bool IsAllowedMove(int row, int col)//no longer needed
            //if the move isn't allowed, just show a exception
        {
            if (board[row, col] != "")
            {
                return false;
            }
                
            else
            {
                return true;
            }
               
        }

    }
}
