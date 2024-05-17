using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{
    public abstract class Bonus
    {
        public int X {  get; set; }    
        public int Y { get; set; } 

        public int tipo { get; set; }   
        bool preso { get; set; }

        public Bonus (int x, int y,int t)
        {
            X = x;
            Y = y;
            preso = false;
            tipo = t ;
          
        }

        public virtual void Disegna(Graphics g,int y) 
        { 
        
        }

    }
    class Cuore : Bonus
    {
      
        public Cuore(int x, int y ) : base(x, y,0)
        {
            X = x;
         
            Y= y;

           
            
        }
        public override void Disegna(Graphics g,int y)
        {if (y % 2 == 0)
            {
                g.FillEllipse(Brushes.DarkRed, X + 5, Y, 13, 13);
                g.FillEllipse(Brushes.DarkRed, X - 5, Y, 13, 13);
                Point[] triangolo = new Point[] {
                new Point(X + 17, Y + 7) ,
                new Point (X-5 ,Y+7),
                new Point (X+6 , Y +20) };
                g.FillPolygon(Brushes.DarkRed, triangolo);

            }
            else {
                g.FillEllipse(Brushes.Red, X + 5, Y, 13, 13);
                g.FillEllipse(Brushes.Red, X - 5, Y, 13, 13);
                Point[] triangolo = new Point[] {
                new Point(X + 19, Y + 7) ,
                new Point (X-5 ,Y+7),
                new Point (X+6 , Y +20) };
                g.FillPolygon(Brushes.Red, triangolo);

            }

        }



    }
}
