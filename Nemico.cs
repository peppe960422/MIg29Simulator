using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{

    public abstract class Nemico
    {

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public int life { get; set; }
        public int sparato;
        



        public int bottoanimazine { get; set; }
        public Nemico(int x, int y, int vita)
        {
            X = x;
            Y = y;
            life = vita;

            bottoanimazine = 8;

        }


        virtual public Nemico Mossa1(Nemico americano, int Mig29x, List<Proiettile> proiettili)

        {
            if (americano.X > Mig29x)
            {
                americano.Y += 10;
                int n = (americano.X - Mig29x);
                americano.X -= n / 15;
                if (americano.sparato == 1 && (americano.X > X - 50) && americano.life >= 1)
                {
                    RazzoNemico r = new RazzoNemico(americano.X, americano.Y + 60); ;

                    proiettili.Add(r);
                    americano.sparato--;


                }

            }
            else if (americano.X == Mig29x)
            {
                americano.Y += 10;



            }
            else
            {
                americano.Y += 10;
                int v = (Mig29x - americano.X);
                americano.X += v / 15;
                if (americano.sparato == 1 && (americano.X < X - 50) && americano.life >= 1)
                {
                    RazzoNemico r = new RazzoNemico(americano.X, americano.Y + 60); ;

                    proiettili.Add(r);
                    americano.sparato--;


                }

            }
            return americano;

        }
        virtual public Nemico Mossa2(Nemico americano, int Mig29x, List<Proiettile> proiettili)
        {
            if (americano.X > Mig29x)
            {
                americano.Y += 10;
                int n = (americano.X - Mig29x);
                americano.X -= n / 15;

                if (americano.sparato == 1 && americano.X < Mig29x + 50 && americano.life >= 1)
                {
                    RazzoNemico r = new RazzoNemico(americano.X, americano.Y + 60); ;

                    proiettili.Add(r);
                    americano.sparato--;


                }

            }
            else if (americano.X == Mig29x)
            {
                americano.Y += 10;

            }
            else
            {
                americano.Y += 10;
                int v = (Mig29x - americano.X);
                americano.X += v / 15;
            }
            return americano;

        }
        virtual public Nemico Mossa3(Nemico americano, List<Proiettile> proiettili)
        {


            americano.Y += 10;
            americano.X -= 20;
            if (americano.Y == 150 && americano.life > 0)
            {
                RazzoNemico r = new RazzoNemico(americano.X, americano.Y + 60); ;

                proiettili.Add(r);

            }
            else if (americano.Y == 300 && americano.life > 0)
            {
                RazzoNemico r = new RazzoNemico(americano.X, americano.Y + 60); ;

                proiettili.Add(r);
            }
            else if (americano.Y == 450 && americano.life > 0)
            {
                RazzoNemico r = new RazzoNemico(americano.X, americano.Y + 60); ;

                proiettili.Add(r);
            }

            return americano;







        }

        virtual public Nemico MossaNave(Nemico americano, List<Proiettile> proiettili)
        {

            if (americano.X < 1500 && americano.Y < 400)
            {
                americano.Y += 3;
                americano.X += 7;
                if ((americano.Y == 300 || americano.Y == 150) && americano.life >0)
                {
                    SferaEnergetica c = new SferaEnergetica(americano.X, americano.Y + 100);
                    proiettili.Add(c);


                }


            }
            else 
            { 
                americano.Y += 3;
                americano.X -= 7;
            }
            return americano;


        }


        virtual public void Disegna(int life, int y, Graphics g)
        {

        }
        virtual public void Disegna2(int life, int y, Graphics g)
        {

        }

        virtual public void DisegnaNave(int life, int y, Graphics g)
        {

        }





        virtual public void Esplosione1(Graphics g, int X, int Y, int bottoAnimazioneLoc)
        {
            if (bottoAnimazioneLoc == 0)
            {
                g.FillEllipse(Brushes.Yellow, X + 30, Y + 50, 50, 50);
                g.FillEllipse(Brushes.Orange, X, Y + 20, 60, 60);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 50, 50);
                g.FillEllipse(Brushes.Orange, X + 15, Y - 20, 30, 30);


            }

            else if (bottoAnimazioneLoc == 1)
            {
                g.FillEllipse(Brushes.Yellow, X, Y + 50, 60, 60);
                g.FillEllipse(Brushes.Orange, X, Y, 60, 56);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 50, 50);
                g.FillEllipse(Brushes.Orange, X, Y - 20, 40, 40);



            }

            else if (bottoAnimazioneLoc == 2)
            {

                g.FillEllipse(Brushes.Yellow, X, Y + 50, 50, 50);
                g.FillEllipse(Brushes.Orange, X + 40, Y, 70, 70);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 20, 20);
                g.FillEllipse(Brushes.Orange, X + 17, Y - 20, 50, 50);



            }
            else if (bottoAnimazioneLoc == 3)
            {

                g.FillEllipse(Brushes.Yellow, X + 19, Y + 20, 30, 30);
                g.FillEllipse(Brushes.Orange, X + 40, Y, 50, 50);
                g.FillEllipse(Brushes.Red, X - 30, Y + 17, 20, 20);
                g.FillEllipse(Brushes.Orange, X + 33, Y - 20, 30, 30);




            }
            else if (bottoAnimazioneLoc == 4)
            {
                g.FillEllipse(Brushes.Yellow, X + 30, Y + 50, 40, 40);
                g.FillEllipse(Brushes.Orange, X, Y + 20, 30, 30);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 40, 40);
                g.FillEllipse(Brushes.Orange, X + 15, Y - 20, 30, 30);




            }
            else if (bottoAnimazioneLoc == 5)
            {
                g.FillEllipse(Brushes.Yellow, X, Y + 50, 50, 50);
                g.FillEllipse(Brushes.Orange, X, Y, 60, 60);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 20, 20);
                g.FillEllipse(Brushes.Orange, X, Y - 20, 30, 30);






            }
            else if (bottoAnimazioneLoc == 6)
            {

                g.FillEllipse(Brushes.Yellow, X + 19, Y + 20, 30, 30);
                g.FillEllipse(Brushes.Orange, X + 40, Y, 70, 70);
                g.FillEllipse(Brushes.Red, X - 30, Y + 17, 20, 20);
                g.FillEllipse(Brushes.Orange, X + 33, Y - 20, 30, 30);



            }
            else if (bottoAnimazioneLoc == 7)
            {
                g.FillEllipse(Brushes.Yellow, X + 30, Y + 50, 40, 40);
                g.FillEllipse(Brushes.Orange, X, Y + 20, 50, 50);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 20, 20);
                g.FillEllipse(Brushes.Orange, X + 15, Y - 20, 30, 30);




            }
            else if (bottoAnimazioneLoc == 8)
            {

                g.FillEllipse(Brushes.Yellow, X + 30, Y + 50, 20, 20);
                g.FillEllipse(Brushes.Orange, X, Y + 20, 30, 30);
                g.FillEllipse(Brushes.Red, X - 30, Y + 30, 20, 20);
                g.FillEllipse(Brushes.Orange, X + 15, Y - 20, 40, 40);
            }



        }


        public class NaveAliena : Nemico


        {


            public NaveAliena(int x, int y, int id) : base(x, y, 15)
            {
                X = x;
                Y = y;
                this.Id = id;




            }


            public override void DisegnaNave(int life, int ynuvolay, Graphics g)
            {
                if (life > 0)
                {
                     Point[] PuntiNave = new Point[] {




                    new Point (X,Y+150),
                    new Point (X+6,Y+148),
                    new Point (X+10,Y+142),
                    new Point (X+11,Y+137),
                    new Point (X+ 11,Y+122),
                    new Point (X+20,Y+114),
                    new Point (X+27,Y+103),
                    new Point (X+27,Y+97
),
                    new Point (X+44,Y+82),
                    new Point (X+52,Y+85),
                    new Point (X+56,Y+92),
                    new Point (X+58,Y+109),
                    new Point (X+56,Y+119),
                    new Point (X+48,Y+132),
                    new Point (X+59,Y+128),
                    new Point (X+76,Y+109),
                    new Point (X+81,Y+81),
                    new Point (X+76,Y+66),
                    new Point (X+69,Y+57),
                    new Point (X+31,Y+44),
                    new Point (X+75,Y+53),
                    new Point (X+105,Y+76),
                    new Point (X+111,Y+89),
                    new Point (X+114,Y+102),
                    new Point (X+111,Y+117),
                    new Point (X+101,Y+129),
                    new Point (X+84,Y+139),
                    new Point (X+120,Y+133),
                     new Point (X+139,Y+112),
                    new Point (X+141,Y+101),
                    new Point (X+140,Y+68),
                     new Point (X+133,Y+54),
                    new Point (X+117,Y+33
),
                    new Point (X+76,Y+12),
                     new Point (X+54,Y+5),
                    new Point (X+54,Y+5),
                    new Point (X+18,Y+7),
                     new Point (X,Y+6),
                    new Point (X,Y+6),
                    new Point (X-18,Y+7),
                     new Point (X-23,Y+12),
                    new Point (X-54,Y+5),
                    new Point (X-76,Y+12),
                     new Point (X-117,Y+33),
                    new Point (X-133,Y+54),
                    new Point (X-140,Y+68),
                     new Point (X-141,Y+101),
                    new Point (X-139,Y+112),
                    new Point (X-120,Y+133),
                     new Point (X-84,Y+139),
                    new Point (X-101,Y+129),
                    new Point (X-111,Y+117),
                         new Point (X-114,Y+102),
                    new Point (X-111,Y+89),
                    new Point (X-105,Y+76),
                    new Point (X-75,Y+53),
                         new Point (X-31,Y+44),
                    new Point (X-69,Y+57),
                    new Point (X-76,Y+66),
                    new Point (X-81,Y+81),
                    new Point (X-76,Y+109),
                    new Point (X-59,Y+128),
                    new Point (X-48,Y+132),
                    new Point (X-56,Y+119),
                    new Point (X-58,Y+109),
                    new Point (X-56,Y+92),
                    new Point (X-52,Y+85),
                    new Point (X-44,Y+82),
                    new Point (X-27,Y+97),
                    new Point (X-27,Y+103),
                    new Point (X-20,Y+114),
                    new Point (X-11,Y+122),
                    new Point (X-11,Y+137),
                    new Point (X-10,Y+142),
                    new Point (X-6,Y+148),
                    new Point (X,Y+150),






                    };
                    if (life == 1)
                    {
                        g.FillPolygon(Brushes.Red, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }
                    else if (life <= 3)
                    {
                        g.FillPolygon(Brushes.MediumVioletRed, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }
                    else if (life <= 5)
                    {
                        g.FillPolygon(Brushes.Violet, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }

                    else if (life <= 10)
                    {
                        g.FillPolygon(Brushes.Purple, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }
                    else { }

                    if (ynuvolay % 2 == 0)
                    {
                        Point[] ugellonemico = new Point[]
                         {
                 new Point(X , Y -40),
                 new Point(X + 15, Y ),
                 new Point(X - 15, Y ),
                 new Point(X , Y - 40)};
                        Point[] ugellonemicosx = new Point[]
                       {
                 new Point(X-20 , Y -20),
                 new Point(X -15 , Y ),
                 new Point(X -35 , Y ),
                 new Point(X -20,Y - 20)};
                        Point[] ugellonemicodx = new Point[] 
        {
                 new Point(X+20 , Y -20),
                 new Point(X +15 , Y ),
                 new Point(X +35 , Y ),
                 new Point(X +20,Y - 20)};
                    


                        g.FillPolygon(Brushes.Blue, ugellonemicosx);
                        g.FillPolygon(Brushes.Blue, ugellonemico);
                        g.FillPolygon(Brushes.Blue, ugellonemicodx);


                    }


                    else
                    {
                        Point[] ugellonemico = new Point[]
                        {
                   new Point(X, Y - 40),
                 new Point(X + 15, Y),
                 new Point(X - 15, Y),
                 new Point(X, Y - 40)};
                        g.FillPolygon(Brushes.White, ugellonemico);


                    }

                    if (life == 1)
                    {
                        g.FillPolygon(Brushes.Red, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }
                    else if (life <= 5)
                    {
                        g.FillPolygon(Brushes.Red, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }
                    else if (life <= 10)
                    {
                        g.FillPolygon(Brushes.MediumVioletRed, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }

                    else if (life <= 15)
                    {
                        g.FillPolygon(Brushes.Purple, PuntiNave);
                        g.FillEllipse(Brushes.DarkBlue, X + 8, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 16, Y + 90, 8, 20);
                        g.FillEllipse(Brushes.DarkBlue, X - 10, Y + 108, 20, 12);
                    }
                    else { }



                } else { }  ;





            }
        }
    }
}