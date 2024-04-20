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
        public event EventHandler<IntegralEventArgs> IntegralCalculated;
        public MainWindow()
        {
            InitializeComponent();

            // добавление элементов в выпадающий список
            comboBoxMethod.Items.Add("Метод прямоугольников");
            comboBoxMethod.Items.Add("Метод трапеций");
            comboBoxFunc.Items.Add("Функция синус");
            comboBoxFunc.Items.Add("Функция косинус");
            comboBoxFunc.Items.Add("Функция тангенс");
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
                if (comboBoxFunc.SelectedItem.ToString() == "Функция синус")
                {
                    f = Math.Sin;
                }
                if (comboBoxFunc.SelectedItem.ToString() == "Функция косинус")
                {
                    f = Math.Cos;
                }
                if (comboBoxFunc.SelectedItem.ToString() == "Функция тангенс")
                {
                    f = Math.Tan;
                }

                // создание экземпляра класса Integral
                Integral integral = new Integral();

                double result = 0.0;

                // проверка выбранного метода и вызов соответствующего метода класса Integral
                if (comboBoxMethod.SelectedItem.ToString() == "Метод прямоугольников")
                {
                    result = integral.RectangleMethod(f, a, b, n);
                    labelResult.Text = $"Результат вычисления интеграла методом прямоугольников: {result}";
                }
                else if (comboBoxMethod.SelectedItem.ToString() == "Метод трапеций")
                {
                    result = integral.TrapezoidMethod(f, a, b, n);
                    labelResult.Text = $"Результат вычисления интеграла методом трапеций: {result}";
                }
                OnIntegralCalculated(result);
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
        protected virtual void OnIntegralCalculated(double result)
        {
            IntegralCalculated?.Invoke(this, new IntegralEventArgs(result));
        }
    }
}