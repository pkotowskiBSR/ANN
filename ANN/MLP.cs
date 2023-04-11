using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANN
{
    internal class MLP
    {
        Random rnd = new Random();
     
        int inLen;

        int hidLen;
        float[,] hid_W;

        int outLen;
        float[,] out_W;

        public MLP(int inLength, int hidLength, int outLength)
        {
            inLen = inLength;
            hidLen = hidLength;
            outLen = outLength;

            hid_W = new float[inLen, hidLen];
            out_W= new float[hidLen, outLen];

            RandomWeights();
        }

        public void RandomWeights()
        {
            for (int i = 0; i < hidLen; i++)
            {
                for (int j = 0; j<inLen; j++)
                {
                    hid_W[j,i] = (float)(2*rnd.NextDouble()-1);
                }
            }
            for (int i = 0; i < hidLen; i++)
            {
                for (int j = 0; j < outLen; j++)
                {
                    out_W[i, j] = (float)(2 * rnd.NextDouble() - 1);
                }
            }
        }

        public float[] ForwardProccess(float[] input, int output)
        {
            float[] out1 = new float[hidLen];
            for (int j=0; j<hidLen; j++)
            {
                //.... dla każdego neurona warstwy ukrytej wyliczamy out1[j]
            }

            float[] out2 = new float[outLen];
            for (int j = 0; j < outLen; j++)
            {
                //.... dla każdego neurona warstwy wyjściowej wyliczamy out2[j]
            }
            

            //Teraz poprawiamy sieć:
            //back propagation


            return out2;
        }
    }
}




