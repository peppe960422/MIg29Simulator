using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dd
{
    public abstract class Proiettile
    {

        public int X { get; set; }
        public int Y { get; set; }
        public bool Attivo { get; set; }
        public bool mio = false;
        public int ID { get; set; }
 

        

        public Proiettile(int x, int y,int ID)
        {
            X = x;
            Y = y;
            
            Attivo = true;
            mio = false;
            

        }
        virtual public void Disegna(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, 5, 7);
        }

        virtual public void DisegnaSfera (Graphics g,int y) 
        { if (y % 4 == 0)
            {
                g.FillEllipse(Brushes.Violet, X, Y, 17, 17);
            }
        else if (y % 2 == 0) 
            {
                g.FillEllipse(Brushes.White, X, Y, 22, 22);

            }
        else
            {
                g.FillEllipse(Brushes.Blue, X, Y, 31, 31);

            }

        }


    }
    class MioProiettile : Proiettile

    {
         
        public MioProiettile(int x, int y) : base(x, y,1)
        {
            X = x;
            Y = y;
            Attivo = true;
            mio = true;
           ID = 0;

        }




    }
    class RazzoNemico : Proiettile
    {


        public RazzoNemico(int x, int y) : base(x, y,2)
        {
            X = x;
            Y = y;
            Attivo = true;
            ID = 1;
          

        }




    }
    class SferaEnergetica:Proiettile

    { public SferaEnergetica(int x, int y) : base(x, y, 3)
        {
            X= x;
            Y= y;
            Attivo = true;
            ID = 3;


        }

















    }


}
