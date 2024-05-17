using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{
    public class Aereo
    {


        public int PosizioneX { get; set; }
        public int PosizioneY { get; set; }

        public int contatoreAnimazioneEsplosione { get; set; }

        public int vite { get; set; }

        public bool bonus { get ; set; }    

        public bool colpito { get; set; }   

        public int immune { get; set; }
        public Aereo(int x, int y)
        {
            PosizioneX = x;
            PosizioneY = y;
            contatoreAnimazioneEsplosione = 12;
            vite = 1;
            immune = 100;
           
    }

        public void DisegnaFiamma1(Graphics g)
        { 
            Point[] puntifiamma = new Point[]{
         new Point(PosizioneX-6, PosizioneY + 90),
         new Point(PosizioneX-3, PosizioneY+ 99),
         new Point(PosizioneX, PosizioneY + 90),
         new Point(PosizioneX+3, PosizioneY + 99),
         new Point(PosizioneX+6, PosizioneY+ 90),
     };
            g.FillPolygon(Brushes.Orange, puntifiamma);
        }


        public void DisegnaFiamma2(Graphics g)
        {
            Point[] puntifiamma2 = new Point[]{
         new Point(PosizioneX-6, PosizioneY + 90),
         new Point(PosizioneX-3, PosizioneY+ 110),
         new Point(PosizioneX, PosizioneY + 90),
         new Point(PosizioneX+3, PosizioneY + 110),
         new Point(PosizioneX+6, PosizioneY+ 90),
     };
            g.FillPolygon(Brushes.Yellow, puntifiamma2);

        }

        public void Disegna(Graphics g)
        {
            if (vite > 0)
            {


                Point[] puntiAli = new Point[]

            {
         new Point(PosizioneX , PosizioneY +6),
         new Point(PosizioneX +5, PosizioneY + 23),
         new Point(PosizioneX + 6, PosizioneY + 40),
         new Point(PosizioneX + 33, PosizioneY + 64),
         new Point(PosizioneX + 34, PosizioneY + 72),
         new Point(PosizioneX + 8 ,PosizioneY + 68),
         new Point(PosizioneX + 9, PosizioneY + 77),
         new Point(PosizioneX + 21, PosizioneY + 85),
         new Point(PosizioneX + 22, PosizioneY + 95),
         new Point(PosizioneX + 8, PosizioneY + 90),
         new Point(PosizioneX , PosizioneY + 90),
         new Point(PosizioneX , PosizioneY + 90),
         new Point(PosizioneX - 8, PosizioneY + 90),
         new Point(PosizioneX - 22, PosizioneY + 95),
         new Point(PosizioneX - 21, PosizioneY + 85),
         new Point(PosizioneX - 9, PosizioneY + 77),
         new Point(PosizioneX - 8 ,PosizioneY + 68),
         new Point(PosizioneX - 34, PosizioneY + 72),
         new Point(PosizioneX - 33, PosizioneY + 64),
         new Point(PosizioneX - 6, PosizioneY + 40),
         new Point(PosizioneX -5, PosizioneY + 23),
         new Point(PosizioneX , PosizioneY +6),


            };





                Point[] finestrino = new Point[]
                {
                  new Point(PosizioneX, PosizioneY + 18),
                 new Point(PosizioneX+4, PosizioneY + 21),
                new Point(PosizioneX, PosizioneY + 35),

                new Point(PosizioneX-4, PosizioneY + 21),



                };
                if (immune <= 0)
                {
                    g.FillPolygon(Brushes.DimGray, puntiAli);
                    g.FillPolygon(Brushes.LightBlue, finestrino);

                    g.FillRectangle(Brushes.Gray, new Rectangle(PosizioneX + 1, PosizioneY + 68, 5, 24));
                    g.FillRectangle(Brushes.Gray, new Rectangle(PosizioneX - 6, PosizioneY + 68, 5, 24));
                }
                else if (immune > 0 && bonus)
                {
                    g.FillPolygon(Brushes.LightGreen, puntiAli);
                    g.FillPolygon(Brushes.LightGreen, finestrino);

                    g.FillRectangle(Brushes.LightGreen, new Rectangle(PosizioneX + 1, PosizioneY + 68, 5, 24));
                    g.FillRectangle(Brushes.LightGreen, new Rectangle(PosizioneX - 6, PosizioneY + 68, 5, 24));


                }
               // else if (immune > 0 && colpito)
               // {
                   // g.FillPolygon(Brushes.Red, puntiAli);
                  //  g.FillPolygon(Brushes.Red, finestrino);

                   // g.FillRectangle(Brushes.Red, new Rectangle(PosizioneX + 1, PosizioneY + 68, 5, 24));
                  //  g.FillRectangle(Brushes.Red, new Rectangle(PosizioneX - 6, PosizioneY + 68, 5, 24));


               // }

                else
                {
                    g.FillPolygon(Brushes.LightBlue, puntiAli);
                    g.FillPolygon(Brushes.LightBlue, finestrino);

                    g.FillRectangle(Brushes.LightBlue, new Rectangle(PosizioneX + 1, PosizioneY + 68, 5, 24));
                    g.FillRectangle(Brushes.LightBlue, new Rectangle(PosizioneX - 6, PosizioneY + 68, 5, 24));


                }

                // 0,6 5,23 6,40 33,64 34,72 8,68 9,77 21,85 22,95 8,90 1,90
            }

            else { }
        }

        public void disegnaesplosione(Graphics g, int i, int X, int Y)
        {
            if (i == 0)
            {
                g.FillEllipse(Brushes.Red, X - 33, Y, 70, 70);
                g.FillEllipse(Brushes.Yellow, X - 33, Y, 50, 50);
                g.FillEllipse(Brushes.White, X - 33, Y, 50, 20);
            }
            else if (i == 1)
            {
                g.FillEllipse(Brushes.Red, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X, Y - 30, 30, 60);
                g.FillEllipse(Brushes.Orange, X, Y + 40, 60, 50);
            }
            else if (i == 2)
            {
                g.FillEllipse(Brushes.Red, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X - 39, Y - 20, 30, 60);
                g.FillEllipse(Brushes.Orange, X, Y + 40, 60, 50);
            }
            else if (i == 3)
            {
                g.FillEllipse(Brushes.Orange, X + 15, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X - 60, Y - 30, 50, 50);
                g.FillEllipse(Brushes.Orange, X - 33, Y + 20 + 40, 50, 50);
            }
            else if (i == 4)
            {
                g.FillEllipse(Brushes.OrangeRed, X - 33, Y, 70, 70);
                g.FillEllipse(Brushes.Yellow, X - 33, Y, 50, 50);
                g.FillEllipse(Brushes.White, X - 33, Y, 50, 50);
            }
            else if (i == 5)
            {
                g.FillEllipse(Brushes.LightYellow, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X, Y - 30, 50, 50);
                g.FillEllipse(Brushes.Red, X, Y + 40, 60, 60);
            }
            else if (i == 6)
            {
                g.FillEllipse(Brushes.Red, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X - 39, Y - 20, 60, 60);
                g.FillEllipse(Brushes.Orange, X, Y + 40, 50, 50);
            }
            else if (i == 7)
            {
                g.FillEllipse(Brushes.Red, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X, Y - 30, 60, 60);
                g.FillEllipse(Brushes.Orange, X, Y + 40, 70, 70);
            }
            else if (i == 8)
            {
                g.FillEllipse(Brushes.Red, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X - 39, Y - 20, 60, 60);
                g.FillEllipse(Brushes.Orange, X, Y + 40, 60, 60);
            }
            else if (i == 9)
            {
                g.FillEllipse(Brushes.Orange, X + 15, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X - 60, Y - 30, 50, 50);
                g.FillEllipse(Brushes.Orange, X - 33, Y + 20 + 40, 50, 50);
            }
            else if (i == 10)
            {
                g.FillEllipse(Brushes.OrangeRed, X - 33, Y, 70, 70);
                g.FillEllipse(Brushes.Yellow, X - 33, Y, 40, 40);
                g.FillEllipse(Brushes.White, X - 33, Y, 50, 50);
            }
            else if (i == 11)
            {
                g.FillEllipse(Brushes.LightYellow, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X, Y - 30, 60, 60);
                g.FillEllipse(Brushes.Red, X, Y + 40, 60, 60);
            }
            else if (i == 12)
            {
                g.FillEllipse(Brushes.Red, X + 20, Y, 40, 40);
                g.FillEllipse(Brushes.Yellow, X - 39, Y - 20, 60, 60);
                g.FillEllipse(Brushes.Orange, X, Y + 40, 60, 60);
            }

        }

    }
}
