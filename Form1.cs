
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static _2dd.Form1;
using static _2dd.Nemico;

namespace _2dd
{

    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer_nuvola =
            new System.Windows.Forms.Timer();

        public Aereo plane;

        public List<Nuvole> nuvolette = new List<Nuvole>();
        public List<Nemico> americani = new List<Nemico>();
        public List<Bonus> bonuses = new List<Bonus>();
        public List<Proiettile> proiettili = new List<Proiettile>();


        public int X = 99;
        public int Y = 700;
        int[] Xnuvola = { 100, 450, 700, 800, 550, 950, 1600, 1100, 1250 };
        int[] Yamericanopartenza = { -60, -70, -150 };
        public int velocita = 30;


        public bool botto = false;
        int punti = 0;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            plane = new Aereo(X, Y);
            for (int i = 0; i < Xnuvola.Length; i++)
            {
                nuvolette.Add(new Nuvole(Xnuvola[i], 0));

            }





            americani.Add(new AereoNemico(100, Yamericanopartenza[0], 0));

            americani.Add(new AereoNemico(400, Yamericanopartenza[0], 1));

            americani.Add(new AereoNemico(950, Yamericanopartenza[0], 2));

            americani.Add(new Bombardiere(600, Yamericanopartenza[1], 3));

            americani.Add(new Bombardiere(800, Yamericanopartenza[1], 4));

            americani.Add(new NaveAliena(100, Yamericanopartenza[2], 5));



            Cuore prova = new Cuore(-700, 900);

            bonuses.Add(prova);


            timer_nuvola.Interval = velocita;
            timer_nuvola.Tick += MovementTimer_Tick;


