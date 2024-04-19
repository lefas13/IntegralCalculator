using System.Text;
using System.Windows;

namespace IntegralCalculator
{
    // объявление делегата
    public delegate double Function(double x);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}