using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{
  
    
        class Bombardiere : Nemico
        {

        
            public Bombardiere(int x, int y, int id) : base(x, y, 2)
            {
                X = x;
                Y = y;
                this.Id = id  ;

            }

        public override void Disegna2( int life, int ynuvolay,Graphics g)

            {
                if (life > 0)
                {
                    Point[] pointsBomb = new Point[]
                    {
             new Point (X+13,Y),
             new Point (X+8,Y+8),
             new Point (X+37,Y+8),
             new Point (X+37,Y+15),
             new Point (X+13,Y+27),
             new Point (X+11,Y+36),
             new Point (X+7,Y+37),
             new Point (X+7,Y+49),
             new Point (X,Y+72),
             new Point (X-7,Y+49),
             new Point (X-7,Y+37),
             new Point (X-11,Y+36),
             new Point (X-13,Y+27),
             new Point (X-37,Y+15),
             new Point (X-37,Y+8),
             new Point (X-8,Y+8),
             new Point (X-13,Y)






                    };
                if (life > 1)
                {
                    g.FillPolygon(Brushes.DarkOliveGreen, pointsBomb);
                    g.FillEllipse(Brushes.LightBlue, X - 4, Y + 40, 8, 12);
                }
                else 
                {
                    g.FillPolygon(Brushes.OliveDrab, pointsBomb);
                    g.FillEllipse(Brushes.LightBlue, X - 4, Y + 40, 8, 12);
                }

                    if (ynuvolay % 2 == 0)
                    {
                        Point[] ugellonemico = new Point[]
                        {
                 new Point(X + 6, Y -1),
             new Point(X + 1, Y -15),
             new Point(X - 1, Y -15),
             new Point(X - 6, Y - 1)};
                        g.FillPolygon(Brushes.Blue, ugellonemico);


                    }
                    else
                    {
                        Point[] ugellonemico = new Point[]
                        {
                 new Point(X + 4, Y -1),
             new Point(X + 1, Y -20),
             new Point(X - 1, Y -20),
             new Point(X - 4, Y - 1)};
                        g.FillPolygon(Brushes.WhiteSmoke, ugellonemico);



                    }

                }
                else
                {

                }

            }
        }
    }

