using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    internal class Item
    {
        Random rnd = new Random();
        public int Digit;

        public int[,] image = new int[28,28];

        public Item(string[] numbers)
        {
            Digit = Convert.ToInt16(numbers[0]);

            for (int i = 1; i < numbers.Length; i++)
            {
                int x = (i-1)%28;
                int y = (i-1)/28;

                image[x, y] = 255-Convert.ToInt16(numbers[i]);
            }
        }

        public void Draw(Graphics g)
        {
            for (int x=0; x < 28; x++)
            {
                for (int y=0; y < 28; y++)
                {
                    SolidBrush brush = new SolidBrush(Color.FromArgb(image[x, y], image[x, y], image[x, y]));
                    g.FillRectangle(brush, 10*x, 10*y, 10, 10);
                }
            }
        }

    }
}
