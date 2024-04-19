using System.Text;
using System.Windows;
using System.Windows.Controls;

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

            // добавление элементов в выпадающий список
            comboBoxMethod.Items.Add("Метод прямоугольников");
            comboBoxMethod.Items.Add("Метод трапеций");
        }

        // обработчик нажатия кнопки "Вычислить"
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получение введенных пользователем данных
                double a = Convert.ToDouble(textBoxA.Text);
                double b = Convert.ToDouble(textBoxB.Text);
                int n = Convert.ToInt32(textBoxN.Text);

                // задание функции
                Function f = Math.Sin;

                // создание экземпляра класса Integral
                Integral integral = new Integral();

                // проверка выбранного метода и вызов соответствующего метода класса Integral
                if (comboBoxMethod.SelectedItem.ToString() == "Метод прямоугольников")
                {
                    double resultRect = integral.RectangleMethod(f, a, b, n);
                    labelResult.Text = $"Результат вычисления интеграла методом прямоугольников: {resultRect}";
                }
                else if (comboBoxMethod.SelectedItem.ToString() == "Метод трапеций")
                {
                    double resultTrap = integral.TrapezoidMethod(f, a, b, n);
                    labelResult.Text = $"Результат вычисления интеграла методом трапеций: {resultTrap}";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода. Проверьте правильность введенных значений.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Ошибка ввода. Введено слишком большое значение в поле.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}