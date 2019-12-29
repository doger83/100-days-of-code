using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace g2Asteroids
{
    abstract class g2AsteroidsObject
    {
        double x;
        double y;
        double vx;
        double vy;
        protected Polygon umriss = new Polygon();

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double VX
        {
            get { return vx; }
            set { vx = value; }
        }
        public double VY
        {
            get { return vy; }
            set { vy = value; }
        }

        public g2AsteroidsObject(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public g2AsteroidsObject(double x, double y,
                                 double vx, double vy)
        {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
        }

        public abstract void ZeichneObjekt(Canvas zeichenfläche);

        public bool AnimiereObjekt(TimeSpan intervall, Canvas zeichenfläche)
        {
            x += vx * intervall.TotalSeconds;
            y += vy * intervall.TotalSeconds;

            //TODO auf WIEDERAPPRALLEN setzen? Video "erste WPF" 
            bool goneOverTheEdge = false;

            if (x < 0.0)
            {
                goneOverTheEdge = true;
                x = zeichenfläche.ActualWidth;

            }
            else if (x > zeichenfläche.ActualWidth)
            {
                goneOverTheEdge = true;
                x = 0;

            }
            if (y < 0.0)
            {
                goneOverTheEdge = true;
                y = zeichenfläche.ActualHeight;

            }
            else if (y > zeichenfläche.ActualHeight)
            {
                goneOverTheEdge = true;
                y = 0;

            }
            return goneOverTheEdge;
        }
    }
}



