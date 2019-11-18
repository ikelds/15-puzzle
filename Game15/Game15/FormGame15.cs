using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game15
{
    public partial class Game15 : Form
    {
        Game myGame;

        public Game15()
        {
            InitializeComponent();
            myGame = new Game(4);             
        }

        private void button0_Click(object sender, EventArgs e)
        {


            //MessageBox.Show(myGame.checkToEndGame().ToString());

            int temp = Convert.ToInt16(((Button)sender).Tag);

            //MessageBox.Show(temp.ToString(), "Была нажата кнопка с Tag");
            myGame.swapTails(temp);
            myButton(temp).Focus();
            RefreshTiles();
            myButton(temp).Focus();

            //MessageBox.Show(myGame.checkToEndGame().ToString());


            if (myGame.checkToEndGame())
                MessageBox.Show("Поздравляем! Вы выиграли!", "Пятнашки");

            //foreach (int i in myGame.rightNumb)
            //    MessageBox.Show(i.ToString());

            //foreach (int i in myGame.numbInMasss)
            //    MessageBox.Show(i.ToString());

            //int currNumb = Convert.ToInt16(((Button)sender).Tag);

            //myButton(currNumb).Text = Convert.ToString(currNumb);

            //for  (int i = 0; i < 16; i++)
            //{
            //    myButton(i).Text = Convert.ToString(i);

            //    if (i == 15)
            //        myButton(i).Text = "";
            //}

        }

        //private void initButtn()
        //{
        //    for (int i = 0; i < 16; i++)
        //    {

        //        int x, y;

        //        myButton(i).Text = 
                
           
        //    }
        //}

        private Button myButton(int pos)
        {
            switch(pos)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;                    
            }
        }


        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            myGame.start();
            myGame.mixTails();
            RefreshTiles();
        }

        private void RefreshTiles()
        {
            for (int p = 0; p < 16; p++)
            {
                int nmb = myGame.get_number(p);

                myButton(p).Text = nmb.ToString();

                myButton(p).Visible = (nmb > 0);

                //if (nmb == 0)
                //    myButton(p).Focus();

                //if (nmb == 0)
                //    myButton(p).Visible = false;
            }
        }

        private void Game15_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void MixTailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
                
                RefreshTiles();
                //System.Threading.Thread.Sleep(1000);
                        
        }
    }
}
