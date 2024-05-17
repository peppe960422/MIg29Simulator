using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{
    public class Nuvole
    {
        public int PosizioneX { get; set; }
        public int PosizioneY { get; set; }

        public Nuvole(int x, int y)
        {
            PosizioneX = x;
            PosizioneY = y;
        }
        public void Disegna(Graphics g)
        {

            g.FillEllipse(Brushes.White, new Rectangle(PosizioneX, PosizioneY + 5, 50, 33));
            g.FillEllipse(Brushes.LightGray, new Rectangle(PosizioneX - 30, PosizioneY + 21, 56, 15));



        }

        public void Disegna2(Graphics g)
        {

            g.FillEllipse(Brushes.White, new Rectangle(PosizioneX, PosizioneY + 5, 56, 36));
            g.FillEllipse(Brushes.LightGray, new Rectangle(PosizioneX - 30, PosizioneY + 21, 76, 35));



        }
        public void Disegna3(Graphics g)
        {

            g.FillEllipse(Brushes.White, new Rectangle(PosizioneX, PosizioneY + 5, 66, 23));
            g.FillEllipse(Brushes.LightGray, new Rectangle(PosizioneX - 30, PosizioneY + 21, 76, 25));
            g.FillEllipse(Brushes.White, new Rectangle(PosizioneX + 5, PosizioneY + 21, 66, 25));



        }



    }


}
