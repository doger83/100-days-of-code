using System.Windows;


namespace g2Asteroids
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //_MainWindow.WindowState = WindowState.Maximized;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ButtonStart.IsEnabled = false;
            ButtonQuit.IsEnabled = false;
            GamePlayWindow theSpace = new GamePlayWindow();
            theSpace.Show();
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();

            bool a = false;
            bool b = false;
            bool c;

            if (true)
            {

            }
        }
    }
}
