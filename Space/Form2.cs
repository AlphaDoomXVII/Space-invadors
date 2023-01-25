using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space
{
    public partial class Form2 : Form
    {

        bool goLeft, goRight;
        int playerSpeed = 12;
        int enemySpeed = 20;
        int score = 0;
        int enemyBulletTimer = -40;

        PictureBox[] sadInvadersArray;

        bool shooting;
        bool isGameOver;

        public Form2()
        {
            InitializeComponent();
            gameSetup();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goLeft)
            {
                player.Left -= playerSpeed;
            }

            if (goRight)
            {
                player.Left += playerSpeed;
            }

            enemyBulletTimer -= 10;

            if (enemyBulletTimer < 1)
            {
                enemyBulletTimer = 300;
                makeBullet("sadBullet");
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "sadInvaders")
                {
                    // x.Left = new Random().Next(10, 550);
                    x.Top += enemySpeed;

                    if (x.Top > 620) // 620
                    {
                        
                        x.Top = -80;
                    }


                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        using (var soundPlayer2 = new SoundPlayer(@"C:\Users\camie\source\repos\AlphaDoomXVII\Space-invadors\Space\Resources\muffled-distant-explosion-7104.wav"))
                        {
                            soundPlayer2.Play();
                        }
                        gameOver("You've been invaded by the sad invaders, you are now sad!");
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                using (var soundPlayer1 = new SoundPlayer(@"C:\Users\camie\source\repos\AlphaDoomXVII\Space-invadors\Space\Resources\muffled-distant-explosion-7104.wav"))
                                {
                                    soundPlayer1.Play();
                                }
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score += 1;
                                shooting = false;
                            }
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 40;

                    if (x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        shooting = false;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "sadBullet")
                {

                    x.Top += 25;

                    if (x.Top > 620)
                    {
                        this.Controls.Remove(x);
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(x);
                        gameOver("You've been killed by the sad bullet. Now you are sad forever!");
                    }

                }
            }

            if (score > 20)
            {
                enemySpeed = 2;
            }

            if (score == sadInvadersArray.Length * 3)
            {
                gameOver("Woohoo Happiness Found, Keep it safe!");
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && shooting == false)
            {
                using (var soundPlayer3 = new SoundPlayer(@"C:\Users\camie\source\repos\AlphaDoomXVII\Space-invadors\Space\Resources\072816_heavy-machine-gun-50-caliber-28293.wav"))
                {
                    soundPlayer3.Play();
                }
                shooting = true;
                makeBullet("bullet");
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeAll();
                gameSetup();
            }
        }


        private void makeInvaders()
        {

            sadInvadersArray = new PictureBox[10];

            int Left = 0;
            

            for (int i = 0; i < sadInvadersArray.Length; i++)
            {

                sadInvadersArray[i] = new PictureBox();
                sadInvadersArray[i].Size = new Size(60, 50);
                sadInvadersArray[i].Image = Space.Properties.Resources.sadFace;
                sadInvadersArray[i].Left = 10;
                sadInvadersArray[i].Tag = "sadInvaders";
                sadInvadersArray[i].Left = Left;
                sadInvadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(sadInvadersArray[i]);
                Left = Left + 75;

            }

            sadInvadersArray = new PictureBox[10];

            Left = 0;

            for (int i = 0; i < sadInvadersArray.Length; i++)
            {

                sadInvadersArray[i] = new PictureBox();
                sadInvadersArray[i].Size = new Size(60, 50);
                sadInvadersArray[i].Image = Space.Properties.Resources.sadFace;
                sadInvadersArray[i].Left = 10;
                sadInvadersArray[i].Top = -80;
                sadInvadersArray[i].Tag = "sadInvaders";
                sadInvadersArray[i].Left = Left;
                sadInvadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(sadInvadersArray[i]);
                Left = Left + 75;

            }

            sadInvadersArray = new PictureBox[10];

            Left = 0;

            for (int i = 0; i < sadInvadersArray.Length; i++)
            {

                sadInvadersArray[i] = new PictureBox();
                sadInvadersArray[i].Size = new Size(60, 50);
                sadInvadersArray[i].Image = Space.Properties.Resources.sadFace;
                sadInvadersArray[i].Left = 10;
                sadInvadersArray[i].Top = -160;
                sadInvadersArray[i].Tag = "sadInvaders";
                sadInvadersArray[i].Left = Left;
                sadInvadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(sadInvadersArray[i]);
                Left = Left + 75;

            }


        }

        private void gameSetup()
        {
            txtScore.Text = "Score: 0";
            score = 0;
            isGameOver = false;

            enemyBulletTimer = 300;
            enemySpeed = 1;
            shooting = false;

            makeInvaders();
            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text = "Score: " + score + " " + message;
        }

        private void removeAll()
        {

            foreach (PictureBox i in sadInvadersArray)
            {
                this.Controls.Remove(i);
            }


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "bullet" || (string)x.Tag == "sadBullet")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void makeBullet(string bulletTag)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Space.Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = bulletTag;
            bullet.Left = player.Left + player.Width / 2;

            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = player.Top - 20;
            }
            else if ((string)bullet.Tag == "sadBullet")
            {
                bullet.Top = -100;
            }

            this.Controls.Add(bullet);
            bullet.BringToFront();

        }

    }
}


//private void makeInvaders()
//{

//    sadInvadersArray = new PictureBox[5];

//    int Top = 0;

//    for (int i = 0; i < sadInvadersArray.Length; i++)
//    {
//        sadInvadersArray[i] = new PictureBox();
//        sadInvadersArray[i].Size = new Size(60, 50);
//        sadInvadersArray[i].Image = Space.Properties.Resources.sadFace;
//        sadInvadersArray[i].Left = 10;
//        sadInvadersArray[i].Tag = "sadInvaders";
//        sadInvadersArray[i].Top = Top;
//        sadInvadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
//        this.Controls.Add(sadInvadersArray[i]);
//        Top = Top - 80;

//    }


//}