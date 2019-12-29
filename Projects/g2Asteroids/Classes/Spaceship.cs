using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace g2Asteroids
{
    //[Serializable]
    class Raumschiff : g2AsteroidsObject
    {
        // TODO : topspeed in Mutterklasse verschieben (rocket brauch auch Topspeed? zuerst langsam dann schnell?)
        readonly double topspeedHigh = 500.0;
        readonly double topspeedLow = -500.0;

        //Konstruktor der Kindklasse        
        public Raumschiff(Canvas _zeichenfläche)
                : base(500, 500, 40, 40)
        {
            umriss.Points.Add(new Point(0.0, -55.0));
            umriss.Points.Add(new Point(55.0, 55.0));
            umriss.Points.Add(new Point(-55.0, 55.0));

            // TODO Pfad für IMG so anpassen dass es nach der installation passt







            umriss.StrokeThickness = 5;
            umriss.Stroke = Brushes.LightYellow;            //var spaceship = new ImageBrush(img);


            //umriss.Fill = img;

        }

        //überschriebene (override) Methoden der Kindklasse
        public override void ZeichneObjekt(Canvas zeichenfläche)
        {
            // TODO : Rotate und rendertransform lernen ATAN usw Math
            double winkelInGrad = Math.Atan2(VY, VX) * 180.0 / Math.PI + 90.0;
            umriss.RenderTransform = new RotateTransform(winkelInGrad);

            // TODO : Dies hier jeweils in Mutterklasse einmalig einfügen?
            zeichenfläche.Children.Add(umriss);
            Canvas.SetLeft(umriss, X);
            Canvas.SetTop(umriss, Y);
        }

        public void TurnOff(bool turnLeft)
        {
            //TODO LEARN : Matheformel für Vectordrehung lernen und besser verstehenRotationsmatrix geht auch
            double winkel = (turnLeft ? -10 : 10) * Math.PI / 180.0;
            double vxNeu = Math.Cos(winkel) * VX - Math.Sin(winkel) * VY;
            VY = Math.Sin(winkel) * VX + Math.Cos(winkel) * VY;
            VX = vxNeu;
        }

        public void Accelerating(bool isAccelerating)
        {
            //TODO : minimal und maximale beschleunigung und abbremsung als varriable ausgliedern.... 
            double faktor = isAccelerating ? 1.25 : 0.8;

            if (VX <= topspeedHigh && VX >= topspeedLow && VY <= topspeedHigh && VY >= topspeedLow)
            {

                VX *= faktor;
                VY *= faktor;
            }
            else
            {
                VX *= 0.8;
                VY *= 0.8;
            }
        }
    }
}
