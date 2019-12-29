using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace g2Asteroids
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class GamePlayWindow : Window
    {
        public GamePlayWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += AnimiereZeichenfläche;
            timer.Start();
            for (int i = 0 ; i < 5 ; i++)
            {
                asteroidsList.Add(new Asteroid(zeichenfläche));
                gameObjectsList.Add(asteroidsList.Last());
            }

            raumschiff = new Raumschiff(zeichenfläche);

            gameObjectsList.Add(raumschiff);
        }

        // TODO IMAGE Background und alle anderen bilder fest einbinden
        // TODO : diese objekte und Methoden in klasse auslagern?
        public DispatcherTimer timer = new DispatcherTimer();

        //Polymorphie: die zunächst einzeln "erstellten" Objekte über eine Liste gemeinsam "erstellen"
        //einzeln
        List<Asteroid> asteroidsList = new List<Asteroid>();
        readonly List<Rocket> rocketsList = new List<Rocket>();
        private readonly Raumschiff raumschiff;

        //gemeinsam
        List<g2AsteroidsObject> gameObjectsList = new List<g2AsteroidsObject>();

        // TODO : EventSetter auch auslagern?
        void AnimiereZeichenfläche(object sender, EventArgs e)
        {
            // POLY: zuerst die Objekte der Zeichenfläche "einzeln" animeren
            //for (int i = 0; i < asteroidsList.Count; i++)
            //{
            //    asteroidsList[i].AnimiereObjekt(timer.Interval, zeichenfläche);
            //}

            //for (int i = 0; i < rocketsList.Count; i++)
            //{
            //    rocketsList[i].AnimiereObjekt(timer.Interval, zeichenfläche);
            //}

            //raumschiff.AnimiereObjekt(timer.Interval, zeichenfläche);

            //Poly alle mit einer Schleife: 
            //for (int i = 0; i < gameObjects.Count; i++)
            //{
            //    gameObjects[i].AnimiereObjekt(timer.Interval, zeichenfläche);
            //}

            //über den Rande gegeangen
            var rocketsOverTheEdge = new List<Rocket>();
            foreach (var gameObj in gameObjectsList)
            {
                bool goneOverTheEdge = gameObj.AnimiereObjekt(timer.Interval, zeichenfläche);
                if (gameObj is Rocket && goneOverTheEdge)
                {
                    rocketsOverTheEdge.Add((Rocket)gameObj);
                }
            }
            foreach (var rocket in rocketsOverTheEdge)
            {
                rocketsList.Remove(rocket);
                gameObjectsList.Remove(rocket);
            }

            //gameObjectsList.ForEach(gameObjects => gameObjects.AnimiereObjekt(timer.Interval, zeichenfläche));

            // auf Kollisionen prüfen...
            // TODO : Kollisionen "Dynamisch über die Liste GameObjects prufen? VAR i in Items

            // zu löschende Objekte
            var deletableAsteroids = new List<Asteroid>();
            var deletableRockets = new List<Rocket>();
            foreach (var asteroid in asteroidsList)
            {
                foreach (var rocket in rocketsList)
                {
                    if (asteroid.Collided(rocket.X, rocket.Y))
                    {
                        deletableAsteroids.Add(asteroid);
                        deletableRockets.Add(rocket);
                    }
                }
            }
            // variante A
            asteroidsList = asteroidsList.Except(deletableAsteroids).ToList();
            gameObjectsList = gameObjectsList.Except(deletableAsteroids).ToList();
            // variante B
            foreach (var rocket in deletableRockets)
            {
                rocketsList.Remove(rocket);
                gameObjectsList.Remove(rocket);
            }


            // dann.......
            zeichenfläche.Children.Clear();

            // POLY : dann die Obekte mit Schleifen "einzeln" zeichnen
            //for (int i = 0; i < asteroidsList.Count; i++)
            //{
            //    asteroidsList[i].ZeichneObjekt(zeichenfläche);

            //}

            //for (int i = 0; i < rocketsList.Count; i++)
            //{
            //    rocketsList[i].ZeichneObjekt(zeichenfläche);
            //}
            //raumschiff.ZeichneObjekt(zeichenfläche);

            // POLY: dann die Objekte mit nur einer Schleife "gemeinsam" zeichnen
            foreach (var gameObject in gameObjectsList)
            {
                gameObject.ZeichneObjekt(zeichenfläche);
            }
            //gameObjectsList.ForEach(gameObject => gameObject.ZeichneObjekt(zeichenfläche));

            // GAME OVER
            // TODO : Gameover in absrtakte? virtuelle? Methode auslagern?
            bool gameOver = false;

            foreach (var asteroid in asteroidsList)
            {
                if (asteroid.Collided(raumschiff.X, raumschiff.Y))
                {
                    gameOver = true;
                    break;
                }
            }

            if (gameOver)
            {
                //raumschiff.X = zeichenfläche.ActualWidth * 0.5;
                //raumschiff.Y = zeichenfläche.ActualHeight * 0.5;
                //MessageBox.Show("GAME OVER", "Asteroids", MessageBoxButton.OK, MessageBoxImage.Error);
                asteroidsList.Clear();
                rocketsList.Clear();
                gameObjectsList.Clear();
                GameOverWindow mesGO = new GameOverWindow();
                mesGO.txtbMessage.Text = "GAME\nOVER\n***";
                mesGO.ShowDialog();

                raumschiff.Y = zeichenfläche.ActualHeight * 0.5;
                raumschiff.X = zeichenfläche.ActualWidth * 0.5;
                for (int i = 0 ; i < 5 ; i++)
                {
                    asteroidsList.Add(new Asteroid(zeichenfläche));
                    gameObjectsList.Add(asteroidsList.Last());
                }

                gameObjectsList.Add(raumschiff);
                // TODO : Spieleneustart mit Startbutton in der Massagebox beginnen und vor startbutton ausblenden
                //ButtonStart.IsEnabled = true;
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer.IsEnabled)
            {
                switch (e.Key)
                {
                    case Key.Left:
                    case Key.A:
                        raumschiff.TurnOff(true);
                        break;
                    case Key.Right:
                    case Key.D:
                        raumschiff.TurnOff(false);
                        break;
                    case Key.Up:
                    case Key.W:
                        raumschiff.Accelerating(true);
                        break;
                    case Key.Down:
                    case Key.S:
                        raumschiff.Accelerating(false);
                        break;
                    case Key.Space:
                        //kurz
                        rocketsList.Add(new Rocket(raumschiff));
                        gameObjectsList.Add(rocketsList.Last());
                        //geameObjects.Add(rocketsList[rocketsList.Count-1])

                        /* lang
                         * {
                         * Rocket p = new Rocket(raumschiff);
                         * rocketsList.Add(p); 
                         } */
                        break;

                }
            }

        }
    }
}
