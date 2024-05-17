using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{
    public class AereoNemico : Nemico
    {
       
        public AereoNemico(int x, int y,int id) : base(x, y, 1)
        {
            X = x;
            Y = y;
            this.Id = id;
        }

       
        public override void Disegna( int life, int y,Graphics g)
        {
            if (life > 0)
            {
                Point[] puntiAli = new Point[]

                {
              new Point(X , Y +60),
              new Point(X +4, Y +45),
              new Point(X + 6, Y +25),
              new Point(X+  33, Y +10 ),
              new Point(X + 5 , Y  + 12),

              new Point(X - 5 , Y  +12),
              new Point(X-  33, Y + 10 ),
              new Point(X - 6, Y +25),
              new Point(X -4, Y +45),
              new Point(X , Y +60),


                };
                Point[] puntiAlette = new Point[]
                {

              new Point(X + 5, Y + 12),
              new Point (X+10, Y+0),
              new Point (X-10, Y+0),
              new Point(X - 5, Y + 12)

              , };


                g.FillPolygon(Brushes.Olive, puntiAli);
                g.FillPolygon(Brushes.Olive, puntiAlette);
                g.FillEllipse(Brushes.LightBlue, X - 3, Y + 30, 6, 10);

                if (y % 2== 0)
                {
                    Point[] ugellonemico = new Point[]
                    {
                  new Point(X + 4, Y -1),
              new Point(X + 1, Y -10),
              new Point(X - 1, Y -10),
              new Point(X - 4, Y - 1)};
                    g.FillPolygon(Brushes.Orange, ugellonemico);


                }
                else
                {
                    Point[] ugellonemico = new Point[]
                    {
                  new Point(X + 4, Y -1),
              new Point(X + 1, Y -20),
              new Point(X - 1, Y -20),
              new Point(X - 4, Y - 1)};
                    g.FillPolygon(Brushes.Yellow, ugellonemico);



                }
            }
            else
            {


            }

            return;
        }

    }

}
