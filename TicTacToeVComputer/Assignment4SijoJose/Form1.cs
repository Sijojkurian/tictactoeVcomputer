using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5SijoJose
{
    public partial class Form1 : Form
    {
        TicTacToeBoard mainBoard;
        bool gameEnded;
        public Form1()
        { 
            InitializeComponent();
            mainBoard = null;
            label5.Text = "click start game";
            //in the program the names comes from textboxes
            //values from text boxes.
            //mainBoard = new TicTacToeBoard("player1", "player2");
            //drawBoard();//make the board based on the initial state
        }

        private void drawBoard()
        {
            if (mainBoard!=null)
            {
                //get the direct board state from here
                string[,] board = mainBoard.GetUpdatedBoard(-1, -1);//getting board state
                                                                    //without changing the board

                //pass the values from setimagesbasedOnvalue to this function
                //when calling the board, images will be set based on the value

                setImageBasedOnValue(pictureBox1, board[0, 0]);
                setImageBasedOnValue(pictureBox2, board[0, 1]);
                setImageBasedOnValue(pictureBox3, board[0, 2]);
                setImageBasedOnValue(pictureBox4, board[1, 0]);
                setImageBasedOnValue(pictureBox5, board[1, 1]);
                setImageBasedOnValue(pictureBox6, board[1, 2]);
                setImageBasedOnValue(pictureBox7, board[2, 0]);
                setImageBasedOnValue(pictureBox8, board[2, 1]);
                setImageBasedOnValue(pictureBox9, board[2, 2]);
                string next_player = "2";
                if (mainBoard.isPlayer1Move)
                    next_player = "1";
                label5.Text = "Player"+next_player+" play next";

            }
        }

        private void setImageBasedOnValue(PictureBox pictureBox, string value)
        {   
            //do this to minize the code
            //pass the picturebox into the function
            if (value == "X")
                pictureBox.Image = Assignment5SijoJose.Properties.Resources.X;
            if (value == "O")
                pictureBox.Image = Assignment5SijoJose.Properties.Resources.O;
            if (value == "")
                pictureBox.Image = Assignment5SijoJose.Properties.Resources.blank;
        }

        private void updateBoard(int row, int col)
        {
            //will pass the row & column into this function
            //lets you make the move if allowed
            if (textBox1.Text=="")
            {
                MessageBox.Show("Enter your name: ");
                return;
            }
            else if (mainBoard == null)
            {
                MessageBox.Show("Please start the game first");
                return;
            }
            /*if (mainBoard.IsAllowedMove(row, col))
                //only make the change if the move is allowed
            {   
                string[,] board = mainBoard.GetUpdatedBoard(row, col);
                drawBoard();
                if (mainBoard.CheckBoard() == true)//game has ended
                {
                    label5.Text = mainBoard.getWinningPlayerName() + " won";
                    MessageBox.Show("Winner is: " + mainBoard.getWinningPlayerName());
                    resetBoard();
                }
            }
            else
            {
                //give message to show that move is not allowed
                MessageBox.Show("This move is not allowed !");
            }*/
            //try
            if(gameEnded == true)
            {
                MessageBox.Show("Game has ended, start a new game!! ");
                return;
            }
            try
            {
                string[,] board = mainBoard.GetUpdatedBoard(row, col);
                drawBoard();
                if (mainBoard.CheckBoard() == true)//game has ended
                {
                    label5.Text = mainBoard.getWinningPlayerName() + " won";
                    MessageBox.Show("Winner is: " + mainBoard.getWinningPlayerName());
                    gameEnded = true;
                    return;
                }
                    //MessageBox.Show("Winner is: " + mainBoard.getWinningPlayerName());
                    //resetBoard();
                    //now play computers move
                    //recallng this function below when computer is making the move
                RowCol rc = mainBoard.GetComputerMove();//call the computer move from a class
                board = mainBoard.GetUpdatedBoard(rc.row, rc.col);
                drawBoard();
                if (mainBoard.CheckBoard() == true)
                {
                    MessageBox.Show("Game has ended, computer wins");
                    gameEnded = true;
                    return;
                }
                /*if (mainBoard.CheckBoard() == true)
                {
                    MessageBox.Show("it's a draw");
                    gameEnded = true;
                    return;
                }*/


            }
            catch(Exception ex)
            {
                //give message to show that move is not allowed
                MessageBox.Show("Exception! "+ ex.Message);
            }
        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //string[,] board = mainBoard.GetUpdatedBoard(0, 0);
            //drawBoard(board);

            // do this instead
            updateBoard(0, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updateBoard(0, 1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            updateBoard(0, 2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            updateBoard(1, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            updateBoard(1, 1);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            updateBoard(1, 2);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            updateBoard(2, 0);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            updateBoard(2, 1);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            updateBoard(2, 2);
        }

        private void resetBoard()
        {
            string player1 = textBox1.Text;
            mainBoard = new TicTacToeBoard(player1);
            drawBoard();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //once the start button is pressed
            //allows to play multiple games without restarting it
            resetBoard();
            gameEnded = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             string player1 = textBox1.Text+ "";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //string player2 = textBox2.Text+ "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
