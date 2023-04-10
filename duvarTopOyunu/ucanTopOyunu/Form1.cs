namespace ucanTopOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int yerX =8, yerY = 8, can = 3;

        private void carpmaOlayý()
        {
            // üst tarafa çarpma
            if (ball.Top <= label2.Bottom)
                yerY = yerY * (-1);

            // kontrol çarpma olayý
            if(ball.Bottom >= kontrol.Top && ball.Left >= kontrol.Left && ball.Right <=kontrol.Right)
                yerY = yerY * (-1);    

            // sað kenara çarpma
            else if (ball.Right >= label4.Left)
                yerX = yerX * (-1);

            //Sol kenara çarpma
            else if (ball.Left <= label1.Right)
                yerX = yerX * (-1);
        }

        private void yanmaOlayý (object sender, EventArgs e)
        {
            if(ball.Top >= label4.Bottom)
            {
                if(can > 0)
                {
                    timer1.Stop();
                    can--;
                    MessageBox.Show("Yandýnýz kalan can = " + can.ToString());
                    Form1_Load(sender, e);
                }
                if (can == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("OYUN BÝTTÝ ", "",MessageBoxButtons.OK);
                    Form1_Load(sender, e);
                    can = 3;
                }

            }
            label3.Text =can.ToString();
        }

        private void topBasa()
        {
            ball.Location = new Point(443, 147);
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            kontrol.Left = e.X;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            carpmaOlayý();
            yanmaOlayý(sender, e);
            ball.Location = new Point(ball.Location.X + yerX, ball.Location.Y +yerY);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            topBasa();
            timer1.Enabled = true;
          


        }
    }
}