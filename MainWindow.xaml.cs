using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();


        private double windowWidth;
        private double windowHeight;
        private Point buttonStartPosition;

        public MainWindow()
        {
            InitializeComponent();

            this.MouseMove += OnMouseMove;

           
            Loaded += (sender, args) =>
            {
                windowWidth = ActualWidth;
                windowHeight = ActualHeight;
                buttonStartPosition = btnRunAway.TranslatePoint(new Point(), this);
            };
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!btnRunAway.IsMouseOver || IsDragging())
            {
                return;
            }

            var mousePos = e.GetPosition(this); 

 
            Point newPosition = GetRandomOffset(mousePos);

            Canvas.SetLeft(btnRunAway, newPosition.X);
            Canvas.SetTop(btnRunAway, newPosition.Y);
        }

        private Point GetRandomOffset(Point currentMousePosition)
        {
            int offsetX = random.Next(-100, 100);
            int offsetY = random.Next(-100, 100);

            double newX = Math.Max(Math.Min(currentMousePosition.X + offsetX, windowWidth - btnRunAway.ActualWidth), 0);
            double newY = Math.Max(Math.Min(currentMousePosition.Y + offsetY, windowHeight - btnRunAway.ActualHeight), 0);

            return new Point(newX, newY);
        }

        private bool IsDragging()
        {
            return false; 
        }


        private void btnRunAway_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}