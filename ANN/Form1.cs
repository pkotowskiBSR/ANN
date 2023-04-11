using System;
using System.Diagnostics;

namespace ANN
{
    public partial class Form1 : Form
    {
        List<Item> items = new List<Item>();
        int currentItem = 0;

        MLP mlp = new MLP(784, 100, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //wczytywanie dataset
            string s;

            StreamReader sr = new StreamReader("digits.txt");

            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();

                string[] numbers = s.Split(",");

                Item item = new Item(numbers);
                items.Add(item);
            }
            sr.Close();

            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (items.Count > 0)
            {
                if (currentItem > 0)
                {
                    currentItem--;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (items.Count > 0)
            {
                if (currentItem < items.Count - 1)
                {
                    currentItem++;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (items.Count == 0)
            {
                return;
            }

            Graphics g = e.Graphics;
            items[currentItem].Draw(g);
            label1.Text = items[currentItem].Digit.ToString();

            //wywo³ujemy dzia³anie sieci i sprawdzamy co zwróci
            float[] input = new float[784];
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = 1f * items[currentItem].image[i % 28, i / 28] / 255f;
            }
            float[] output = mlp.ForwardProccess(input, items[currentItem].Digit);

            //wynik jakoœ prezentujemy:
            //????

        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (items.Count > 0)
            {
                currentItem = (currentItem + 1) % items.Count;
                pictureBox1.Invalidate();
            }
        }
    }
}