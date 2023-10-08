using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino
{
    public class Ficha
    {
        private int num1;
        private int num2;
        public PictureBox pictureReferencia;

        public Ficha(int num1, int num2)
        {   // Abre constructor
            this.num1 = num1;
            this.num2 = num2;
        }

        public int getNum1()
        {
            return num1;
        }

        public int getNum2()
        {
            return num2;
        }
        public bool contieneNumero(int num)
        {
            if(num==num1 || num == num2)
            {
                return (true);
            }
            return (false);
        }
        public void setPictureReferencia(PictureBox p)
        {
            pictureReferencia = p;
        }
        public PictureBox getPictureBox()
        {
            return (pictureReferencia);
        }
    }
}
