﻿namespace IntegralCalculator
{
    // класс Integral с методами для вычисления интеграла
    public class Integral
    {
        public event EventHandler СalculationIntegral;
        // методы для вычисления интеграла
        public double RectangleMethod(Function f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double result = 0.0;
            for (int i = 0; i < n; i++)
            {
                result += f(a + h * (i + 0.5));
            }
            result *= h;
            OnCalculationIntegral();
            return result;
        }

            public double TrapezoidMethod(Function f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double result = 0.0;
            for (int i = 1; i < n; i++)
            {
                result += f(a + h * i);
            }
            result += (f(a) + f(b)) / 2;
            result *= h;
            OnCalculationIntegral();
            return result;
        }

        protected virtual void OnCalculationIntegral()
        {
            СalculationIntegral?.Invoke(this, EventArgs.Empty);
        }
    }
}