            timer_nuvola.Start();


        }
        public void BonusSiMuovono()
        {
            foreach (var bonus in bonuses)
            {
                if (bonus.Y < 7731)
                {
                    bonus.Y += 10;
                }
                else
                {
                    Random random = new Random();
                    int numeroCasuale = random.Next(100, 1100);
                    bonus.X = numeroCasuale;
                    bonus.Y = -20;

                }
            }

        }

        public void ControllaCuori()
        {
            foreach (var bonus in bonuses)
            {
                if (VerificaBonus(bonus) && plane.immune < 0)
                {

                    plane.vite++;
                    plane.immune = 20;
                    plane.bonus = true;
                }


            }


        }

        public void NuvoleSiMuovono()

        {

            if (nuvolette[0].PosizioneY < 1000)
            {

                nuvolette[0].PosizioneY += 7;
            }
            else if (nuvolette[0].PosizioneY >= 1000)
            { nuvolette[0].PosizioneY = Xnuvola[0] = 0; }
            if (nuvolette[1].PosizioneY < 1000)
            {

                nuvolette[1].PosizioneY += 1;

            }
            else if (nuvolette[1].PosizioneY == 1000)
            { nuvolette[1].PosizioneY = Xnuvola[1] = 0; }
            if (nuvolette[2].PosizioneY < 1000)
            {

                nuvolette[2].PosizioneY += 3;

            }
            else if (nuvolette[2].PosizioneY >= 1000)
            { nuvolette[2].PosizioneY = 0; }
            if (nuvolette[3].PosizioneY < 1000)
            {

                nuvolette[3].PosizioneY += 5;
            }
            else if (nuvolette[3].PosizioneY == 1000)
            { nuvolette[3].PosizioneY = Xnuvola[3] = 0; }
            if (nuvolette[4].PosizioneY < 1000)
            {

                nuvolette[4].PosizioneY += 10;
            }
            else if (nuvolette[4].PosizioneY == 1000)
            { nuvolette[4].PosizioneY = Xnuvola[4] = 0; }
            if (nuvolette[5].PosizioneY < 1000)
            {

                nuvolette[5].PosizioneY += 9;
            }
            else if (nuvolette[5].PosizioneY >= 1000)
            { nuvolette[5].PosizioneY = Xnuvola[5] = 0; }
            if (nuvolette[6].PosizioneY < 1000)
            {

                nuvolette[6].PosizioneY += 8;
            }
            else if (nuvolette[6].PosizioneY >= 1000)
            { nuvolette[6].PosizioneY = Xnuvola[6] = 0; }
            if (nuvolette[7].PosizioneY < 1000)
            {

                nuvolette[7].PosizioneY += 2;
            }
            else if (nuvolette[7].PosizioneY >= 1000)
            { nuvolette[7].PosizioneY = Xnuvola[7] = 0; }
            if (nuvolette[8].PosizioneY < 1000)
            {

                nuvolette[8].PosizioneY += 1;
            }
            else if (nuvolette[8].PosizioneY >= 1000)
            { nuvolette[8].PosizioneY = Xnuvola[8] = 0; }





        }



        public void NemiciSiMuovono()

        {

            for (int i = 0; i < americani.Count; i++)
            {
                if (americani[i].Id == 0)
                {
                    if (americani[i].Y < 3863)
                    {
                        americani[i] = americani[0].Mossa1(americani[i], X, proiettili);
                    }

                    else
                    {
                        Random random = new Random();
                        int numeroCasuale = random.Next(400, 800);

                        americani[i].Y = -63;
                        americani[i].X = numeroCasuale;
                        americani[i].life = 1;
                        americani[i].sparato = 1;
                        americani[i].bottoanimazine = 8;

                    }



                }
                else if (americani[i].Id == 1)
                {

                    if (americani[i].Y < 2777)
                    {
                        americani[i] = americani[i].Mossa2(americani[i], X, proiettili);
                    }

                    else
                    {
                        americani[i].Y = Yamericanopartenza[1];
                        americani[i].X = plane.PosizioneX + 400;
                        americani[i].life = 1;
                        americani[i].bottoanimazine = 8;
                        americani[i].sparato = 1;
                    }



                }
                else if (americani[i].Id == 2)
                {
                    if ((americani[i].Y < 7001)) { americani[i] = americani[i].Mossa2(americani[i], X, proiettili); }

                    else
                    {
                        Random random = new Random();
                        int numeroCasuale = random.Next(400, 800);

                        americani[i].Y = -63;
                        americani[i].X = numeroCasuale;
                        americani[i].life = 1;
                        americani[i].sparato = 1;
                        americani[i].bottoanimazine = 8;
                    }
                }

                else if (americani[i].Id == 3)
                {
                    if (americani[i].Y < 8111)
                    {
                        americani[i] = americani[i].Mossa3(americani[i], proiettili);
                    }

                    else
                    {
                        americani[i].Y = Yamericanopartenza[1];
                        americani[i].X = plane.PosizioneX + 400;
                        americani[i].life = 2;
                        americani[i].bottoanimazine = 8;
                        americani[i].sparato = 1;
                    }


                }

                else if (americani[i].Id == 4)
                {
                    if (americani[i].Y < 5847)
                    {
                        americani[i] = americani[i].Mossa1(americani[i], X, proiettili);
                    }
                    else

                    {
                        Random random = new Random();
                        int numeroCasuale = random.Next(400, 800);

                        americani[i].Y = -63;
                        americani[i].X = numeroCasuale;
                        americani[i].life = 2;
                        americani[i].sparato = 1;
                        americani[i].bottoanimazine = 8;

                    }


                }

                else if (americani[i].Id == 5)
                {
                    if (americani[i].Y < 1847)
                    {
                        americani[i].MossaNave(americani[i], proiettili);
                    }
                    else

                    {
                        Random random = new Random();
                        int numeroCasuale = random.Next(100, 800);

                        americani[i].Y = -63;
                        americani[i].X = numeroCasuale;
                        americani[i].life = 15;
                        americani[i].sparato = 1;
                        americani[i].bottoanimazine = 8;

                    }


                }


                else { }


            }
        }

        public void ProiettiliSiMuovono()
        {

            foreach (Proiettile p in proiettili)
            {
                if (p.ID == 0)
                {
                    p.Y += -40;
                }
                if (p.ID == 3)
                {
                    if (p.X > X)
                    {
                        p.Y += 7;
                        int n = (p.X - X);
                        p.X -= n / 20;


                    }
                    else if (p.X == X)
                    {
                        p.Y += 7;



                    }
                    else
                    {
                        p.Y += 7
                            ;
                        int v = (X - p.X);
                        p.X += v / 20;


                    }
                }
                else { p.Y += 20; }

            }


        }
        public void ControllaProiettili() //questo controlla che il mio aereo venga colpito!
        {
            foreach (Proiettile r in proiettili)
            {
                if (((((((X < r.X + 33 && X > r.X - 33) &&
                        (Y > r.Y + 5 && Y < r.Y + 60)) ||
                        ((X < r.X + 33 && X > r.X - 33) &&
                        (Y + 90 > r.Y + 5 && Y + 90 < r.Y + 60)) ||
                        ((X - 33 < r.X + 33 && X - 33 > r.X - 33) &&
                        (Y + 72 > r.Y + 5 && Y + 72 < r.Y + 60)) ||
                        ((X - 33 < r.X + 33 && X + 33 > r.X - 33) &&
                        (Y + 72 > r.Y + 5 && Y + 72 < r.Y + 60)))))
                         ) && plane.immune <= 0 && !r.mio)
                {
                    plane.vite--;
                    plane.immune = 50;
                    plane.colpito = true;
                    label1.Text = plane.vite.ToString();
                }


            }

            foreach (Proiettile p in proiettili)
            {
                for (int i = 0; i < americani.Count; i++)
                {
                    if (americani[i].Id >= 0 && americani[i].Id < 5)
                    {
                        if (p.Attivo && americani[i].life > 0 && VerificaCollisione(p, americani[i], 66, 60, 33))
                        {


                            p.Attivo = false;
                            americani[i].life--;
                            punti++;
                            label3.Text = (punti.ToString());
                            break;

                        }
                    }

                    else if (americani[i].Id == 5)
                    {

                        if (p.Attivo && americani[i].life > 0 && VerificaCollisione(p, americani[i], 120, 240, 100) && p.mio)
                        {
                            p.Attivo = false;
                            americani[i].life--;
                            punti++;
                            label3.Text = (punti.ToString());
                            break;



                        }


                    }



                }
            }

        }
        private bool VerificaBonus(Bonus bonus)
        {
            Rectangle rettangoloCuore = new Rectangle(bonus.X - 10, bonus.Y, 20, 20);
            Rectangle rettangoloNemico = new Rectangle(X - 33, Y, 66, 60);

            return rettangoloCuore.IntersectsWith(rettangoloNemico);




        }
        private void Controlla()
        {
            foreach (Nemico p in americani)
            {
                if ((((((X < p.X + 33 && X > p.X - 33) &&
                    (Y > p.Y + 5 && Y < p.Y + 60)) ||
                    ((X < p.X + 33 && X > p.X - 33) &&
                    (Y + 90 > p.Y + 5 && Y + 90 < p.Y + 60)) ||
                    ((X - 33 < p.X + 33 && X - 33 > p.X - 33) &&
                    (Y + 72 > p.Y + 5 && Y + 72 < p.Y + 60)) ||
                    ((X - 33 < p.X + 33 && X + 33 > p.X - 33) &&
                    (Y + 72 > p.Y + 5 && Y + 72 < p.Y + 60)))))
                    && (p.life > 0) && plane.immune <= 0 && p.life > 0)
                {
                    plane.vite--;
                    botto = true;
                    p.life = 0;
                    label3.Text = punti.ToString();




                }



            }

        }
        private bool VerificaCollisione(Proiettile proiettile, Nemico nemico, int largezza, int lunghezza, int correggiposizione)
        {
            Rectangle rettangoloProiettile = new Rectangle(proiettile.X, proiettile.Y, 3, 7);
            Rectangle rettangoloNemico = new Rectangle(nemico.X - correggiposizione, nemico.Y, largezza, lunghezza);

            return rettangoloProiettile.IntersectsWith(rettangoloNemico);


        }



        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            NuvoleSiMuovono();
            NemiciSiMuovono();

            BonusSiMuovono();
            ProiettiliSiMuovono();
            ControllaCuori();
            ControllaProiettili();
            Controlla();
            if (plane.vite < 1)
            {
                plane.contatoreAnimazioneEsplosione--;

            }

            foreach (var american in americani) { if (american.life == 0) { american.bottoanimazine--; } }

            plane.immune--;
            if (plane.immune <= 0)
            {
                plane.bonus = false;
                plane.colpito = false;

            }
            Invalidate();


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Pen penna = new Pen(Color.Red);
            Brush pennello = new SolidBrush(Color.Blue);

            int i = 0;
            foreach (Nuvole n in nuvolette)
            {
                if (i % 3 == 0)
                {
                    n.Disegna(g);

                }
                else if (i % 3 == 2)
                {
                    n.Disegna2(g);
                }
                else if (i % 3 == 1)
                {
                    n.Disegna3(g);
                }
                i++;
            }
            plane.Disegna(g);

            if (plane.vite > 0 && plane.immune < 0)
            {
                if (nuvolette[1].PosizioneY % 2 == 0)
                {

                    plane.DisegnaFiamma2(g);

                }
                else
                    plane.DisegnaFiamma1(g);


            }





            foreach (Nemico f16 in americani)
            {
                if (f16.Id == 0 || f16.Id == 1 || f16.Id == 2)
                {
                    f16.Disegna(f16.life, nuvolette[1].PosizioneY, g);
                }
                else if (f16.Id == 3 || f16.Id == 4)
                {
                    f16.Disegna2(f16.life, nuvolette[1].PosizioneY, g);

                }
                else if (f16.Id == 5)
                {

                    f16.DisegnaNave(f16.life, nuvolette[1].PosizioneY, g);

                }




            }



            foreach (Proiettile p in proiettili)
            {
                if (p.ID == 3) { p.DisegnaSfera(g, nuvolette[1].PosizioneY); }
                else { p.Disegna(g); }


            }

            foreach (Bonus b in bonuses)
            {
                if (b.tipo == 0)
                {
                    b.Disegna(g, nuvolette[1].PosizioneY);

                }


            }




            if (plane.vite <= 0 && plane.contatoreAnimazioneEsplosione > 0)
            {
                plane.disegnaesplosione(g, plane.contatoreAnimazioneEsplosione, X, Y);





                if (plane.contatoreAnimazioneEsplosione <= 1 && plane.vite <= 0)

                {

                    timer_nuvola.Stop();

                    punti = 0;
                    label3.Text = "0";
                    MessageBox.Show("Willst du noch spielen?", "*** BOOM! ***");
                    plane.immune = 100;
                    plane.vite = 1;
                    plane.contatoreAnimazioneEsplosione = 12;
                    timer_nuvola.Start();





                }



            }
            foreach (Nemico nemico in americani)
            {
                if (nemico.bottoanimazine > 0 && nemico.life == 0)
                {
                    nemico.Esplosione1(g, nemico.X, nemico.Y, nemico.bottoanimazine);


                }
            }

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    X = X - 30;
                    plane.PosizioneX = X;
                    Invalidate();
                    break;
                case Keys.Right:
                    X = X + 30;
                    plane.PosizioneX = X;
                    Invalidate();
                    break;
                case Keys.Up:
                    Y = Y - 5;
                    plane.PosizioneY = Y;

                    Invalidate();
                    break;
                case Keys.Down:

                    Y = Y + 5;
                    plane.PosizioneY = Y;

                    Invalidate();
                    break;
                case Keys.Space:
                    if (plane.immune < 0)
                    {
                        //HoSparato = true;

                        Proiettile DX = new MioProiettile(X + 33, Y + 64);

                        Proiettile SX = new MioProiettile(X - 33, Y + 64);
                        proiettili.Add(DX);
                        proiettili.Add(SX);
                        Invalidate();
                        break;
                    }
                    else { break; }
            }


            return base.ProcessCmdKey(ref msg, keyData);

        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }


}


















