using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace g2Asteroids
{
    class Rocket : g2AsteroidsObject
    {
        // TODO : Rockedspeed nicht an raumschiffspeed koppeln eigene konstante geschwindigkeit setzen stichwort Hilfsklasse? Pytagoras? 
        public Rocket(Raumschiff raumschiff)
            : base(raumschiff.X, raumschiff.Y, 3 * raumschiff.VX, 3 * raumschiff.VY)
        {
            // Leer
        }

        public override void ZeichneObjekt(Canvas zeichenfläche)
        {
            // TODO Rockets so animieren wie die ateroiden als sie geflimmert haben nur als linie! Rendertransform transform point 
            Ellipse elli = new Ellipse
            {
                Width = 15.0,
                Height = 15.0,
                Fill = Brushes.Red
            };

            // TODO : Dies hier jeweils in Mutterklasse einmalig einfügen?
            zeichenfläche.Children.Add(elli);
            Canvas.SetLeft(elli, X - 0.5 * elli.Width);
            Canvas.SetTop(elli, Y - 0.5 * elli.Height);
        }
    }
}
