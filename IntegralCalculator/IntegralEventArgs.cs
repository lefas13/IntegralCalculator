public class IntegralEventArgs : EventArgs
{
    public double Result { get; }

    public IntegralEventArgs(double result)
    {
        Result = result;
    }
}
