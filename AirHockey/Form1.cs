using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{ //Dylan de groot 
  // november 29th 2023
  // airhockey
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(10, 130, 30, 30);
        Rectangle player1top = new Rectangle(11, 129, 28, 1);
        Rectangle player1right = new Rectangle(39, 131, 1, 28);
        Rectangle player1bottom = new Rectangle(11, 160, 28, 1);
        Rectangle player1left = new Rectangle(10, 131, 1, 28);
        Rectangle player2 = new Rectangle(396, 140, 30, 30); //colision shapes
        Rectangle player2top = new Rectangle(397, 139, 28, 1);
        Rectangle player2right = new Rectangle(396, 141, 1, 28);
        Rectangle player2bottom = new Rectangle(397, 170, 28, 1);
        Rectangle player2left = new Rectangle(426, 141, 1, 28);
        Rectangle ball = new Rectangle(207, 155, 10, 10);
        Rectangle goal1 = new Rectangle(0, 60, 5, 170);
        Rectangle goal2 = new Rectangle(431, 60, 5, 170);

        int player1Score = 0;
        int player2Score = 0;
        int gametimerloopcoutner = 0;
        int playerSpeed1 = 4;
        int playerSpeed2 = 4;
        int ballXSpeed = 0;
        int ballYSpeed = 0;
        int ballMaxSpeed = 12;
        int player1vMonentum;
        int player2vMonentum; //variables
        int player1hMonentum;
        int player2hMonentum;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false; //variables for storying key presses
        bool eDown = false;
        bool spaceDown = false;

        Random rnd = new Random(); // random ball color
        Color randomColor;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue); // brushes
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.E:
                    eDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;

            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    player1vMonentum = 0;
                    break;
                case Keys.S:
                    sDown = false;
                    player1vMonentum = 0;
                    break;
                case Keys.D:
                    dDown = false;
                    player1hMonentum = 0;
                    break;
                case Keys.A:
                    aDown = false;
                    player1hMonentum = 0;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    player2vMonentum = 0;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    player2vMonentum = 0;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    player2hMonentum = 0;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    player2hMonentum = 0;
                    break;
                case Keys.E:
                    eDown = false;
                    playerSpeed1 = 4;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    playerSpeed2 = 4;
                    break;
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gametimerloopcoutner++;
            //move ball 
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move player 1 
            if (wDown == true && player1.Y > 0)
            {

                player1vMonentum = -playerSpeed1;
                player1.Y -= playerSpeed1;
                player1top.Y -= playerSpeed1;
                player1right.Y -= playerSpeed1;
                player1bottom.Y -= playerSpeed1;
                player1left.Y -= playerSpeed1;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1vMonentum = playerSpeed1;
                player1.Y += playerSpeed1;
                player1top.Y += playerSpeed1;
                player1right.Y += playerSpeed1;
                player1bottom.Y += playerSpeed1;
                player1left.Y += playerSpeed1;
            }

            if (dDown == true && player1.X < 185)
            {
                player1hMonentum = playerSpeed1;
                player1.X += playerSpeed1;
                player1top.X += playerSpeed1;
                player1right.X += playerSpeed1;
                player1bottom.X += playerSpeed1;
                player1left.X += playerSpeed1;
            }

            if (aDown == true && player1.X > 0)
            {
                player1hMonentum = -playerSpeed1;
                player1.X -= playerSpeed1;
                player1top.X -= playerSpeed1;
                player1right.X -= playerSpeed1;
                player1bottom.X -= playerSpeed1;
                player1left.X -= playerSpeed1;
            }
            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2vMonentum = -playerSpeed2;
                player2.Y -= playerSpeed2;
                player2top.Y -= playerSpeed2;
                player2right.Y -= playerSpeed2;
                player2bottom.Y -= playerSpeed2;
                player2left.Y -= playerSpeed2;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2vMonentum = playerSpeed2;
                player2.Y += playerSpeed2;
                player2top.Y += playerSpeed2;
                player2right.Y += playerSpeed2;
                player2bottom.Y += playerSpeed2;
                player2left.Y += playerSpeed2;
            }

            if (leftArrowDown == true && player2.X > 210)
            {
                player2hMonentum = -playerSpeed2;
                player2.X -= playerSpeed2;
                player2top.X -= playerSpeed2;
                player2right.X -= playerSpeed2;
                player2bottom.X -= playerSpeed2;
                player2left.X -= playerSpeed2;
            }

            if (rightArrowDown == true && player2.X < 405)
            {
                player2hMonentum = playerSpeed2;
                player2.X += playerSpeed2;
                player2top.X += playerSpeed2;
                player2right.X += playerSpeed2;
                player2bottom.X += playerSpeed2;
                player2left.X += playerSpeed2;
            }
            if (eDown == true)
            {
                playerSpeed1 = 6;
            }
            if (spaceDown == true)
            {
                playerSpeed2 = 6;
            }

            //check if ball hit top or bottom wall and change direction if it does 
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            }
            if (ball.Y < -10 || ball.Y > this.Height - ball.Height + 15)
            {
                ball.X = 207;
                ball.Y = 155;
                ballXSpeed = 0;
                ballYSpeed = 0;
                winLabel.Text = "ball left field";
            }

            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 
            if (player1right.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player1right.X + ball.Width;
                if (ballXSpeed < ballMaxSpeed)
                {
                    ballXSpeed += player1hMonentum;
                }
            }
            else if (player1top.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player1top.Y - ball.Height;
                if (ballYSpeed < ballMaxSpeed)
                {
                    ballYSpeed += player1vMonentum;
                }
            }
            else if (player1bottom.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player1bottom.Y + ball.Height;
                if (ballYSpeed < ballMaxSpeed)
                {
                    ballYSpeed += player1vMonentum;
                }
            }
            else if (player1left.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player1left.X - ball.Width;
                if (ballXSpeed < ballMaxSpeed)
                {
                    ballXSpeed += player1hMonentum;
                }
            }
            else if (player2top.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ballYSpeed += player2vMonentum;
                if (ballYSpeed < ballMaxSpeed)
                {
                    ball.Y = player2top.Y - ball.Height;
                }
            }
            else if (player2right.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ball.X = player2right.X - ball.Width;
                if (ballXSpeed < ballMaxSpeed)
                {
                    ballXSpeed += player2hMonentum;
                }
            }
            else if (player2bottom.IntersectsWith(ball))
            {
                ballYSpeed = -ballYSpeed;
                ball.Y = player2bottom.Y + ball.Height;
                if (ballYSpeed < ballMaxSpeed)
                {
                    ballYSpeed += player2vMonentum;
                }
            }
            else if (player2left.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ballXSpeed += player2hMonentum;
                ball.X = player2left.X + ball.Width;
                if (ballXSpeed < ballMaxSpeed)
                {
                    ballXSpeed += player2vMonentum;
                }
            }
            else if (player1.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ballYSpeed = -ballYSpeed;
            }
            else if (player2.IntersectsWith(ball))
            {
                ballXSpeed = -ballXSpeed;
                ballYSpeed = -ballYSpeed;
            }
            else if (ball.IntersectsWith(goal2))
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                ball.X = 207;
                ball.Y = 155;
                ballXSpeed = 0;
                ballYSpeed = 0;
            }
            else if (ball.IntersectsWith(goal1))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                ball.X = 207;
                ball.Y = 155;
                ballXSpeed = 0;
                ballYSpeed = 0;
            }
            //check if a player missed the ball and if true add 1 to score of other player  
            if (ball.X > 431)
            {
                ballXSpeed *= -1;
            }
            else if (ball.X < 0)
            {
                ballXSpeed *= -1;
            }

            // check score and stop game if either player is at 3 
            if (player1Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }
            if (gametimerloopcoutner % 25 == 0)
            {
                if (ballXSpeed > 0)
                    ballXSpeed -= 1;
                else if (ballXSpeed < 0)
                    ballXSpeed += 1;
                if (ballYSpeed > 0)
                    ballYSpeed -= 1;
                else if (ballYSpeed < 0)
                    ballYSpeed += 1;
                winLabel.Text = "";
                randomColor = Color.FromArgb(rnd.Next(50, 256), rnd.Next(50, 256), rnd.Next(50, 256));
            }

            Refresh();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush randombrush = new SolidBrush(randomColor);
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(randombrush, ball);
            e.Graphics.FillRectangle(whiteBrush, goal1);
            e.Graphics.FillRectangle(whiteBrush, goal2);
        }

        private void Form1_KeyClick(object sender, EventArgs e)
        {
            if (gameTimer.Enabled == false)
            {
                gameTimer.Start();
                player1Score = 0;
                player2Score = 0;
                p2ScoreLabel.Text = "0";
                p1ScoreLabel.Text = "0";
                player1.X = 10;
                player1top.X = 11;
                player1right.X = 39;
                player1bottom.X = 11;
                player1left.X = 10;
                player2.X = 396;
                player2top.X = 397;
                player2right.X = 396;
                player2bottom.X = 397;
                player2left.X = 426;
                player1.Y = 130;
                player1top.Y = 129;
                player1right.Y = 131;
                player1bottom.Y = 160;
                player1left.Y = 131;
                player2.Y = 140;
                player2top.Y = 139;
                player2right.Y = 141;
                player2bottom.Y = 170;
                player2left.Y = 141;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

